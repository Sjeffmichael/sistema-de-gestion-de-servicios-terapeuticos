import React from 'react';
import { Layout, Typography,Avatar, Menu, Dropdown, PageHeader, Button } from 'antd';
import Logout from "../../Components/LogOutButton"
import "../../Utils/TextUtils.css"
import { MoreOutlined } from '@ant-design/icons';

const { Title } = Typography;

function Ajustes(){
    const user = JSON.parse(localStorage.getItem('user'));

    return(
        <Layout>
            <PageHeader ghost={false} title={<Title level={3}>Configuración</Title>}/>
            <Layout className='ContentLayout'>
                <div><Avatar src={user.avatar}/>{user.username}</div>
                <Logout/>
            </Layout>
        </Layout>
        )
}
export default Ajustes