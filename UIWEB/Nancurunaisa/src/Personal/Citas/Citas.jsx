import React from 'react';
import { Layout, Typography,Avatar,Row,Col } from 'antd';
import "../../Utils/TextUtils.css";
import {ContainerFilled, SmileFilled,MedicineBoxFilled,HeartFilled, EnvironmentFilled, PlusOutlined} from "@ant-design/icons";
import { Link } from 'react-router-dom';
const { Title } = Typography;

function Citas(){
    return(<div>
        <div className="BackMenu"/>
        <Title level={2} style={{marginTop:"20px",marginLeft:"20px",color:"white"}}>Citas</Title>
        <button className='BottomRoundButton' onClick={()=>{}}><PlusOutlined/></button>

        <Layout className='ContentLayout' style={{borderTopLeftRadius:"50px",borderTopRightRadius:"50px",backgroundColor:"white"}}>

        </Layout>
    </div>)
}
export default Citas