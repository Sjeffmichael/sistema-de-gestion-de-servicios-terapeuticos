import React, {useState,useEffect} from 'react';
import {FetchTerapeuta} from '../../../Utils/FetchingInfo';
import {Typography, Skeleton,Layout, Avatar,Button,Select,Input,Form,DatePicker,TimePicker} from 'antd';
import "../../../Components/TextUtils.css";
import { useNavigate} from "react-router-dom";
import {
  CommentOutlined
} from '@ant-design/icons';
import WatsButton from '../../../Components/WatsButton';
import Clock from '../../../Components/Clock';
import moment from 'moment';/*What Day is? */

import PhoneInput from 'react-phone-input-2';
import { TimepickerUI } from 'timepicker-ui';
import 'react-phone-input-2/lib/style.css';
import es from 'react-phone-input-2/lang/es.json';
const { Option } = Select;
const { Title } = Typography;

function getAge(dateString) {
  var today = new Date();
  var birthDate = new Date(dateString);
  var age = today.getFullYear() - birthDate.getFullYear();
  var m = today.getMonth() - birthDate.getMonth();
  if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
  }
  return age;
}

export default function TerapeutaDetail(){
    const [Loading,setLoading] = useState(true);
    const [LocalLoad,setLocalLoad] = useState(true);
    const [idTeraTa] = useState(localStorage.getItem('IdTeraTaDetail'));
    const [Terapeuta,setTerapeuta] = useState([]);
    const [Countries,setCountries] = useState([]);
    const [Collapse,setCollapse] = useState(false);
    const [form] = Form.useForm()
    const sectionStyle = {border:"2px solid purple", marginTop:"15px",boxShadow:"2px 2px 12px #c5c5c5",backgroundColor:"white",borderRadius:"10px",padding:"5px"};
    const Resultado = Countries.map(Country => <Option key={Country.id}>{Country.name}</Option>)
    let Navigate = useNavigate();
    useEffect(() => {
        TeraTaGet()
      }, [])

      window.onscroll = function() {scrollFunction()};
      function scrollFunction() {
        if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
          setCollapse(true);
        } else {
          setCollapse(false);
        }
      }
    const TeraTaGet = () =>{
      FetchTerapeuta(1,idTeraTa).then((result)=>{
        setLoading(false);
        setLocalLoad(false);
        setTerapeuta(result.user);
        form.resetFields();
          }
        )
    }

    return([
      <Skeleton active={Loading} style={{display:Loading ? "":"None"}}/>,
      <div id="header" className={Collapse ? "CollapsibleHeaderOn":"CollapsibleHeaderOff"} style={{display:Loading ? "None":""}}>
        <Avatar src={Terapeuta.avatar} style={{boxShadow:Collapse?"":"0px 0px 20px #fff",height:Collapse ? "40px":"100px",width:"auto", transition:"all 0.3s ease-in"}}/>
        <Title style={{marginTop:"10px",color:"white",paddingLeft:Collapse ? "10px":"0px"}} level={3}>{Terapeuta.fname+" "+Terapeuta.lname}</Title>
        <div style={{display:Collapse ? "none":"flex",color:"white",flexDirection:"column",alignItems:"center",minWidth:"200px"}}>
          <WatsButton number=""/>
        </div>
      </div>,
      <div style={{marginTop:"280px",display:Loading ? "None":""}}/>,
      <Layout className='ContentLayout' style={{marginTop:"280px",display:Loading ? "None":""}}>
        <Clock entrada="05:10:10" salida="20:00:00" sucursal="Rafaela Herrera"/>

        <Form initialValues={{Nombres:Terapeuta.fname,Apellidos:Terapeuta.lname,Phone:"50557533230",Mail:Terapeuta.username}} 
        form={form} size='Default' style={{marginTop:"25px",maxWidth:"600px",width:"100%"}}>
          <div style={sectionStyle}>
            <Title level={4}>Información Personal</Title>
            <Form.Item name="Nombres" label="Nombres" rules={[{
              required:true,
              message:"¡Introduzca los nombres!"}]}>
              <Input placeholder='Nombres'/>
            </Form.Item>
            <Form.Item name="Apellidos" label="Apellidos" rules={[{
              required:true,
              message:"¡Introduzca los apellidos!"}]}>
              <Input placeholder='Apellidos'/>
            </Form.Item>
            <Form.Item label="Fecha de nacimiento" name="Birth" rules={[{
              required:true,
              message:"¡Introduzca la fecha de Nacimiento!"}]}>
              <DatePicker inputReadOnly="true" picker="date" defaultValue={moment('2000/01/01', "YYYY/MM/DD")}/>
            </Form.Item>
            <Form.Item label="Género" name="Gender" rules={[{required:true,message:"¡Introduzca el género!"}]}>
              <Select defaultValue={"Masculino"}>
                <Option value="M">Masculino</Option>
                <Option value="F">Femenino</Option>
                <Option value="O">Otro</Option>
              </Select>
            </Form.Item>
            </div>

            <div style={sectionStyle}>
              <Title level={4}>Información de Contacto</Title>
              <Form.Item name="Phone" label="Numero Telefónico" rules={[{
                required: true, message: 'Introduzca el número Celular!'}]}>
                  <PhoneInput country={"ni"}/>
              </Form.Item>
              <Form.Item name="Mail" label="Correo Electrónico"
              rules={[{type: 'email',message: '¡No es un correo Válido!',},{required:true,message:"¡Introduzca el Correo!"}]}>
                <Input type="email"></Input>
              </Form.Item>
            </div>

            <div style={sectionStyle}>
              <Title level={4}>Información Laboral</Title>
              <Form.Item name="Horario" >
                <input class="timepicker-ui-input" value="12:00 AM"/>
              </Form.Item>
            </div>
          </Form>
      </Layout>
      
    ])
}