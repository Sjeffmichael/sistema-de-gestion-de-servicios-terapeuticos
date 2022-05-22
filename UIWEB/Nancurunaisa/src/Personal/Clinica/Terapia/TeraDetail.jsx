import {PageHeader,Typography, Layout, Form, message, Menu, Button, InputNumber, Input, Divider} from 'antd';
import { useLocation, useNavigate, useParams} from "react-router-dom";
const { Title } = Typography;
import React, {useState,useEffect} from 'react';
import "../../../Utils/TextUtils.css";
import { getaction, TerataFormActionProvider } from '../../../Utils/ActionsProviders';
import { CreateTera, DeleteTera, GetByIdTera, UpdateTera } from '../../../Utils/FetchingInfo';
import { BlockRead, ButtonSubmit, FormAvName, FormPageHeader, sectionStyle } from '../../../Utils/TextUtils';

function convert(currency1, currency2, value) {
    const host = "api.frankfurter.app";
    fetch(`https://${host}/latest?amount=${value}&from=${currency1}&to=${currency2}`)
      .then((val) => val.json())
      .then((val) => {
        console.log(Object.values(val.rates)[0]);
        output.value = Object.values(val.rates)[0];
      });
  }

export default function TeraDetail(){
    let Navigate = useNavigate();
    const local = useLocation();/* What is my url */
    const ActionsProvider = new TerataFormActionProvider(getaction(local.pathname));/*Actions crud*/
    const {idTE} = useParams(); /* Params react Router fron now what is the id to want a action */

    const [Loading,setLoading] = useState(idTE==null? false:true);/*Fetching terapeuta info */
    const [isLoading,setloading]= useState(false);/*For Add teratas */
    const [form] = Form.useForm();

    const [Terapia,setTerapia] = useState([]);/* All terapeuta info after fetching */

    /* * * * * * * * * * * * * * * * * * *  */
    /*This Functions are Only in Action UPDATE */
    /* * * * * * * * * * * * * * * * * * *  */
    if (!ActionsProvider.isAdd) {
        useEffect(() => {TeraGet()},[])
    }
        
    const TeraGet = () =>{
        GetByIdTera(idTE).then((result)=>{
            setLoading(false);
            setTerapia(result.attraction);
            form.resetFields();
        })
    }

    const onFinish=()=>{
        setloading(true);
        if (ActionsProvider.isAdd) {
            var data = {
                "name": form.getFieldValue("Nombre"),
                "detail": form.getFieldValue("Dir"),
                "coverimage": "https://source.unsplash.com/random/800x600",
                "latitude": 13.9642507,
                "longitude": 100.5866942}
                CreateTera(data).then((result)=>{
            if (result['status'] === 'ok') {
                message.success("Terapia Añadida",1).then(()=>{
                setloading(false);
                Navigate(-1);
                })
            }else{message.error("No se pudo añadir",2);setloading(false)}
            })
        }else{
            var data = {'id':idSU,"name": form.getFieldValue("Nombre")}
            UpdateTera(data).then((result)=>{
                if (result['status'] === 'ok'){
                  message.success("Terapia Modificada",1).then(()=>{
                    setloading(false);
                    Navigate(-1);
                  })
                }else{message.error("No se pudo Modificar",2);setloading(false);}
              })
        }
    }

    const deleteTera =()=>{
        var data = {'id':idTE}
            DeleteTera(data).then((result)=>{
            if (result['status'] === 'ok'){
                message.success("Terapia Eliminada",1).then(()=>{
                setloading(false);
                Navigate(-1);
                })
            }else{message.error("No se pudo Eliminar",2);setloading(false);}
            })
    }

    const userMenu = (
    <Menu style={{width:"200px",borderRadius:"20px"}}>
        <Menu.Item key="1">Item 1</Menu.Item>
        <Menu.Item key="2">Item 2</Menu.Item>
        <Menu.Divider />
        <Menu.Item key="4">
        <Button type='primary' onClick={()=>{deleteTera()}} danger 
        style={{width:"100%",borderBottomLeftRadius:"20px",borderBottomRightRadius:"20px"}}>Eliminar</Button>
        </Menu.Item>
    </Menu>
    );

    return(<div>
        <BlockRead Show={ActionsProvider.isRead}/>
        <FormPageHeader ActionProv={ActionsProvider} Text="Terapia" menu={userMenu}/>
        <div className='BackImageCollapsible' style={{display:ActionsProvider.isAdd? "none":""}}/>
        <FormAvName ActionProv={ActionsProvider} Loading={Loading} Avatar={Terapia.coverimage} Text={Terapia.name}/>

        <Layout className='ContentLayout' style={{display:Loading ? "None":""}}>
            <Form onFinish={()=>{onFinish()}} onFinishFailed={(e)=>{form.scrollToField(e.errorFields[0].name)}} 
            initialValues={{Nombre:Terapia.name, PS:10,PD:13}} 
            form={form} size='Default' style={{marginTop:"25px",maxWidth:"600px",width:"100%"}}>
                
                <div style={sectionStyle}>
                    <Title level={4}>Descripción</Title>
                    <Form.Item name="Nombre" label="Nombre:" rules={[{
                        required:true,message:"¡Introduzca el Nombre!"}]}>
                        <Input type="text" maxLength={30} placeholder='Nombre'/>
                    </Form.Item>
                    <Divider/>
                </div>

                <div style={sectionStyle}>
                    <Title level={4}>Detalles</Title>
                    <Form.Item name="PS" label="Precio en Sucursal:" rules={[{
                        required:true,message:"¡Introduzca el Precio!"}]}>
                        <InputNumber onChange={(value)=>{fetchConvertCordobaToDollar(value)}} type="number" maxLength={5} min={1} max={10000} placeholder='Precio'/>
                    </Form.Item>
                    <Divider/>
                    <Form.Item name="PD" label="Precio a Domicilio:" rules={[{
                        required:true,message:"¡Introduzca el Precio!"}]}>
                        <InputNumber type="number" maxLength={5} min={1} max={10000} placeholder='Precio'/>
                    </Form.Item>
                    <Divider/>
                    <Form.Item name="Time" label="Tiempo Aproximado:" rules={[{
                        required:true,message:"¡Introduzca el Tiempo!"}]}>
                        <Input type="time"  maxLength={4} placeholder='Precio'/>
                    </Form.Item>                    
                </div>

                <ButtonSubmit ActionProv={ActionsProvider} isLoading={isLoading}/>
            </Form>
        </Layout>
    </div>)
}