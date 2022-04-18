import { useLocation, Navigate, Outlet } from "react-router-dom";
import React from 'react';

class RequireAuth extends React.Component {
    render(){
    const location = useLocation();
    const auth = localStorage.getItem('accessToken');

    if(!auth){
        return(<Navigate to= "/SignIn" state={{from:location}} replace/>)
    }else{
        return(<Outlet/>)
    }
}}

export default RequireAuth