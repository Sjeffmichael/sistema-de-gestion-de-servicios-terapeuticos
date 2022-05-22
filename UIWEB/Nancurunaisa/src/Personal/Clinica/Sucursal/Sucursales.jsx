import {PageHeader,Typography, Layout, Input,Empty, List, Pagination} from 'antd';
import { useNavigate} from "react-router-dom";
import { GetByPagSucur, SearchSucur } from '../../../Utils/FetchingInfo';
import React, {useState,useEffect} from 'react';
import ItemView from "../../../Components/Items/TerapeutaItem";
import Searchbar from "../../../Components/SearchBar";
import "../../../Utils/TextUtils.css";
import { PlusOutlined } from '@ant-design/icons';
import { FormActions } from '../../../Utils/ActionsProviders';

const { Title } = Typography;

export default function Sucursales(props){
    let Navigate = useNavigate();/*Go back */
    const [Sucurs, setSucurs] = useState([]);
    const perPageDefault = 5;
    const [totalItems,setTotalItems] = useState(0);
    const [LoadingList,setLoadingList] = useState(true);
    const isPicker = props.picker==true? true:false
    const grid = isPicker? {}:{ gutter: 16, xs: 1, sm: 1, md: 2,lg: 2,xl: 3,xxl: 3 }
    useEffect(() => {
        getSucurs(1)
      }, [])

    const setList = (result) =>{
        setSucurs(result);
        setLoadingList(false);
    }

    const getSucurs=(Page)=>{
        GetByPagSucur(Page,perPageDefault)
        .then((result)=>{
            setTotalItems(result.total);
            setList(result.data);})
    }

    const SucurSearch =(bus)=>{
        setLoadingList(true);
        SearchSucur(bus)
        .then((result)=>{
            setList(result);
          }
        )
    }

    const changePage=(Page)=>{
        setLoadingList(true)
        getSucurs(Page);
    }

    const onclick=(id,name)=>{
        if (isPicker) {
            if(typeof props.onClick === "function"){
                props.onClick(id,name);
            }
        }else{
            if(true/*Range for edit*/){
                Navigate("/Personal/Clinica/Sucursal/"+FormActions.Update+"/"+id);
            }else{/*Range for ReadOnly */
                Navigate("/Personal/Clinica/Sucursal/"+FormActions.Read+"/"+id);
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

    const onClickAddSucur=()=>{
        Navigate("/Personal/Clinica/Sucursal/"+FormActions.Add);
    }

    return (
        <Layout>
            <PageHeader className="TopTittle" ghost={false} onBack={()=>{onBack()}} title={<Title level={2}>Sucursales</Title>}/>
            <button className='BottomRoundButton' onClick={()=>{onClickAddSucur()}} style={{display:isPicker?"none":""}}><PlusOutlined/></button>
            <Layout className='ContentLayout'>
                <Searchbar onSearch={(value)=>{SucurSearch(value)}} loading={LoadingList}/>
                <Pagination onChange={(page)=>changePage(page)} defaultPageSize={perPageDefault} total={totalItems} style={{marginTop:"20px"}}/>
                <List style={{marginTop:"40px"}} loading={LoadingList} grid={grid}
                dataSource={Sucurs} renderItem={sucur => (
                    <ItemView id={sucur.id} avatar={sucur.coverimage} text={sucur.name} onClick={(id,name)=>{onclick(id,name)}}/>
                )}/>
            </Layout>
                
        </Layout>
    )
}