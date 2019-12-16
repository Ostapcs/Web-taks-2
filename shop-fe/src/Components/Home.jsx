import React from "react";
import {getProducts, removeProduct} from "../services/productService";
import "../css/main.css";
import NavBar from "./NavBar";
import {getKey} from "../services/localStorageService";
import {toast} from "react-toastify";

class HomePage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            user: {},
            products: []
        }
    }

    async componentDidMount() {
        await getProducts().then(products => {
            this.setState({products: products})
        });
    }

    redirectToProduct = (e) => {
        let productId = e.target.id;

        const {history} = this.props;

        history.push(`/product/${productId}`)

    };

    createProduct = () => {
        const {history} = this.props;

        history.push(`/product/create`)
    };

    updateProduct = (id) => {
        const {history} = this.props;
        history.push(`/product/update/${id}`)
    };

    onDelete = async (id) => {
        await removeProduct(id)
            .then(resp => {
                toast.success("Deleted Product", {position: toast.POSITION.BOTTOM_RIGHT});
            });

        let pr = Object.assign([], this.state.products);
        const index = pr.indexOf(p => p.id === id);
        if(index > -1){
            pr = pr.splice(index, 1)
        }
        console.log(pr.splice(index, 1));
        this.setState({products : pr});
    };

    render() {

        return <div>
            <NavBar/>
            {
                getKey("Role") === "Admin" &&
                <button
                    style={{margin: '2%'}}
                    className={'btn btn-success'}
                    onClick={this.createProduct}
                >Create Product</button>
            }
            <div style={{display: "flex"}} className="row row-cols-4">
                {this.state.products.map(p => {
                    return <div className={"container"}>
                        {
                            getKey("Role") === "Admin" &&
                            <div className={'row'}>
                                <div className={'col-sm'}>
                                    <button
                                        style={{margin: '2%'}}
                                        className={'btn btn-success'}
                                        onClick={() => this.updateProduct(p.id)}
                                    >Update Product
                                    </button>
                                </div>
                                <div className={'col-sm'}>
                                    <p onClick={() => this.onDelete(p.id)} className="close">&times;</p>
                                </div>
                            </div>
                        }
                        <div className={"col-sm"} style={{display: "flex"}}>
                            <div>
                                <img src={p.file} style={{maxHeight: "200px", maxWidth: "100%", minHeight: "200px"}}/>
                                <p className={"text-view"}>{p.name}</p>
                                <p className={"text-view"}>{p.description}</p>
                                <button id={p.id} onClick={this.redirectToProduct}>View Product</button>
                            </div>
                            <div className={"price"}>
                                <p>{p.price}</p>
                            </div>

                        </div>
                    </div>
                })}
            </div>
        </div>
    }
}

export default HomePage;