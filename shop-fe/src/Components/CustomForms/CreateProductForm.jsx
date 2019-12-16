import React from "react";
import Form from "../Form";
import {createProduct} from "../../services/productService";
import 'react-toastify/dist/ReactToastify.css';
import {toast} from "react-toastify";

class CreateProductForm extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            formData: {},
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
                    name: "description",
                    label: "Description for product",
                    required: true,
                    cssClass: 'form-control',
                    errorMessage: 'Description is required field'
                },
                {
                    name: "price",
                    label: "Price for product",
                    required: true,
                    type : "number",
                    min : "1",
                    cssClass: 'form-control',
                    errorMessage: 'Description is required field'
                },
                {
                    name: "file",
                    label: "Photo for product",
                    required: true,
                    type : "file",
                    cssClass: 'form-control',
                    errorMessage: 'File is required field'
                },
            ]
        }
    }

    handleSubmit = async () => {
        const reader = new FileReader();
        const {name, description, price } = this.state.formData;
        reader.readAsDataURL(this.state.formData.file);
        reader.onload =  async function() {
             await createProduct({
                "Name": name,
                "Description": description,
                "Price": parseFloat(price),
                "File": reader.result
            }).then(resp => {
                 toast.success("Added Product", {position: toast.POSITION.BOTTOM_RIGHT});
             });
        };



    };



    render() {
        return <div className="container">
            <Form setBaseState={this.setState.bind(this)}
                  onSubmit={this.handleSubmit}
                  baseState={this.state}
                  inputConfig={this.state.inputConfig}/>
            {/*<input type="file" onChange={this.showFile}/>*/}
        </div>
    }
}

export default CreateProductForm;