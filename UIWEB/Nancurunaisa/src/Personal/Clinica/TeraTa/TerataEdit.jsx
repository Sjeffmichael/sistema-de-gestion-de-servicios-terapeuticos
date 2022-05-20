import {Button,Input,Form,DatePicker,InputNumber} from 'antd';
import React, {useState,useEffect} from 'react';

export default function EditTerata(props){
  const [Terapeuta,setTera] = useState(props.tera);
  const [form] = Form.useForm()
  useEffect(() =>
    form.resetFields(), [props.initialValues])

    return(
        <Form initialValues={{Nombres:Terapeuta.lname}} form={form} size='large' style={{width:"350px"}}>
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
            <Form.Item name="FechaNac" rules={[{
              required:true,
              message:"¡Introduzca la fecha de Nacimiento!"}]}>
              <DatePicker placeholder='Mes y Año' picker="month"/>
              <InputNumber min={1} max={31} defaultValue={1}/>
            </Form.Item>
          </Form>
    )
}