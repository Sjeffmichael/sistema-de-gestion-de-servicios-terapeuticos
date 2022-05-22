import { Button, Divider, Form, Input, Layout, Menu, message, Space, Typography } from "antd";
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
import React, {useState,useEffect} from 'react';
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { TerataFormActionProvider, getaction } from "../../../Utils/ActionsProviders";
import { CreateSucur, DeleteSucur, GetByIdSucur, UpdateSucursal } from "../../../Utils/FetchingInfo";
import { BlockRead, ButtonSubmit, FormAvName, FormPageHeader, sectionStyle } from "../../../Utils/TextUtils";

const { TextArea } = Input;
const {Title} = Typography;

export default function SucurDetail(){
    let Navigate = useNavigate();
    const local = useLocation();/* What is my url */
    const ActionsProvider = new TerataFormActionProvider(getaction(local.pathname));/*Actions crud*/
    const {idSU} = useParams(); /* Params react Router fron now what is the id to want a action */

    const [Loading,setLoading] = useState(idSU==null? false:true);/*Fetching terapeuta info */
    const [isLoading,setloading]= useState(false);/*For Add teratas */
    const [form] = Form.useForm();

    const [Sucursal,setSucursal] = useState([]);/* All terapeuta info after fetching */
    const Cuartos = ["Cuarto1"]

    const formItemLayout = {
        labelCol: {
          xs: { span: 24 },
          sm: { span: 4 },
        },
        wrapperCol: {
          xs: { span: 24 },
          sm: { span: 20 },
        },
      };
      const formItemLayoutWithOutLabel = {
        wrapperCol: {
          xs: { span: 24, offset: 0 },
          sm: { span: 20, offset: 4 },
        },
      };

    /* * * * * * * * * * * * * * * * * * *  */
    /*This Functions are Only in Action UPDATE */
    /* * * * * * * * * * * * * * * * * * *  */
    if (!ActionsProvider.isAdd) {
        useEffect(() => {SucurGet()},[])
    }
        
    const SucurGet = () =>{
        GetByIdSucur(idSU).then((result)=>{
            setLoading(false);
            setSucursal(result.attraction);
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
                CreateSucur(data).then((result)=>{
            if (result['status'] === 'ok') {
                message.success("Sucursal Añadida",1).then(()=>{
                setloading(false);
                Navigate(-1);
                })
            }else{message.error("No se pudo añadir",2);setloading(false)}
            })
        }else{
            var data = {'id':idSU,"name": form.getFieldValue("Nombre")}
            UpdateSucursal(data).then((result)=>{
                if (result['status'] === 'ok'){
                  message.success("Sucursal Modificada",1).then(()=>{
                    setloading(false);
                    Navigate(-1);
                  })
                }else{message.error("No se pudo Modificar",2);setloading(false);}
              })
        }
    }

    const deleteSucur =()=>{
        var data = {'id':idSU}
            DeleteSucur(data).then((result)=>{
            if (result['status'] === 'ok'){
                message.success("Sucursal Eliminada",1).then(()=>{
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
        <Menu.Item key="3">{Sucursal.Active == true? "Desactivar":"Activar"}</Menu.Item>
        <Menu.Divider />
        <Menu.Item key="4">
        <Button type='primary' onClick={()=>{deleteSucur()}} danger 
        style={{width:"100%",borderBottomLeftRadius:"20px",borderBottomRightRadius:"20px"}}>Eliminar</Button>
        </Menu.Item>
    </Menu>
    );

    return (<div>
        <BlockRead Show={ActionsProvider.isRead}/>
        <FormPageHeader ActionProv={ActionsProvider} Text="Sucursal" menu={userMenu}/>
        <div className='BackImageCollapsible' style={{display:ActionsProvider.isAdd? "none":""}}/>
        <FormAvName ActionProv={ActionsProvider} Loading={Loading} Avatar={Sucursal.coverimage} Text={Sucursal.name}/>

        <Layout className='ContentLayout' style={{display:Loading ? "None":""}}>
            <Form onFinish={()=>{onFinish()}} onFinishFailed={(e)=>{form.scrollToField(e.errorFields[0].name)}} 
            initialValues={{Nombre:Sucursal.name, Dir:Sucursal.detail, Cuartos:Cuartos}} 
            form={form} size='Default' style={{marginTop:"25px",maxWidth:"600px",width:"100%"}}>

                <div style={sectionStyle}>
                    <Title level={4}>Descripción</Title>
                    <Form.Item name="Nombre" label="Nombre:" rules={[{
                        required:true,message:"¡Introduzca el Nombre!"}]}>
                        <Input type="text" maxLength={30} placeholder='Nombre'/>
                    </Form.Item>
                    <Divider/>
                    <Form.Item name="Dir" label="Dirección:" rules={[{
                        required:true,message:"¡Introduzca la Dirección!"}]}>
                        <TextArea rows={4} maxLength={230} placeholder="Dirección"/>
                    </Form.Item>
                </div>

                <div style={sectionStyle}>
                    <Title level={4}>Cubículo</Title>
                    <Form.List name="Cuartos" rules={[{validator: async (_, names) => {
                        if (!names || names.length < 1) {
                            return Promise.reject(new Error('¡Agregue almenos 1 cubículo!'));}}}]}>
                                
                        {(fields, { add, remove }, { errors }) => (<>{fields.map((field, index) => (
                            <Form.Item {...(index === 0 ? formItemLayout : formItemLayoutWithOutLabel)}
                            label={index === 0 ? 'Cubículo' : ''} required={false} key={field.key}>
                                
                                <Form.Item {...field} validateTrigger={['onChange', 'onBlur']}
                                rules={[{required: true,whitespace: true,message: "¡Introduzca el nombre del cuarto!"}]} noStyle>
                                    <Input placeholder="Nombre del Cubículo" style={{ width: '60%' }} />
                                </Form.Item>
                                {fields.length > 1 ? (<MinusCircleOutlined onClick={() => remove(field.name)}/>) : null}
                            </Form.Item>))}
                            
                            <Form.Item>
                                <Button type="dashed" onClick={() => add()} style={{ width: '60%' }} icon={<PlusOutlined />}>
                                    Añadir Cubículo
                                </Button>
                                <Form.ErrorList errors={errors} />
                            </Form.Item>
                            </>)}
                    </Form.List>
                </div>

                <ButtonSubmit ActionProv={ActionsProvider} isLoading={isLoading}/>

            </Form>
        </Layout>
    </div>)
}