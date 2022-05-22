import "./TeraTaItem.css";
import {Row,Col,Avatar} from "antd";
import React, { useState } from 'react';

export default function TeraTaItem(props){
    const ClickHandler = (id,name) =>{
        if (typeof props.onClick === 'function') {
            props.onClick(id,name);
        }
    }
    return (
            <Row onClick={()=>ClickHandler(props.id,props.text)} className="ItemTera">
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