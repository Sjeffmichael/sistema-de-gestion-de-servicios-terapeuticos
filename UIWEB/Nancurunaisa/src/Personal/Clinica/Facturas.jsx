import {PageHeader,Typography, Layout} from 'antd';
import { useNavigate} from "react-router-dom";
const { Title } = Typography;
import React from 'react';
import "../../Components/TextUtils.css";

export default function Facturas(){
    let Navigate = useNavigate();
    return([
        <PageHeader className="TopTittle" ghost={false} onBack={()=>Navigate(-1)} title={<Title level={2}>Facturas</Title>}/>,
        <Layout>
            <div>Pienso?</div>
        </Layout>
    ])
}