import ReactDOM from 'react-dom';
import React from 'react';
import Landing from "./Landing/Landing";
import SignIn from './SignIn/SignIn';
import Home from "./Personal/Home/Home";

import RequireAuth from "./Utils/RequireAuth";

import {
  BrowserRouter as Router,
  Route,
  Routes
} from "react-router-dom";

function Nancurunaisa(){
  const token = localStorage.getItem('accessToken');

  if (!token) {
    
  }


  return(
    <Router>
      <Routes>
        <Route exact path='/' element={<Landing/>}/>
        <Route exact path='*' element={<Landing/>}/>
        <Route exact path='/SignIn' element={<SignIn/>}/>
        <Route exact path="/Home" element={<Home/>}/>
      </Routes>
    </Router>
  )
}
/*<Route element={<RequireAuth/>}>
          <Route exact path="/Home" element={<Home/>}/>
        </Route>*/
ReactDOM.render(
  <Nancurunaisa/>,
  document.getElementById('root')
);
