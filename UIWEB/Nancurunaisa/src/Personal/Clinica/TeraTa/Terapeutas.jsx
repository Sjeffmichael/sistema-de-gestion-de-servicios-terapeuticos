import {PageHeader,Typography, Layout, Input, List, Pagination} from 'antd';/*osiris */
import { useNavigate} from "react-router-dom";
import { GetByPagTeraTa, SearchTeraTa } from '../../../Utils/FetchingInfo';
const { Title } = Typography;
const {Search} = Input;
import React, {useState,useEffect} from 'react';
import "../../../Utils/TextUtils.css";
import ItemView from "../../../Components/Items/TerapeutaItem";
import Searchbar from '../../../Components/SearchBar';
import { PlusOutlined } from '@ant-design/icons';
import { FormActions } from '../../../Utils/ActionsProviders';
import { getFirstWord } from '../../../Utils/TextUtils';

export default function Terapeutas(){
    let Navigate = useNavigate();
    const [Terapeutas, setTerapeutas] = useState([]);
    const [LoadingList,setLoadingList] = useState(true);
    const perPageDefault = 5;
    const [totalItems,setTotalItems] = useState(0);

    useEffect(() => {
      TeraTasGet(1)
    }, [])

    const TeraTasGet = (Page) => {
      GetByPagTeraTa(Page,perPageDefault).then((result) => {
        setTotalItems(result.total);
        setList(result.data);
        }
      )
    }

    const setList = (result) =>{
      setTerapeutas(result);
      setLoadingList(false);
    }

    const TeraTaSearch =(bus)=>{
        setLoadingList(true);
        SearchTeraTa(bus)
        .then((result)=>{
            setList(result);
          }
        )
    }

    const onClikTeraTa =(id)=>{
      //localStorage.setItem('IdTeraTaDetail', id);
      if(true/*Range for edit*/){
        Navigate("/Personal/Clinica/Terapeuta/"+FormActions.Update+"/"+id);
      }else{/*Range for ReadOnly */
        Navigate("/Personal/Clinica/Terapeuta/"+FormActions.Read+"/"+id);
      }
    }
    
    const changePage=(Page)=>{
      setLoadingList(true)
      TeraTasGet(Page);
    }

    const onClickAddTerata=()=>{
      Navigate("/Personal/Clinica/Terapeuta/"+FormActions.Add);
    }

    return(
      <Layout>
        <PageHeader className="TopTittle" ghost={false} onBack={()=>Navigate(-1)} title={<Title level={3}>Terapeutas</Title>}/>
        <button className='BottomRoundButton' onClick={()=>{onClickAddTerata()}}><PlusOutlined/></button>
        <Layout className='ContentLayout'>
          <Searchbar onSearch={(value)=>{TeraTaSearch(value)}} loading={LoadingList}/>
          <Pagination onChange={(page)=>changePage(page)} defaultPageSize={perPageDefault} total={totalItems} style={{marginTop:"20px"}}/>
            <List style={{marginTop:"40px"}} loading={LoadingList} grid={{ gutter: 16, xs: 1, sm: 1, md: 2,lg: 2,xl: 3,xxl: 3 }}
            dataSource={Terapeutas} renderItem={terap => (
              <ItemView id={terap.id} avatar={terap.avatar} text={getFirstWord(terap.fname)+" "+getFirstWord(terap.lname)} onClick={(id)=>{onClikTeraTa(id)}}/>
            )}/>
        </Layout>
      </Layout>)
}