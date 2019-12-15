import React from "react";
import "../../css/login-form.css";
import {UnAuthorizeAccess} from "../PrivateRoute";
import Form from "../Form";
import {getToken} from "../../services/loginPageService";
import {toast} from "react-toastify";


class Login extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            formData: {
                login: "",
                password: ""
            },
            validatedObjects: {},
            inputConfig: [
                {
                    name: "login",
                    label: "Login",
                    required: true,
                    // value: "admin@gmail.com",
                    cssClass: 'form-control',
                    errorMessage: 'Login is required field'
                },
                {
                    name: "password",
                    label: "Password",
                    required: true,
                    type: "password",
                    // value: "Admin_123",
                    cssClass: 'form-control',
                    errorMessage: 'Password is required field'

                }
            ]
        };
        // this.loginSrv = new LoginService();
        //this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit = async () => {
        const {history} = this.props;
        const {login, password} = this.state.formData;
        let response;
        if (login === "" && password === "" &&
            this.state.inputConfig[0].value !== "" && this.state.inputConfig[1].value) {
            response = await getToken(this.state.inputConfig[0].value, this.state.inputConfig[1].value);
        } else {
            response = await getToken(this.state.formData.login, this.state.formData.password);
        }
        //console.log(response);
        if (response.hasOwnProperty("error_description")) {
            toast.error(response["error_description"], {position: toast.POSITION.TOP_CENTER});

        } else if (response.hasOwnProperty('message')) {
            toast.error(response.message, {position: toast.POSITION.BOTTOM_RIGHT});
            return ;

        } else if (response && UnAuthorizeAccess.location) {
            localStorage.setItem("Token", response.access_token);
            history.push(UnAuthorizeAccess.location);
            UnAuthorizeAccess.location = null;
        } else {
            localStorage.setItem("Token", response.access_token);
            history.push("/main");
        }
    };

    render() {
        return <div className="container">
            <Form setBaseState={this.setState.bind(this)}
                  onSubmit={this.handleSubmit}
                  baseState={this.state}
                  inputConfig={this.state.inputConfig}/>
        </div>
    }
}

export default Login;