import { Layout, Typography } from "antd";
const { Title } = Typography;

export default function SucRep(){
    return(<div>
        <Title level={2} style={{marginTop:"20px",marginLeft:"20px",color:"white"}}>Reportes</Title>

        <Layout className='ContentLayout' style={{borderTopLeftRadius:"50px",borderTopRightRadius:"50px",backgroundColor:"white"}}>
            <div style={{padding:"20px"}}>
                <Title level={3} style={{marginTop:"20px",marginLeft:"20px",color:"black"}}>Sucursales y ventas</Title>
            </div>

        </Layout>
    </div>)
}