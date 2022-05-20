import {PageHeader,Typography, Layout, Input,Empty, List} from 'antd';
import { useNavigate} from "react-router-dom";
const { Title } = Typography;
const {Search} = Input;
import React, {useState,useEffect} from 'react';
import "../../../Components/TextUtils.css";
import ItemView from "../../../Components/TerapeutaItem";

export default function Terapeutas(){
    let Navigate = useNavigate();
    const [Terapeutas, setTerapeutas] = useState([]);
    const [LoadingList,setLoadingList] = useState(true);
    const [Vacio,setVacio] = useState(false);
    useEffect(() => {
      TeraTasGet()
      TeraTaSearch()
    }, [])

    const TeraTasGet = () => {
      fetch("https://www.mecallapi.com/api/users")
        .then(res => res.json())
        .then(
          (result) => {
            setList(result);
          }
        )
    }

    const setList = (result) =>{
      setLoadingList(false);
      if (result.Empty) {
        setVacio(true);
      }else{
        setVacio(false);
        setTerapeutas(result);
      }
    }

    const TeraTaSearch =(bus)=>{
        setLoadingList(true);
        fetch("https://www.mecallapi.com/api/users?search="+bus)
        .then(res => res.json())
        .then(
          (result)=>{
            setList(result);
          }
        )
    }

    return([
        <PageHeader className="TopTittle" ghost={false} onBack={()=>Navigate(-1)} title={<Title level={2}>Terapeutas</Title>}/>,
        <Layout className='ContentLayout'>
            <Search className='ComunSearch' onSearch={e=>TeraTaSearch(e)} placeholder="Buscar" enterButton size='large' loading={LoadingList} />
            <Empty style={{marginTop:"40px", display:Vacio ? "":"None"}} description={<Title level={4}>Sin Terapeutas</Title>}/>
            <List style={{marginTop:"40px"}} loading={LoadingList} grid={{ gutter: 16, xs: 1, sm: 1, md: 2,lg: 2,xl: 3,xxl: 3 }}
            dataSource={Terapeutas} renderItem={terap => (
              <ItemView id={terap.id} avatar={terap.avatar} text={terap.fname+" "+terap.lname}/>
            )}/>
        </Layout>
    ])
}