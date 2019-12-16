import React from "react";
import Form from "../Form";
import {getProductById, updateProduct} from "../../services/productService";
import 'react-toastify/dist/ReactToastify.css';
import {toast} from "react-toastify";

class UpdateProductForm extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            id : this.props.match.params.id,
            formData: {
                name: "",
                description : "",
                price : "",
                file : ""
            },
            validatedObjects: {},

        }
    }

    handleSubmit = async () => {
        await updateProduct(this.state.formData)
    };

    async componentDidMount() {
        await getProductById(this.state.id)
            .then(response => {
                this.setState({formData : response});
            })
    }


    render() {
        const {name, description, price, file} = this.state.formData;
        return <div className="container">
            <Form setBaseState={this.setState.bind(this)}
                  onSubmit={this.handleSubmit}
                  baseState={this.state}
                  inputConfig={[
                  {
                      name: "name",
                      label: "Name",
                      required: true,
                      cssClass: 'form-control',
                      value: name,
                      errorMessage: 'Name is required field'
                  },
                  {
                      name: "description",
                      label: "Description for product",
                      required: true,
                      cssClass: 'form-control',
                      value : description,
                      errorMessage: 'Description is required field'
                  },
                  {
                      name: "price",
                      label: "Price for product",
                      required: true,
                      type : "number",
                      min : "1",
                      cssClass: 'form-control',
                      value: price,
                      errorMessage: 'Description is required field'
                  },
                  {
                      name: "file",
                      label: "Photo for product",
                      required: true,
                      type : "file",
                      cssClass: 'form-control',
                      //value: file,
                      errorMessage: 'File is required field'
                  },
                      ]}/>
            {/*<input type="file" onChange={this.showFile}/>*/}
        </div>
    }
}

export default UpdateProductForm;