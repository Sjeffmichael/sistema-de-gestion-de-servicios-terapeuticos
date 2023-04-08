global using api_nancurunaisa.Models;
global using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.Extensions.FileProviders;
using api_nancurunaisa.Data;
using api_nancurunaisa.Resolvers.Queries;
using api_nancurunaisa.Resolvers.Mutations;
using HotChocolate.Types.Pagination;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy
                          .WithOrigins(
                              "http://localhost:3000", 
                              "http://172.23.82.105:3000",
                              "http://25.14.18.58:3000",
                              "http://192.168.1.101:3000"
                              )
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers();
builder.Services.AddDbContext<nancuranaisaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddGraphQLServer()
    .SetPagingOptions(new PagingOptions { DefaultPageSize = 200 })
    .AddQueryType(d => d.Name("Query"))
        .AddType<TerapeutaQueryResolver>()
        .AddType<PacienteQueryResolver>()
        .AddType<TerapiaQueryResolver>()
        .AddType<PromocionQueryResolver>()
        .AddType<UsuarioQueryResolver>()
        .AddType<DiaLibreQueryResolver>()
        .AddType<ModuloQueryResolver>()
        .AddType<OperacionQueryResolver>()
        .AddType<RolQueryResolver>()
        .AddType<EstadoCitaQueryResolver>()
        .AddType<HabitacionQueryResolver>()
        .AddType<SucursalQueryResolver>()
        .AddType<NombreDetalleQueryResolver>()
        .AddType<DetalleHCQueryResolver>()
        .AddType<CitaQueryResolver>()
        .AddType<FacturaQueryResolver>()
            .AddProjections()
            .AddFiltering()
            .AddSorting()
    .AddMutationType(d => d.Name("Mutation"))
        .AddType<Login>()
        .AddType<TerapeutaMutationResolver>()
        .AddType<UsuarioMutationResolver>()
        .AddType<TerapiaMutationResolver>()
        .AddType<PromocionMutationResolver>()
        .AddType<DiaLibreMutationResolver>()
        .AddType<ModuloMutationResolver>()
        .AddType<OperacionMutationResolver>()
        .AddType<RolMutationResolver>()
        .AddType<EstadoCitaMutationResolver>()
        .AddType<HabitacionMutationResolver>()
        .AddType<SucursalMutationResolver>()
        .AddType<NombreDetalleMutationResolver>()
        .AddType<DetalleHCMutationResolver>()
        .AddType<PacienteMutationResolver>()
        .AddType<CitaMutationResolver>()
        .AddType<FacturaMutationResolver>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();// For the wwwroot folder

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                System.IO.Path.Combine(Directory.GetCurrentDirectory(), "images")),
    RequestPath = "/images"
});

//Enable directory browsing
app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(
                System.IO.Path.Combine(Directory.GetCurrentDirectory(), "images")),
    RequestPath = "/images"
});

app.MapControllers();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapGraphQL("/graphql");


app.Run();
