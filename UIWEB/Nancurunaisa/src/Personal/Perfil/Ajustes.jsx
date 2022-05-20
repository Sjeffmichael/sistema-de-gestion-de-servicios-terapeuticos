import React from 'react';
import { Layout, Typography,Avatar } from 'antd';
import Logout from "../../Components/LogOutButton"
import "../../Components/TextUtils.css"

const { Title } = Typography;

function Ajustes(){
    const user = JSON.parse(localStorage.getItem('user'));

    return([
    <Layout className='TopTittle'>
        <Title level={2}>Configuración</Title>
    </Layout>,
    <Layout className='ContentLayout'>
        <div>
            <Avatar src={user.avatar}/>
            {user.username}
        </div>
        <Logout/>
    </Layout>
    ])
}
export default Ajustes