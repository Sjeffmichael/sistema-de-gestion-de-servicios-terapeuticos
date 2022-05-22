import React from 'react';
import { Layout, Typography,Avatar,Row,Col } from 'antd';
import "../../Utils/TextUtils.css";
import {ContainerFilled, SmileFilled,MedicineBoxFilled,HeartFilled, EnvironmentFilled} from "@ant-design/icons";
import { Link } from 'react-router-dom';
const { Title } = Typography;

function Clinica(){
    return(<div>
        <div className="BackMenu"/>
        <Title level={2} style={{marginTop:"20px",marginLeft:"20px",color:"white"}}>Clínica</Title>

        <Layout className='ContentLayout' style={{borderTopLeftRadius:"50px",borderTopRightRadius:"50px",backgroundColor:"white"}}>
            <Link to='/Personal/Clinica/Pacientes'>
                <Row className='Cardview'>
                    <Col className='ColCardTitle' span={18}>
                        <Title level={3}>Pacientes</Title>
                    </Col>
                    <Col className='ColCardIcon' span={4}>
                        <SmileFilled style={{color:"#5a33ae",fontSize:"40px"}}/>
                    </Col> 
                </Row>
            </Link>
            <Link to='/Personal/Clinica/Facturas'>
                <Row className='Cardview'>
                    <Col className='ColCardTitle' span={18}>
                        <Title level={3}>Facturas</Title>
                    </Col>
                    <Col className='ColCardIcon' span={4}>
                        <ContainerFilled style={{color:"#5a33ae",fontSize:"40px"}}/>
                    </Col> 
                </Row>
            </Link>
            <Link to ="/Personal/Clinica/Terapeutas">
                <Row className='Cardview'>
                    <Col className='ColCardTitle' span={18}>
                        <Title level={3}>Terapeutas</Title>
                    </Col>
                    <Col className='ColCardIcon' span={4}>
                        <MedicineBoxFilled style={{color:"#5a33ae",fontSize:"40px"}}/>
                    </Col> 
                </Row>
            </Link>
            <Link to='/Personal/Clinica/Terapias'>
                <Row className='Cardview'>
                    <Col className='ColCardTitle' span={18}>
                        <Title level={3}>Terapias</Title>
                    </Col>
                    <Col className='ColCardIcon' span={4}>
                        <HeartFilled style={{color:"#5a33ae",fontSize:"40px"}}/>
                    </Col> 
                </Row>
            </Link>
            <Link to='/Personal/Clinica/Sucursales'>
                <Row className='Cardview'>
                    <Col className='ColCardTitle' span={18}>
                        <Title level={3}>Sucursales</Title>
                    </Col>
                    <Col className='ColCardIcon' span={4}>
                        <EnvironmentFilled style={{color:"#5a33ae",fontSize:"40px"}}/>
                    </Col> 
                </Row>
            </Link>
        </Layout>
        </div>)
}
export default Clinica