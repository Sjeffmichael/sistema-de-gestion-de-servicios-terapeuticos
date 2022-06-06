import React, {useState,useEffect} from 'react';
import {GetByIdTeraTa, CreateTeraTa, DeleteTeraTa, UpdateTeraTa} from '../../../Utils/FetchingInfo';
import { TerataFormActionProvider,getaction} from '../../../Utils/ActionsProviders';
import {Typography, Skeleton,Layout,Select,Form,Image, Button, Dropdown} from 'antd';
import {Input,DatePicker,Divider, Upload,message,Menu} from 'antd';
import "../../../Utils/TextUtils.css";

import moment from 'moment';/*What Day is? */
import { useNavigate, useLocation, useParams } from 'react-router-dom'
import PickerSucursal from '../../../Components/Picker/Pickers';
import WatsButton from '../../../Components/WatsButton';
import Clock from '../../../Components/Clock';
import PhoneInput from 'react-phone-input-2';
import 'react-phone-input-2/lib/style.css';

import { FormPageHeader, sectionStyle, BlockRead, FormAvName, ValDoubleName, ButtonSubmit } from '../../../Utils/TextUtils';
import ImgCrop from 'antd-img-crop';

const { Title } = Typography;
const { Option } = Select;

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
function beforeUpload(file) {
  const isJpgOrPng = file.type === 'image/jpeg' || file.type === 'image/png';
  if (!isJpgOrPng) {
    message.error('You can only upload JPG/PNG file!');
  }
  const isLt2M = file.size / 1024 / 1024 < 2;
  if (!isLt2M) {
    message.error('Image must smaller than 2MB!');
  }
  return isJpgOrPng && isLt2M;
}

/*Formulario de lectura, Edicion, Adicion */
export default function TerapeutaDetail(){
  let Navigate = useNavigate();
  const local = useLocation();/* What is my url */
  const ActionsProvider = new TerataFormActionProvider(getaction(local.pathname));/*Actions crud*/
  const {idTA} = useParams(); /* Params react Router fron now what is the id to want a action */

  const [Loading,setLoading] = useState(idTA==null? false:true);/*Fetching terapeuta info */
  const [isLoading,setloading]= useState(false);/*For Add teratas */
  var isInModal = false;
  const [form] = Form.useForm();

  const [Terapeuta,setTerapeuta] = useState([]);/* All terapeuta info after fetching */
  const [EntradaHora,setEntradaHora] = useState("09:00 am");
  const [SalidaHora,setSalidaHora]= useState("06:00 pm");
  const [ActSucur,setActSucur] = useState("Rafaela Herrera");

  const changeHorario=(FH,LH)=>{setEntradaHora(FH);setSalidaHora(LH);console.log(LH,FH)}
  const OptionDayFree = [
    <Option key={1} value={1}>Lunes</Option>,
    <Option key={2} value={2}>Martes</Option>,
    <Option key={3} value={3}>Miercoles</Option>,
    <Option key={4} value={4}>Jueves</Option>,
    <Option key={5} value={5}>Viernes</Option>,
    <Option key={6} value={6}>Sabado</Option>,
    <Option key={7} value={7}>Domingo</Option>
]

  /* * * * * * * * * * * * * * * * * * *  */
  /*This Functions are Only in Action UPDATE */
  /* * * * * * * * * * * * * * * * * * *  */

  if (!ActionsProvider.isAdd) {
    useEffect(() => {TeraTaGet()},[])
  }
      
  const TeraTaGet = () =>{
    GetByIdTeraTa(idTA).then((result)=>{
      setLoading(false);
      setTerapeuta(result.user);
      //setEntradaHora();
      //setSalidaHora();
      //setActSucur();
      form.resetFields();
        }
      )
  }

  const deleteTerata =()=>{
    var data = {'id':idTA}
        DeleteTeraTa(data).then((result)=>{
          if (result['status'] === 'ok'){
            message.success("Terapeuta Eliminado",1).then(()=>{
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
        <Menu.Item key="3">{Terapeuta.Active == true? "Desactivar":"Activar"}</Menu.Item>
        <Menu.Divider />
        <Menu.Item key="4">
          <Button type='primary' onClick={()=>{deleteTerata()}} danger 
          style={{width:"100%",borderBottomLeftRadius:"20px",borderBottomRightRadius:"20px"}}>Eliminar</Button>
        </Menu.Item>
      </Menu>
    );

  /* * * * * * * * * * * * * * * * * * *  */
  /*This Functions are Only in Action ADD */
  /* * * * * * * * * * * * * * * * * * *  */
  const onFinish = () =>{
    if(isLoading || isInModal) {return;}
    setloading(true);
    if (ActionsProvider.isAdd) {
      var data = {
      'fname': form.getFieldValue("Nombres"),
      'lname': form.getFieldValue("Apellidos"),
      'username': form.getFieldValue("Nombres")+form.getFieldValue("Apellidos"),
      'email': form.getFieldValue("Mail"),
      'avatar': "https://source.unsplash.com/random/800x600"}
      CreateTeraTa(data).then((result)=>{
      if (result['status'] === 'ok') {
        message.success("Terapeuta Añadido",1).then(()=>{
          setloading(false);
          Navigate(-1);
        })
      }else{message.error("No se pudo añadir",2);setloading(false);}
    })
    }else{
      var data = {'id':idTA,"lname": form.getFieldValue("Apellidos")}
      UpdateTeraTa(data).then((result)=>{
        if (result['status'] === 'ok'){
          message.success("Terapeuta Modificado",1).then(()=>{
            setloading(false);
            Navigate(-1);
          })
        }else{message.error("No se pudo Modificar",2);setloading(false);}
      })
    }
  }

  /*UploadImage */
  const [fileList, setFileList] = useState([{
    uid: '-1',
    name: 'image.png',
    status: 'done',
    url: 'https://zos.alipayobjects.com/rmsportal/jkjgkEfvpUPVyRjUImniVslZfWPnJuuZ.png'
  }]);

  const onChange = ({ fileList: newFileList }) => {
    setFileList(newFileList);
  };

  const onPreview = async file => {
    let src = file.url;
    if (!src) {
      src = await new Promise(resolve => {
        const reader = new FileReader();
        reader.readAsDataURL(file.originFileObj);
        reader.onload = () => resolve(reader.result);
      });
    }
    const image = new Image();
    image.src = src;
    /*const imgWindow = window.open(src);
    imgWindow.document.write(image.outerHTML);*/
  };

  const dummyRequest = ({ file, onSuccess }) => {
    setTimeout(() => {
      onSuccess("ok");
    }, 0);
  };

    return(<div>
      <BlockRead Show={ActionsProvider.isRead}/>
      <FormPageHeader ActionProv={ActionsProvider} Text="Terapeuta" menu={userMenu}/>
      <div className='BackImageCollapsible' style={{display:ActionsProvider.isAdd? "none":""}}/>

      <FormAvName ActionProv={ActionsProvider} Loading={Loading} Avatar={Terapeuta.avatar} Text={Terapeuta.fname+" "+Terapeuta.lname}/>
      
      <Layout className='ContentLayout' style={{display:Loading ? "None":""}}>
        <div style={{zIndex:"6",display:ActionsProvider.isAdd? "none":"flex"}}>
          <WatsButton number="+50581248928"/>
        </div>
        <Clock visible={!ActionsProvider.isAdd} entrada={EntradaHora} salida={SalidaHora} sucursal={ActSucur}/>          
        
        <Form onFinish={()=>{onFinish()}} onFinishFailed={(e)=>{form.scrollToField(e.errorFields[0].name)}} 
        initialValues={{Nombres:Terapeuta.fname, Apellidos:Terapeuta.lname,Phone:"50557533230", 
        HE:'09:00',HS:'18:00',Mail:Terapeuta.email, Gender:"M",Birth:moment("1990/01/01", "YYYY/MM/DD"),FreeDay:[6,7]}} 
        form={form} size='Default' style={{marginTop:"25px",maxWidth:"600px",width:"100%"}}>

          <div style={sectionStyle}>
            <Title level={4}>Información Personal</Title>
            <Form.Item name="Nombres" label="Nombres:" rules={[
              {validator: (_, value) => ValDoubleName(value,"nombres")}]}>
              <Input type="text" maxLength={30} placeholder='Nombres'/>
            </Form.Item>
            <Divider/>
            <Form.Item name="Apellidos" label="Apellidos:" rules={[
              {validator: (_, value) => ValDoubleName(value,"apellidos")}]}>
              <Input placeholder='Apellidos'/>
            </Form.Item>
            <Divider/>
            <Form.Item label="Fecha de nacimiento:" name="Birth" rules={[{
              required:true,message:"¡Introduzca la fecha de Nacimiento!"}]}>
              <DatePicker inputReadOnly={true} picker="date"/>
            </Form.Item>
            <Divider/>
            <Form.Item label="Género:" name="Gender" rules={[{required:true,message:"¡Seleccione el género!"}]}>
              <Select>
                <Option value="M">Masculino</Option>
                <Option value="F">Femenino</Option>
                <Option value="O">Otro</Option>
              </Select>
            </Form.Item>
          </div>
          
        <div style={sectionStyle}>
          <Title level={4}>Información de Contacto</Title>
          <Form.Item name="Phone" label="Numero Telefónico:" rules={[{
            required: true, message: 'Introduzca el número Celular!'}]}>
            <PhoneInput country={"ni"}/>
          </Form.Item>
          <Divider/>
          <Form.Item name="Mail" label="Correo Electrónico:"rules={[{
            type: 'email',message: '¡No es un correo Válido!',},{required:true,message:"¡Introduzca el Correo!"}]}>
            <Input type="email"></Input>
          </Form.Item>
        </div>
          
        <div style={sectionStyle}>
          <Title level={4}>Información Laboral</Title>
          <Form.Item name="HE" label="Horario Entrada">
            <Input type="time" style={{width:"40%"}}/>
          </Form.Item>
          <Form.Item name="HS" label="Horario Salida">
            <Input type="time" style={{width:"40%"}}/>
          </Form.Item>

          <Divider/>
          <Form.Item label="Sucursal:">
            {ActSucur}
            <PickerSucursal onFocus={(sta)=>{isInModal=sta}} onChange={(id,name)=>{setActSucur(name)}}/>
          </Form.Item>
          
          <Divider/>
          <Form.Item label="Dia Libre:" name="FreeDay" rules={[{required:true,message:"¡Seleccione un dia!"}]}>
            <Select mode="multiple" allowClear showSearch={false} style={{ width: '100%' }} placeholder="Dias libre">
              {OptionDayFree}
            </Select>
          </Form.Item>
          </div>

          <div style={sectionStyle}>
            <Title level={4}>Perfil</Title>
            <Form.Item>
              <ImgCrop>
                <Upload action="https://www.mocky.io/v2/5cc8019d300000980a055e76" accept='.png'
                  beforeUpload={beforeUpload} listType="picture-card"
                  fileList={fileList} onChange={onChange} onPreview={onPreview}
                  customRequest={dummyRequest}>
                  {fileList.length < 2 && '+ Upload'}
                </Upload>
              </ImgCrop>
            </Form.Item>
          </div>

          <ButtonSubmit ActionProv={ActionsProvider} isLoading={isLoading}/>
          
        </Form>
      </Layout>
      </div>)
}

/*grid-row: 2 / span 2;
grid-column: 2 / span 2; */