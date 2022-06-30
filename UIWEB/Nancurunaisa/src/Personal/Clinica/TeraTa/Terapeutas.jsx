import {PageHeader,Typography, Layout, Input, List, Pagination, Collapse, Button} from 'antd';/*osiris */
import { useNavigate} from "react-router-dom";
import { GetByPagTeraTa, SearchTeraTa } from '../../../Utils/FetchingInfo';
const { Title } = Typography;
const {Search} = Input;
const { Panel } = Collapse;
import React, {useState,useEffect} from 'react';
import "../../../Utils/TextUtils.css";
import ItemView from "../../../Components/Items/TerapeutaItem";
import Searchbar from '../../../Components/SearchBar';
import { CheckOutlined, ControlOutlined, DeleteOutlined, PlusOutlined } from '@ant-design/icons';
import { FormActions } from '../../../Utils/ActionsProviders';
import { getFirstWord, MapSelectedItems } from '../../../Utils/TextUtils';
import { Terapeuta } from '../../../Models/Models';
import SelectedItem from '../../../Components/Items/SelectedItem';
import { AllowFunction, Ranges } from '../../../Utils/RangeProviders';

export default function Terapeutas(props){
    let Navigate = useNavigate();
    const [Terapeutas, setTerapeutas] = useState([]);
    const [LoadingList,setLoadingList] = useState(true);
    const perPageDefault = 6;
    const [totalItems,setTotalItems] = useState(0);

    const isPicker = props.picker==true? true:false
    const isMulti = props.multi==true? true:false

    const [MultiData,setMultiData] = useState(props.data? props.data:[]);
    const grid = isPicker? {}:{ gutter: 16, xs: 1, sm: 1, md: 2,lg: 2,xl: 3,xxl: 3 }

    const [selectionMode,setSelectionMode] = useState(isMulti?true:false);//is selection mode

    useEffect(() => {
      TeraTasGet(1)
    }, [])

    const TeraTasGet = (Page) => {
      /*GetByPagTeraTa(Page,perPageDefault).then((result) => {
        setTotalItems(result.pages);
        setList(result.masajistas);
        }
      )*/

      const TeraTas = [{idMasajista:1,nombres:"Maria Jose",apellidos:"Altamirano Lopez"},
                      {idMasajista:2,nombres:"Juan Carlos",apellidos:"Altamirano Lopez"},
                      {idMasajista:3,nombres:"Armando Carlos",apellidos:"Guitarra Lopez"},
                      {idMasajista:4,nombres:"Hone Carlos",apellidos:"Lopez Lopez"},]

      const data = [];
      TeraTas.map((item)=>{
        data.push(new Terapeuta(item.idMasajista,item.nombres,item.apellidos,null,null,null,null,null,null,null,MultiData.find((sel)=>{return sel.idMasajista==item.idMasajista})? true:false));
      });
      setTotalItems(TeraTas.length);
      setList(data);
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

    const setSelectedPac =(index,sel)=>{
      let newArr = [...Terapeutas]; // copying the old datas array
      newArr[index].selected = sel; //key and value
      setTerapeutas(newArr);
  }

  const setMultiSelected =(index,id,selected)=>{//multi selection select or deselect
      if(selected){//if is selected, i want to deselect 
          setMultiData(MultiData.filter(item=>item.idMasajista!=id));
          setSelectedPac(index,false);
          if(MultiData.length == 1){
              setMultiData([]);
              setSelectionMode(false);
          }
      }else{
          setMultiData(MultiData => [...MultiData, Terapeutas[index]]);
          setSelectedPac(index,true);
      }
  }

  const desSelectItem =(id,index) =>{
      //setMultiData(MultiData.slice(index,1));
      setMultiData(MultiData.filter((item,indexF)=>indexF!=index));

      let newArr = [...Terapeutas]; // copying the old datas array
      newArr.map((item)=>{
          if(item.idMasajista==id){
              item.selected = false;
          }
      });

      setTerapeutas(newArr);

      if(MultiData.length == 1){
          setMultiData([]);
          setSelectionMode(false);
      }
  }

  const onLongPress = (id,name,selected,index) => {
      if(isPicker){
          props.onFinish(Terapeutas[index]);
      }else{
         if(selectionMode){//if iam in multi Selection Mode
              setMultiSelected(index,id,selected);
          }else{
              setMultiData(MultiData => [...MultiData, Terapeutas[index]]);
              setSelectedPac(index,true);
              setSelectionMode(true);
          } 
      }        
  }

  const onclick=(id,name,selected,index)=>{
      if(isPicker){
          props.onFinish(Terapeutas[index]);
      }else if (isMulti){
          if(!selectionMode) { setSelectionMode(true); }
          setMultiSelected(index,id,selected);
      }else {
         if(selectionMode){//if iam in multi Selection Mode
              setMultiSelected(index,id,selected);
          }else{
              if(AllowFunction([Ranges.Owner])){//Owner and Employ can edit
                Navigate("/Personal/Clinica/Terapeuta/"+FormActions.Update+"/"+id);
              }else{/*Range for ReadOnly */
                Navigate("/Personal/Clinica/Terapeuta/"+FormActions.Read+"/"+id);
              }
          }
      }
  }

    const onBack=()=>{
      if(isPicker || isMulti){
          if (typeof props.onBack === "function") {
              props.onBack();
          }
      }else{
          Navigate(-1)
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
        <PageHeader className="TopTittle" ghost={false} onBack={()=>{onBack()}} title={<Title level={2}>Terapeutas</Title>}
        extra={<><Button style={{display:selectionMode && !isPicker && !isMulti?"":"none"}} shape="circle" size='large' 
                onClick={()=>{console.log(MultiData)}} icon={<DeleteOutlined/>}/></>}>
            
            <MapSelectedItems data={MultiData} item={(item,index)=>(<SelectedItem key={index} index={index} text={item.getShortName} avatar={""} 
            onClick={(index)=>{desSelectItem(item.idMasajista,index)}} />)}/>
            
        </PageHeader>
        <button className='BottomRoundButton' onClick={()=>{onClickAddTerata()}} style={{display:isPicker||isMulti?"none":""}}><PlusOutlined/></button>
        <button className='BottomRoundButton' onClick={()=>{props.onFinish(MultiData)}} style={{display:selectionMode && isMulti?"":"none"}}><CheckOutlined/></button>
        <Layout className='ContentLayout'>
          <Searchbar onSearch={(value)=>{TeraTaSearch(value)}} loading={LoadingList}/>

          <Collapse bordered={false} style={{width:"100%",maxWidth:"600px"}}>
            <Panel showArrow={false} extra={<ControlOutlined style={{fontSize:"20px"}}/>} header="Filtrar" key="PanelFilters">
            </Panel>
          </Collapse>

          <Pagination onChange={(page)=>changePage(page)} defaultPageSize={perPageDefault} 
          total={totalItems*perPageDefault} style={{marginTop:"20px"}}/>
            <List style={{marginTop:"40px"}} loading={LoadingList} grid={{ gutter: 16, xs: 1, sm: 1, md: 2,lg: 2,xl: 3,xxl: 3 }}
            dataSource={Terapeutas} renderItem={(teraTa,index) => (
              <ItemView id={teraTa.idMasajista} avatar={""} onClick={(id,name,selected)=>{onclick(id,name,selected,index)}}
                onLongPress={(id,name,selected)=>{onLongPress(id,name,selected,index)}} mulSelMode={selectionMode}
                text={teraTa.getShortName} selected={teraTa.selected}/>
            )}/>
        </Layout>
      </Layout>)
}