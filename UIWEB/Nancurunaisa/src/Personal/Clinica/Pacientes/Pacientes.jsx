import {PageHeader,Typography, Layout, Pagination, List} from 'antd';
import { useNavigate} from "react-router-dom";
const { Title } = Typography;
import React, {useState,useEffect} from 'react';
import "../../../Utils/TextUtils.css";
import { PlusOutlined } from '@ant-design/icons';
import ItemView from '../../../Components/Items/TerapeutaItem';
import { getFirstWord } from '../../../Utils/TextUtils';
import Searchbar from '../../../Components/SearchBar';
import { GetByPagPacS, SearchPacS } from '../../../Utils/FetchingInfo';
import { FormActions } from '../../../Utils/ActionsProviders';

export default function Pacientes(props){
    let Navigate = useNavigate();/*Go back */
    const [PacS, setPacS] = useState([]);
    const perPageDefault = 5;
    const [totalItems,setTotalItems] = useState(0);
    const [LoadingList,setLoadingList] = useState(true);
    const isPicker = props.picker==true? true:false
    const grid = isPicker? {}:{ gutter: 16, xs: 1, sm: 1, md: 2,lg: 2,xl: 3,xxl: 3 }
    useEffect(() => {
        getPacS(1)
      }, [])

    const setList = (result) =>{
        setPacS(result);
        setLoadingList(false);
    }

    const getPacS=(Page)=>{
        GetByPagPacS(Page,perPageDefault)
        .then((result)=>{
            setTotalItems(result.total);
            setList(result.data);})
    }

    const PacSSearch =(bus)=>{
        setLoadingList(true);
        SearchPacS(bus)
        .then((result)=>{
            setList(result);
          }
        )
    }

    const changePage=(Page)=>{
        setLoadingList(true)
        getPacS(Page);
    }

    const onclick=(id,name)=>{
        if (isPicker) {
            if(typeof props.onClick === "function"){
                props.onClick(id,name);
            }
        }else{
            if(true/*Range for edit*/){
                Navigate("/Personal/Clinica/Paciente/"+FormActions.Update+"/"+id);
            }else{/*Range for ReadOnly */
                Navigate("/Personal/Clinica/Paciente/"+FormActions.Read+"/"+id);
            }
        }
    }

    const onBack=()=>{
        if(isPicker){
            if (typeof props.onBack === "function") {
                props.onBack();
            }
        }else{
            Navigate(-1)
        }
    }

    const onClickAddPacs=()=>{
        Navigate("/Personal/Clinica/Paciente/"+FormActions.Add);
    }

    return(<Layout>
        <PageHeader className="TopTittle" ghost={false} onBack={()=>{onBack()}} title={<Title level={2}>Pacientes</Title>}/>
        <button className='BottomRoundButton' onClick={()=>{onClickAddPacs()}} style={{display:isPicker?"none":""}}><PlusOutlined/></button>
        <Layout className='ContentLayout'>
            <Searchbar onSearch={(value)=>{PacSSearch(value)}} loading={LoadingList}/>
            <Pagination onChange={(page)=>changePage(page)} defaultPageSize={perPageDefault} total={totalItems} style={{marginTop:"20px"}}/>
            <List style={{marginTop:"40px"}} loading={LoadingList} grid={grid}
            dataSource={PacS} renderItem={pacS => (
                <ItemView id={pacS.id} avatar={pacS.avatar} text={getFirstWord(pacS.fname)+" "+getFirstWord(pacS.lname)} onClick={(id)=>{onclick(id)}}/>
            )}/>
        </Layout>
    </Layout>)
}