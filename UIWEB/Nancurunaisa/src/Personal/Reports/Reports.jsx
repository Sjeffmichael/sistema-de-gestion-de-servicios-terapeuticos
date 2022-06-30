import React from 'react';
import { Button, Layout, Typography } from 'antd';
const { Title } = Typography;

export default function ReportsMenu(){
    return(<div>
        <div className="BackMenu"/>
        <Title level={2} style={{marginTop:"20px",marginLeft:"20px",color:"white"}}>Reportes</Title>

        <Layout className='ContentLayout' style={{borderTopLeftRadius:"50px",borderTopRightRadius:"50px",backgroundColor:"white"}}>
            <Button type="primary" style={{margin:"20px"}}>Sucursales y ventas</Button>

        </Layout>
    </div>)
}