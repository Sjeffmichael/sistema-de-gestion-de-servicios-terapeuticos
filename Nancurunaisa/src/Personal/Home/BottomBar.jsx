import React, { useState } from 'react';
import { Row, Col } from 'antd';
import {
    HomeOutlined,
    SearchOutlined,
    SettingOutlined,
    EnvironmentOutlined,
    HeartOutlined
} from '@ant-design/icons';
import "./BottomBar.css";
import Goo from 'gooey-react';

import {Link} from "react-router-dom";
import { render } from 'react-dom';

function BottomBar (){
    const [Unselect] = useState("unselected");
    const [Selected] = useState("selected");
    const [actualIndex,setActualIndex] = useState(2);
    const [actualMul,setActualMul] = useState(2);
    const [menu,setmenu] = useState([
        {mul:6,sel:false},{mul:3,sel:false},{mul:2,sel:true},
        {mul:1.5,sel:false},{mul:1.2,sel:false}
    ]);


    const handleClick = (index) =>{
        if(index != actualIndex){
            const aux = menu;

            aux[index].sel = true;
            aux[actualIndex].sel = false;

            setActualIndex(index);
            setActualMul(aux[index].mul);
            setmenu(aux);
        }
    }

    return(
        <Row className='nav'>
            <div style={{marginLeft:`calc((100%/${actualMul}) - 40px)`}} className='indicator'/>
            <Col span={2}/>
            <Col onClick={() => handleClick(0)} className={menu[0].sel ? Selected : Unselect} span={4}>
                <EnvironmentOutlined />
                <div class="tittle">Local</div>                
            </Col>
            <Col onClick={() => handleClick(1)} className={menu[1].sel ? Selected : Unselect} span={4}>
                <HeartOutlined />
                <div class="tittle">Clinica</div>
            </Col>
            <Col onClick={() => handleClick(2)} className={menu[2].sel ? Selected : Unselect} span={4}>
                <HomeOutlined/>
                <div class="tittle">Inicio</div>
            </Col>
            <Col onClick={() => handleClick(3)} className={menu[3].sel ? Selected : Unselect} span={4}>
                <SearchOutlined />
                <div class="tittle">Buscar</div>
            </Col>
            <Col onClick={() => handleClick(4)} className={menu[4].sel ? Selected : Unselect} span={4}>
                <SettingOutlined />
                <div class="tittle">Ajustes</div>
            </Col>
            <Col span={2}/>
        </Row>
    );
}

export default BottomBar