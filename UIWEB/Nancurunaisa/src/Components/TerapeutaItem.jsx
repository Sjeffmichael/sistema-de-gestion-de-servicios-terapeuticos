import "../Components/TeraTaItem.css";
import {Row,Col,Avatar} from "antd";
import React, { useState } from 'react';
import { useNavigate} from "react-router-dom";



export default function TeraTaItem(props){
    let Navigate = useNavigate();
    const ClickHandler = () =>{
        localStorage.setItem('IdTeraTaDetail', props.id);
        Navigate("/Personal/Clinica/Terapeuta");
    }
    return (
            <Row onClick={ClickHandler} className="ItemTera">
                <Col className="ColCardIcon" span={6}>
                    <Avatar size="large" src={props.avatar}/>
                </Col>
                <Col span={2}/>
                <Col span={16}>
                {props.text}
                </Col>
            </Row>
    )
}