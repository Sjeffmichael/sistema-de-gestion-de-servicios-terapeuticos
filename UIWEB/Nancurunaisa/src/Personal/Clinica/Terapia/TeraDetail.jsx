import {PageHeader,Typography, Layout, Form, message, Menu, Button, InputNumber, Input, Divider, Space} from 'antd';
import { useLocation, useNavigate, useParams} from "react-router-dom";
const { Title } = Typography;
import React, {useState,useEffect} from 'react';
import "../../../Utils/TextUtils.css";
import { getaction, TerataFormActionProvider } from '../../../Utils/ActionsProviders';
import { CreateTera, DeleteTera, GetByIdTera, UpdateTera } from '../../../Utils/FetchingInfo';
import { BlockRead, ButtonSubmit, FormAvName, FormPageHeader, sectionStyle } from '../../../Utils/TextUtils';
import { NIOConvUSD, RateUSDNIO, USDConvNIO } from '../../../Utils/Calwulator';


export default function TeraDetail(){
    let Navigate = useNavigate();
    const local = useLocation();/* What is my url */
    const ActionsProvider = new TerataFormActionProvider(getaction(local.pathname));/*Actions crud*/
    const {idTE} = useParams(); /* Params react Router fron now what is the id to want a action */

    const [Loading,setLoading] = useState(idTE==null? false:true);/*Fetching terapeuta info */
    const [isLoading,setloading]= useState(false);/*For Add teratas */
    const [form] = Form.useForm();

    const [Terapia,setTerapia] = useState([]);/* All terapeuta info after fetching */

    const [PSC,setPSC] = useState(0);
    const [PSD,setPSD] = useState(NIOConvUSD(PSC));
    const [PDC,setPDC] = useState(0);
    const [PDD,setPDD] = useState(NIOConvUSD(PDC));

    /* * * * * * * * * * * * * * * * * * *  */
    /*This Functions are Only in Action UPDATE */
    /* * * * * * * * * * * * * * * * * * *  */
    if (!ActionsProvider.isAdd) {
        useEffect(() => {TeraGet()},[])
    }
        
    const TeraGet = () =>{
        GetByIdTera(idTE).then((result)=>{
            if (result["status"]==="ok") {
                setLoading(false);
                setTerapia(result.attraction);

                setPSC(parseFloat(Number(result.attraction.latitude).toFixed(2)));
                setPDC(parseFloat(Number(result.attraction.longitude).toFixed(2)));

                setPSD(NIOConvUSD(parseFloat(result.attraction.latitude)));
                setPDD(NIOConvUSD(parseFloat(result.attraction.longitude)));

                form.resetFields();
            }else{
                message.error("Hubo un error",2);
                setloading(false);
                Navigate(-1);
            }
        })
    }

    const onFinish=()=>{
        setloading(true);
        if (ActionsProvider.isAdd) {
            var data = {
                "name": form.getFieldValue("Nombre"),
                "detail": "form.getFieldValue(",
                "coverimage": "https://source.unsplash.com/random/800x600",
                "latitude": PSC,
                "longitude": PDC}
                CreateTera(data).then((result)=>{
            if (result['status'] === 'ok') {
                message.success("Terapia Añadida",1).then(()=>{
                setloading(false);
                Navigate(-1);
                })
            }else{message.error("No se pudo añadir",2);setloading(false)}
            })
        }else{
            var data = {'id':idTE,"name": form.getFieldValue("Nombre"),"latitude": PSC,"longitude": PDC}
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
            initialValues={{Nombre:Terapia.name}} 
            form={form} size='Default' style={{marginTop:"25px",maxWidth:"600px",width:"100%"}}>
                
                <div style={sectionStyle}>
                    <Title level={4}>Descripción</Title>
                    <Form.Item name="Nombre" label="Nombre:" rules={[{
                        required:true,message:"¡Introduzca el Nombre!"}]}>
                        <Input type="text" maxLength={30} placeholder='Nombre'/>
                    </Form.Item>
                    <Divider/>
                </div>

                <div style={{float:"right",backgroundColor:"rgb(89,32,133)",borderRadius:"25px",padding:"5px",marginTop:"5px"}}>
                    <Typography.Text style={{color:"white"}}>{"1$ = C$"+RateUSDNIO}</Typography.Text>
                </div>
                <div style={sectionStyle}>
                    <Title level={4}>Detalles</Title><div>

                    <div style={{width:"100%"}}> Precio en Sucursal</div>
                    <InputNumber required prefix="C$" size='large' type="number" value={PSC}
                    onChange={(value)=>{setPSC(value);setPSD(NIOConvUSD(value))}}
                    maxLength={5} min={1} max={10000} placeholder='Córdobas' style={{width:"50%"}}/>
                    <InputNumber prefix="$" size='large' type="number"value={PSD}
                        onChange={(value)=>{setPSD(value);setPSC(USDConvNIO(value))}}
                        maxLength={5} min={0.1} max={10000} placeholder='Dólares' style={{width:"50%"}}/>  
                    </div>

                    <Divider/><div>
                    <div style={{width:"100%"}}> Precio a Domicilio</div>
                    <InputNumber required prefix="C$" size='large' type="number" value={PDC}
                    onChange={(value)=>{setPDC(value);setPDD(NIOConvUSD(value))}}
                    maxLength={5} min={1} max={10000} placeholder='Córdobas' style={{width:"50%"}}/>
                    <InputNumber prefix="$" size='large' type="number"value={PDD}
                        onChange={(value)=>{setPDD(value);setPDC(USDConvNIO(value))}}
                        maxLength={5} min={0.1} max={10000} placeholder='Dólares' style={{width:"50%"}}/>  
                    </div>
                                  
                </div>

                <ButtonSubmit ActionProv={ActionsProvider} isLoading={isLoading}/>
            </Form>
        </Layout>
    </div>)
}