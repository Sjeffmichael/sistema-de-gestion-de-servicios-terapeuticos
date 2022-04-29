import "./Clock.css";
import {Layout,Typography} from 'antd';
import { useState } from "react";
import day from "../resources/clockDay.jpg";
import night from "../resources/clockNightjpg.jpg";

const Horario = Layout;
const { Title } = Typography;

function RangeDate(min,max,today){
    var aa1=min.split(":");
    var aa2=max.split(":");
    var hourmin = parseInt(aa1[0]);
    var hourmax = parseInt(aa2[0]);
    var minmin = parseInt(aa1[1]);
    var minmax = parseInt(aa2[1]);

    if (hourmin <= today.getHours() && hourmax >= today.getHours()){
        if (hourmin == today.getHours() || hourmax == today.getHours()){
            if (minmin <= today.getMinutes() && minmax >= today.getMinutes()){
                return true;
            }else return false;
        } else return true;
    }
    else return false;
}

export default function ClockShow(props){
    var isday = false;
    var display = "Fuera del horario laboral";
    var sucur = "";
    var color = "red";
    var today = new Date();

    if (RangeDate("06:00:00","18:00:00",today)) {
        isday = true;   
    }


    if (RangeDate(props.entrada,props.salida,today)){
        if (/*Si esta con paciente*/ false){
            display = "En una cita";
            sucur = "Dirección: "+props.sucursal;
            color = "green";
        }else{
            display="Dentro del horario laboral";
            sucur = "Sucursal: " + props.sucursal;
            color="blue";
        }
    }else{
        display ="Fuera del horario laboral";
        color="red";
    }

    return(
        <Horario className="clockPerfil">
            <div className="DayNight" style={{backgroundImage:`url(${isday?day:night})`}} />
            <div style={{textAlign:"center",width:"65%"}}>
                <h1> {display} </h1>
                <h5> {sucur} </h5>
            </div>
            <div style={{width:"5%",height:"100%",backgroundColor:color,borderBottomRightRadius:"25px",borderTopRightRadius:"25px"}}/>
        </Horario>
    )
}