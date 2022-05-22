import LogInForm from "./LogInForm";
import Header from "../Landing/Header";
import { Layout } from "antd";



function SignIn(){
    return(
      <Layout>
        <Header/>
        <LogInForm/>
      </Layout>
    )
}

export default SignIn