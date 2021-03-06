import React from "react";
import {register} from "../../services/loginPageService";
import Form from "../Form";

class RegisterForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            formData: {
                name: "",
                surname: "",
                email: "",
                address: "",
                password: "",
                confirmpassword: ""
            },
            validatedObjects: {},
            inputConfig: [
                {
                    name: "name",
                    label: "Name",
                    required: true,
                    cssClass: 'form-control',
                    errorMessage: 'Name is required field'
                },
                {
                    name: "surname",
                    label: "Surname",
                    required: true,
                    cssClass: 'form-control',
                    errorMessage: 'Surname is required field'
                },
                {
                    name: "email",
                    label: "Email",
                    required: true,
                    cssClass: 'form-control',
                    errorMessage: 'Email is required field'
                },
                {
                    name: "address",
                    label: "Address",
                    required: true,
                    cssClass: 'form-control',
                    errorMessage: 'Address is required field'
                },
                {
                    name: "password",
                    label: "Password",
                    required: true,
                    type: "password",
                    cssClass: 'form-control',
                    errorMessage: 'Password is required field'
                },
                {
                    name: "confirmpassword",
                    label: "Confirm Password",
                    required: true,
                    type: "password",
                    cssClass: 'form-control',
                    errorMessage: 'Password is required field'
                },
            ]
        };
        // this.loginSrv = new LoginService();
        //this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit = async () => {
        const {history} = this.props;
        const userInfo  = this.state.formData;
        await register(userInfo)

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

export default RegisterForm;