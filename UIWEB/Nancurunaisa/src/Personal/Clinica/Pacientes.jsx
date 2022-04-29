import {PageHeader,Typography, Layout} from 'antd';
import { useNavigate} from "react-router-dom";
const { Title } = Typography;
import React from 'react';
import "../../Components/TextUtils.css";

export default function Pacientes(){
    let Navigate = useNavigate();
    return([
        <PageHeader className="TopTittle" ghost={false} onBack={()=>Navigate(-1)} title={<Title level={2}>Pacientes</Title>}/>,
        <Layout>
            <div>Fumo?</div>
        </Layout>
    ])
}