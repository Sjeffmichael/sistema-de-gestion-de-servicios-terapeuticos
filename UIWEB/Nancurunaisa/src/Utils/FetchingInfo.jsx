export async function FetchTerapeuta(action=0, id = 0){/*action 0:Getall,1:Detail +id, 2:Delete+id */
    switch (action) {
        case 0:
            return false;
        case 1:
            const res = await fetch("https://www.mecallapi.com/api/users/"+id)
            return await res.json();
    
        default:
            break;
    }
}