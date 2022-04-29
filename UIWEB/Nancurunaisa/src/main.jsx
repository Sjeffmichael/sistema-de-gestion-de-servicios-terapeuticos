import ReactDOM from 'react-dom';
import React from 'react';
import Landing from "./Landing/Landing";
import SignIn from './SignIn/SignIn';
import Home from "./Personal/Home/Home";

import Ajustes from "./Personal/Perfil/Ajustes";

import Clinica from "./Personal/Clinica/Clinica";
import Pacientes from "./Personal/Clinica/Pacientes";
import Terapeutas from "./Personal/Clinica/TeraTa/Terapeutas";
import TeraTaDetail from "./Personal/Clinica/TeraTa/TerataDetail";

import Facturas from "./Personal/Clinica/Facturas";
import Terapias from "./Personal/Clinica/Terapias";

import Citas from "./Personal/Citas/Citas";
import Buscar from "./Personal/Buscar/Buscar";

import BottomBar from "./Personal/Home/BottomBar";

import RequireAuth from "./Utils/RequireAuth";

import {
  BrowserRouter as Router,
  Route,
  Routes
} from "react-router-dom";

function Nancurunaisa(){
  return(
    <Router>
      <Routes>
        <Route exact path='/' element={<Landing/>}/>
        <Route exact path='*' element={<Landing/>}/>
        <Route exact path='/SignIn' element={<SignIn/>}/>

        <Route path ="/Personal" element={<RequireAuth/>}>
          <Route exact path='/Personal/Home' element={[<Home/>,<BottomBar/>]}/>
          <Route exact path='Ajustes' element={[<Ajustes/>,<BottomBar/>]}/>

          <Route exact path='/Personal/Clinica' element={[<Clinica/>,<BottomBar/>]}/>
          <Route exact path='/Personal/Clinica/Pacientes' element={[<Pacientes/>,<BottomBar/>]}/>
          <Route exact path='/Personal/Clinica/Facturas' element={[<Facturas/>,<BottomBar/>]}/>
          <Route exact path='/Personal/Clinica/Terapeutas' element={[<Terapeutas/>,<BottomBar/>]}/>
          <Route exact path='/Personal/Clinica/Terapeuta' element={[<TeraTaDetail/>,<BottomBar/>]}/>

          <Route exact path='/Personal/Clinica/Terapias' element={[<Terapias/>,<BottomBar/>]}/>

          <Route path='/Personal/Citas' element={[<Citas/>,<BottomBar/>]}/>
          <Route path='/Personal/Buscar' element={[<Buscar/>,<BottomBar/>]}/>
       </Route>
      </Routes>
    </Router>
  )
}
ReactDOM.render(
  <Nancurunaisa/>,
  document.getElementById('root')
);
