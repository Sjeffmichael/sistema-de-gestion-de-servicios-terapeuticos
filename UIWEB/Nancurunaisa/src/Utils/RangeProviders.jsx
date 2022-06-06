import { Navigate, Outlet, useLocation } from "react-router-dom";

export function getMyRange() {
    const user = localStorage.getItem('user');
    if (!user) {
        return Ranges.Invited/*user.Rango */
    }
    else { return Ranges.Owner}/*This is me, if i am loged */
}

function includes(array){
    const myRange = getMyRange();
    for (let index = 0; index < array.length; index++) {
        if (array[index] == myRange){ return true }
    }
    return false;
}

export function Allow(Permited){
    if (includes(Permited.Permited)){ 
        return (<Outlet/>) 
    }
    return (<Navigate to="/Personal/Clinica" state={{from:useLocation()}} replace/>)
}

export function Deny(Exclude){
    if (!includes(Exclude.Exclude)){ 
        return (<Navigate to="/Personal/Clinica" state={{from:useLocation()}} replace/>) 
    }
    return (<Outlet/>)
}

export const Ranges={ Owner:0, Manager:1,Employ:2,Invited:3 }