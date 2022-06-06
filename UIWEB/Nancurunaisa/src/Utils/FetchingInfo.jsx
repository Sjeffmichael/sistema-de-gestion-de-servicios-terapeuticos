/*Pagination All Methods */
export async function GetByPagTeraTa(Page,perPage){
    const res = await fetch("https://www.mecallapi.com/api/users?page=" + Page + "&per_page=" + perPage);
    const result = await res.json();
    return result;
}

export async function GetByPagSucur(Page,perPage){
    const res = await fetch("https://www.mecallapi.com/api/attractions?page=" + Page + "&per_page=" + perPage);
    const result = await res.json();
    return result;
}

export async function GetByPagPacS(Page,perPage){
  const res = await fetch("https://www.mecallapi.com/api/users?page=" + Page + "&per_page=" + perPage);
  const result = await res.json();
  return result;
}

export async function GetByPagTera(Page,perPage){
  const res = await fetch("https://www.mecallapi.com/api/attractions?page=" + Page + "&per_page=" + perPage);
  const result = await res.json();
  return result;
}

export async function GetByPagCitas(Page,perPage){
  /*const res = await fetch("https://www.mecallapi.com/api/attractions?page=" + Page + "&per_page=" + perPage);*/
  /*const result = await res.json();*/
  const result = [{Fecha:"2022-05-30",Hora:"19:00"}]
  return result;
}

/*Get all information from specific id */
export async function GetByIdTeraTa(id){
    const res = await fetch("https://www.mecallapi.com/api/users/"+id);
    const result = await res.json();
    return result;
}

export async function GetByIdPac(id){
  const res = await fetch("https://www.mecallapi.com/api/users/"+id);
  const result = await res.json();
  return result;
}

export async function GetByIdSucur(id){
  const res = await fetch(" https://www.mecallapi.com/api/attractions/"+id);
  const result = await res.json();
  return result;
}

export async function GetByIdTera(id){
  const res = await fetch(" https://www.mecallapi.com/api/attractions/"+id);
  const result = await res.json();
  return result;
}

/*Searching All Methods */
export async function SearchTeraTa(search){
    const res = await fetch("https://www.mecallapi.com/api/users?search="+search);
    const result = await res.json();
    return result;
}

export async function SearchSucur(search){
    const res = await fetch(" https://www.mecallapi.com/api/attractions?search="+search);
    const result = await res.json();
    return result;
}

export async function SearchPacS(search){
  const res = await fetch("https://www.mecallapi.com/api/users?search="+search);
  const result = await res.json();
  return result;
}

export async function SearchTera(search){
  const res = await fetch(" https://www.mecallapi.com/api/attractions?search="+search);
  const result = await res.json();
  return result;
}

/*Creating */
export async function CreateTeraTa(data){
    const res = await fetch('https://www.mecallapi.com/api/users/create', {
       method: 'POST',
       headers: {
         Accept: 'application/form-data',
         'Content-Type': 'application/json',
       },body: JSON.stringify(data),
     })
     const result = await res.json();
     return result;
}

export async function CreateSucur(data){
  const res = await fetch('https://www.mecallapi.com/api/auth/attractions/create', {
     method: 'POST',
     headers: {
       Accept: 'application/form-data',
       'Content-Type': 'application/json',
       Authorization: "Bearer "+localStorage.getItem('accessToken')
     },body: JSON.stringify(data),
   })
   const result = await res.json();
   return result;
}

export async function CreatePac(data){
  const res = await fetch('https://www.mecallapi.com/api/users/create', {
     method: 'POST',
     headers: {
       Accept: 'application/form-data',
       'Content-Type': 'application/json',
     },body: JSON.stringify(data),
   })
   const result = await res.json();
   return result;
}

export async function CreateTera(data){
  const res = await fetch('https://www.mecallapi.com/api/auth/attractions/create', {
     method: 'POST',
     headers: {
       Accept: 'application/form-data',
       'Content-Type': 'application/json',
       Authorization: "Bearer "+localStorage.getItem('accessToken')
     },body: JSON.stringify(data),
   })
   const result = await res.json();
   return result;
}

/*Updating */
export async function UpdateTeraTa(data){
  const res = await fetch("https://www.mecallapi.com/api/users/update",{
    method:"PUT",
    headers: {
      Accept: 'application/form-data',
      'Content-Type': 'application/json',
    },body: JSON.stringify(data)
  })
  const result = await res.json();
     return result;
}

export async function UpdateSucursal(data){
  const res = await fetch("https://www.mecallapi.com/api/auth/attractions/update",{
    method:"PUT",
    headers: {
      Accept: 'application/form-data',
      'Content-Type': 'application/json',
      Authorization: "Bearer "+localStorage.getItem('accessToken')
    },body: JSON.stringify(data),
  })
  const result = await res.json();
     return result;
}

export async function UpdatePac(data){
  const res = await fetch("https://www.mecallapi.com/api/users/update",{
    method:"PUT",
    headers: {
      Accept: 'application/form-data',
      'Content-Type': 'application/json',
    },body: JSON.stringify(data)
  })
  const result = await res.json();
     return result;
}

export async function UpdateTera(data){
  const res = await fetch("https://www.mecallapi.com/api/auth/attractions/update",{
    method:"PUT",
    headers: {
      Accept: 'application/form-data',
      'Content-Type': 'application/json',
      Authorization: "Bearer "+localStorage.getItem('accessToken')
    },body: JSON.stringify(data),
  })
  const result = await res.json();
     return result;
}

/*Deleting */
export async function DeleteTeraTa(data){
    const res = await fetch('https://www.mecallapi.com/api/users/delete', {
       method: 'DELETE',
       headers: {
         Accept: 'application/form-data',
         'Content-Type': 'application/json',
       },
       body: JSON.stringify(data),
     })
     const result = await res.json();
     return result;
}

export async function DeleteSucur(data){
  const res = await fetch('https://www.mecallapi.com/api/auth/attractions/delete', {
     method: 'DELETE',
     headers: {
       Accept: 'application/form-data',
       'Content-Type': 'application/json',
       Authorization: "Bearer "+localStorage.getItem('accessToken')
     },
     body: JSON.stringify(data),
   })
   const result = await res.json();
   return result;
}

export async function DeletePac(data){
  const res = await fetch('https://www.mecallapi.com/api/users/delete', {
     method: 'DELETE',
     headers: {
       Accept: 'application/form-data',
       'Content-Type': 'application/json',
     },
     body: JSON.stringify(data),
   })
   const result = await res.json();
   return result;
}

export async function DeleteTera(data){
  const res = await fetch('https://www.mecallapi.com/api/auth/attractions/delete', {
     method: 'DELETE',
     headers: {
       Accept: 'application/form-data',
       'Content-Type': 'application/json',
       Authorization: "Bearer "+localStorage.getItem('accessToken')
     },
     body: JSON.stringify(data),
   })
   const result = await res.json();
   return result;
}

export async function FecthUSDNIORate(){
  const res = await fetch("https://v6.exchangerate-api.com/v6/2b03c3bbce449407cb6d52c1/pair/USD/NIO");
  const result = await res.json();
  localStorage.setItem('convertRate', result.conversion_rate);
  localStorage.setItem('latestRateUpdated', getDateToday());
  return result.conversion_rate;
}