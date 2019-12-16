import React from "react";
import {getProductById} from "../services/productService";
import NavBar from "./NavBar";
import {getKey} from "../services/localStorageService";
import Form from "./Form";
import {addComment} from "../services/commentService";
import {addToCart} from "../services/cartService";
import {toast} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

class Product extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            product: {},
            comments : [],
            id: this.props.match.params.id,
            formData: {
                comment: ""
            },
            validatedObjects: {},
            inputConfig: [
                {
                    name: "comment",
                    label: "Your Comment",
                    required: true,
                    cssClass: 'form-control',
                    errorMessage: 'Comment is required field'
                },
            ]
        }
    }

    async componentDidMount() {
        await getProductById(this.state.id).then(resp =>
            this.setState({product: resp, comments: resp.comments}))
    }

    handleSubmit = async () => {
        await addComment(
            {
                "UserId" : parseInt(getKey("Id")),
                "ProductId" : parseInt(this.state.id),
                "Text" : this.state.formData.comment
            }
        ).then(resp => {
            let comments = [...this.state.comments];
            comments.push(resp);
            this.setState({comments: comments})
        });
    };

    addToCart = async () => {
        await addToCart(
            {
                "UserId" : parseInt(getKey("Id")),
                "ProductId" : parseInt(this.state.id)
            }
        ).then(resp =>
            toast.success("Quiz was updated successfully", {position: toast.POSITION.BOTTOM_RIGHT}));
    };


    render() {
        return <div>
            <NavBar/>
            <div style={{margin: "5%"}}>
                <h2>{this.state.product.name}</h2>
                <div className={"row"} style={{display: "flex", marginTop: "5%"}}>
                    <div className={"col"}>
                        <img src={this.state.product.file}
                             style={{maxHeight: "400px", maxWidth: "100%", minHeight: "300px"}}
                        />
                    </div>

                    <div className={"col"}>
                        <p style={{wordBreak: "break-all", fontSize: "2em"}}>{this.state.product.description}</p>
                        <p className={"text-view"}><span>Price : </span>{this.state.product.price}</p>
                        <button onClick={this.addToCart}>Buy</button>
                    </div>

                </div>
            </div>
            <div style={{margin: "2%"}}>
                {getKey("Token") &&
                <Form setBaseState={this.setState.bind(this)}
                      onSubmit={this.handleSubmit}
                      baseState={this.state}
                      inputConfig={this.state.inputConfig}/>
                }
            </div>
            <div >
                {this.state.comments.map(c => {
                    return <div className={"container"} style={{marginTop: "2%"}}>
                        <div>
                            <span>{`${c.user.name} ${c.user.surname}`}</span>
                        </div>
                        <div>
                            <p style={{wordBreak: "break-all"}}>{c.text}</p>
                        </div>
                    </div>
                })}
            </div>
        </div>
    }
}

export default Product