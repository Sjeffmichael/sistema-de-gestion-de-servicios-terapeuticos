import {PageHeader,Typography, Layout, Pagination, List} from 'antd';
import { useNavigate} from "react-router-dom";
const { Title } = Typography;
import React, {useState,useEffect} from 'react';
import "../../../Utils/TextUtils.css";
import { PlusOutlined } from '@ant-design/icons';
import Searchbar from '../../../Components/SearchBar';
import ItemView from "../../../Components/Items/TerapeutaItem";
import { GetByPagTera, SearchTera } from '../../../Utils/FetchingInfo';
import { FormActions } from '../../../Utils/ActionsProviders';

export default function Terapias(props){
    let Navigate = useNavigate();/*Go back */
    const [Teras, setTeras] = useState([]);
    const perPageDefault = 5;
    const [totalItems,setTotalItems] = useState(0);
    const [LoadingList,setLoadingList] = useState(true);
    const isPicker = props.picker==true? true:false;
    const grid = isPicker? {}:{ gutter: 16, xs: 1, sm: 1, md: 2,lg: 2,xl: 3,xxl: 3 };

    useEffect(() => {
        getTeras(1)
      }, [])

    const setList = (result) =>{
        setTeras(result);
        setLoadingList(false);
    }

    const getTeras=(Page)=>{
        GetByPagTera(Page,perPageDefault)
        .then((result)=>{
            setTotalItems(result.total);
            setList(result.data);})
    }

    const TeraSearch =(bus)=>{
        setLoadingList(true);
        SearchTera(bus)
        .then((result)=>{
            setList(result);
          }
        )
    }

    const changePage=(Page)=>{
        setLoadingList(true)
        getTeras(Page);
    }

    const onclick=(id,name)=>{
        if (isPicker) {
            if(typeof props.onClick === "function"){
                props.onClick(id,name);
            }
        }else{
            if(true/*Range for edit*/){
                Navigate("/Personal/Clinica/Terapia/"+FormActions.Update+"/"+id);
            }else{/*Range for ReadOnly */
                Navigate("/Personal/Clinica/Terapia/"+FormActions.Read+"/"+id);
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

    const onClickAddTera=()=>{
        Navigate("/Personal/Clinica/Terapia/"+FormActions.Add);
    }

    return(<Layout>
        <PageHeader className="TopTittle" ghost={false} onBack={()=>{onBack()}} title={<Title level={2}>Terapias</Title>}/>
        <button className='BottomRoundButton' onClick={()=>{onClickAddTera()}} style={{display:isPicker?"none":""}}><PlusOutlined/></button>
        <Layout className='ContentLayout'>
        <Searchbar onSearch={(value)=>{TeraSearch(value)}} loading={LoadingList}/>
            <Pagination onChange={(page)=>changePage(page)} defaultPageSize={perPageDefault} total={totalItems} style={{marginTop:"20px"}}/>
            <List style={{marginTop:"40px"}} loading={LoadingList} grid={grid}
            dataSource={Teras} renderItem={tera => (
                <ItemView id={tera.id} avatar={tera.coverimage} text={tera.name} onClick={(id,name)=>{onclick(id,name)}}/>
            )}/>
        </Layout>
    </Layout>)
}