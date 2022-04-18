/*
Created		3/21/2022
Modified		4/27/2022
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

Create Database nancurunaisadb
go

use nancurunaisadb

Create table [paciente]
(
	[idPaciente] Integer Identity(1,1) NOT NULL, UNIQUE ([idPaciente]),
	[nombres] Nvarchar(50) NOT NULL,
	[apellidos] Nvarchar(50) NOT NULL,
	[sexo] Varchar(1) NOT NULL Constraint [CHK_Paciente] Check (sexo='F' OR sexo='M'),
	[edad] Integer NOT NULL,
	[nacionalidad] Nvarchar(50) NOT NULL,
	[profesion_oficio] Nvarchar(50) NULL,
	[horas_trabajo] Float NULL,
	[numCel] Nvarchar(14) NOT NULL,
	[fecha_nacimiento] Date NOT NULL,
Primary Key ([idPaciente])
) 
go

Create table [cita]
(
	[idCita] Integer Identity(1,1) NOT NULL, UNIQUE ([idCita]),
	[idHabitacion] Integer NOT NULL,
	[fechaHora] Datetime NOT NULL,
	[pendiente] Bit Default 1 NOT NULL,
	[direccion_domicilio] Nvarchar(100) NULL,
Primary Key ([idCita])
) 
go

Create table [terapia]
(
	[idTerapia] Integer Identity(1,1) NOT NULL, UNIQUE ([idTerapia]),
	[nombreTerapia] Nvarchar(50) NOT NULL,
	[duracion] Integer NOT NULL,
	[precioDomicilio] Float NOT NULL,
	[precioLocal] Float NOT NULL,
Primary Key ([idTerapia])
) 
go

Create table [promocion]
(
	[idPromocion] Integer Identity(1,1) NOT NULL, UNIQUE ([idPromocion]),
	[nombrePromocion] Nvarchar(50) NOT NULL,
	[descripcion] Nvarchar(200) NOT NULL,
	[activo] Bit Default 1 NOT NULL,
Primary Key ([idPromocion])
) 
go

Create table [masajista]
(
	[idMasajista] Integer Identity(1,1) NOT NULL, UNIQUE ([idMasajista]),
	[nombres] Nvarchar(50) NOT NULL,
	[apellidos] Nvarchar(50) NOT NULL,
	[fechaNacimiento] Date NOT NULL,
	[correo] Nvarchar(256) NOT NULL, UNIQUE ([correo]),
	[password] Nvarchar(50) NOT NULL,
	[foto] Varchar(50) NULL,
	[roll] Nvarchar(30) NOT NULL,
	[numCel] Nvarchar(14) NOT NULL,
	[activo] Bit Default 1 NOT NULL,
	[sexo] Char(1) NOT NULL Check (sexo='F' OR sexo='M'),
	[horaEntrada] Time NOT NULL,
	[horaSalida] Time NOT NULL,
Primary Key ([idMasajista])
) 
go

Create table [habitacion]
(
	[idHabitacion] Integer Identity(1,1) NOT NULL, UNIQUE ([idHabitacion]),
	[idSucursal] Integer NOT NULL,
	[nombreHabitacion] Nvarchar(10) NOT NULL,
Primary Key ([idHabitacion])
) 
go

Create table [sucursal]
(
	[idSucursal] Integer Identity(1,1) NOT NULL, UNIQUE ([idSucursal]),
	[nombreSucursal] Nvarchar(50) NOT NULL,
	[direccion] Nvarchar(50) NOT NULL,
Primary Key ([idSucursal])
) 
go

Create table [amnanesis]
(
	[idAmnanesis] Integer Identity(1,1) NOT NULL, UNIQUE ([idAmnanesis]),
	[idPaciente] Integer NOT NULL,
	[escolaridad] Nvarchar(50) NULL,
	[estadoCivil] Nvarchar(50) NULL,
	[direccion] Nvarchar(50) NULL,
Primary Key ([idAmnanesis])
) 
go

Create table [terapiaCita]
(
	[idCita] Integer NOT NULL,
	[idTerapia] Integer NOT NULL,
Primary Key ([idCita],[idTerapia])
) 
go

Create table [pacienteCita]
(
	[idCita] Integer NOT NULL,
	[idPaciente] Integer NOT NULL,
Primary Key ([idCita],[idPaciente])
) 
go

Create table [masajistaCita]
(
	[idCita] Integer NOT NULL,
	[idMasajista] Integer NOT NULL,
Primary Key ([idCita],[idMasajista])
) 
go

Create table [amnanesisInfo]
(
	[idCita] Integer NOT NULL,
	[idPaciente] Integer NOT NULL,
	[motivo] Nvarchar(200) NULL,
	[HEA] Nvarchar(200) NULL,
	[observacionAnalisis] Nvarchar(200) NULL,
	[diagnosticoProblema] Nvarchar(200) NULL,
	[proxCita] Datetime NULL,
Primary Key ([idCita],[idPaciente])
) 
go

Create table [signosVitales]
(
	[idCita] Integer NOT NULL,
	[idPaciente] Integer NOT NULL,
	[FC] Integer NOT NULL,
	[FR] Integer NOT NULL,
	[PA] Integer NOT NULL,
	[T] Float NOT NULL,
Primary Key ([idCita],[idPaciente])
) 
go

Create table [AFP]
(
	[idAmnanesis] Integer NOT NULL,
	[otros] Nvarchar(200) NULL,
Primary Key ([idAmnanesis])
) 
go

Create table [TipoAFP]
(
	[idTipoAFP] Integer Identity(1,1) NOT NULL, UNIQUE ([idTipoAFP]),
	[idAmnanesis] Integer NOT NULL,
	[nombreAFP] Nvarchar(50) NOT NULL,
	[descripcion] Nvarchar(200) NULL,
Primary Key ([idTipoAFP])
) 
go

Create table [APNP]
(
	[idAmnanesis] Integer NOT NULL,
	[farmacos] Bit Default 0 NOT NULL,
	[nombPosFar] Nvarchar(200) NULL,
Primary Key ([idAmnanesis])
) 
go

Create table [tipoAPNP]
(
	[idTipoAPNP] Integer Identity(1,1) NOT NULL, UNIQUE ([idTipoAPNP]),
	[idAmnanesis] Integer NOT NULL,
	[nombreAPNP] Nvarchar(15) NOT NULL,
	[tipo] Nvarchar(50) NULL,
	[cantFrec] Nvarchar(50) NULL,
Primary Key ([idTipoAPNP])
) 
go

Create table [APP]
(
	[idAPP] Integer Identity(1,1) NOT NULL, UNIQUE ([idAPP]),
	[idAmnanesis] Integer NOT NULL,
	[nombre] Nvarchar(35) NOT NULL,
	[descripcion] Nvarchar(200) NULL,
Primary Key ([idAPP])
) 
go

Create table [factura]
(
	[idFactura] Integer Identity(1,1) NOT NULL, UNIQUE ([idFactura]),
	[idCita] Integer NOT NULL,
	[descuento] Float NULL,
	[subTotal] Float NOT NULL,
	[total] Float NOT NULL,
Primary Key ([idFactura])
) 
go

Create table [promocionCita]
(
	[idPromocion] Integer NOT NULL,
	[idCita] Integer NOT NULL,
Primary Key ([idPromocion],[idCita])
) 
go

Create table [dia]
(
	[idDia] Integer Identity(1,1) NOT NULL, UNIQUE ([idDia]),
	[nombreDia] Nvarchar(10) NOT NULL,
Primary Key ([idDia])
) 
go

Create table [diaLibre]
(
	[idMasajista] Integer NOT NULL,
	[idDia] Integer NOT NULL,
Primary Key ([idMasajista],[idDia])
) 
go


Alter table [pacienteCita] add  foreign key([idPaciente]) references [paciente] ([idPaciente])  on update no action on delete cascade 
go
Alter table [amnanesis] add  foreign key([idPaciente]) references [paciente] ([idPaciente])  on update no action on delete cascade 
go
Alter table [terapiaCita] add  foreign key([idCita]) references [cita] ([idCita])  on update no action on delete cascade 
go
Alter table [pacienteCita] add  foreign key([idCita]) references [cita] ([idCita])  on update no action on delete cascade 
go
Alter table [masajistaCita] add  foreign key([idCita]) references [cita] ([idCita])  on update no action on delete cascade 
go
Alter table [factura] add  foreign key([idCita]) references [cita] ([idCita])  on update no action on delete cascade 
go
Alter table [promocionCita] add  foreign key([idCita]) references [cita] ([idCita])  on update no action on delete cascade 
go
Alter table [terapiaCita] add  foreign key([idTerapia]) references [terapia] ([idTerapia])  on update no action on delete no action 
go
Alter table [promocionCita] add  foreign key([idPromocion]) references [promocion] ([idPromocion])  on update no action on delete no action 
go
Alter table [masajistaCita] add  foreign key([idMasajista]) references [masajista] ([idMasajista])  on update no action on delete no action 
go
Alter table [diaLibre] add  foreign key([idMasajista]) references [masajista] ([idMasajista])  on update no action on delete cascade 
go
Alter table [cita] add  foreign key([idHabitacion]) references [habitacion] ([idHabitacion])  on update no action on delete no action 
go
Alter table [habitacion] add  foreign key([idSucursal]) references [sucursal] ([idSucursal])  on update no action on delete no action 
go
Alter table [AFP] add  foreign key([idAmnanesis]) references [amnanesis] ([idAmnanesis])  on update no action on delete cascade 
go
Alter table [APNP] add  foreign key([idAmnanesis]) references [amnanesis] ([idAmnanesis])  on update no action on delete cascade 
go
Alter table [APP] add  foreign key([idAmnanesis]) references [amnanesis] ([idAmnanesis])  on update no action on delete cascade 
go
Alter table [amnanesisInfo] add  foreign key([idCita],[idPaciente]) references [pacienteCita] ([idCita],[idPaciente])  on update no action on delete cascade 
go
Alter table [signosVitales] add  foreign key([idCita],[idPaciente]) references [amnanesisInfo] ([idCita],[idPaciente])  on update no action on delete cascade 
go
Alter table [TipoAFP] add  foreign key([idAmnanesis]) references [AFP] ([idAmnanesis])  on update no action on delete cascade 
go
Alter table [tipoAPNP] add  foreign key([idAmnanesis]) references [APNP] ([idAmnanesis])  on update no action on delete cascade 
go
Alter table [diaLibre] add  foreign key([idDia]) references [dia] ([idDia])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


