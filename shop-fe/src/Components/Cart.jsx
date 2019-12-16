import React from "react";
import {getCart, updateAmount} from "../services/cartService";
import {getKey} from "../services/localStorageService";
import 'react-toastify/dist/ReactToastify.css';
import NavBar from "./NavBar";
import Form from "./Form";
import {toast} from "react-toastify";

class CartPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            products: [],
            validatedObjects: {},
            formData: {}
        }
    }

    async componentDidMount() {
        await getCart(getKey("Id"))
            .then(resp => {

                let formdata = {};
                resp.map(r => {
                    formdata[r.product.id] = r.amount;
                });
                this.setState({
                    products: resp,
                    formData: formdata
                });
            })
    }

    async UpdateAmount(e) {
        var productId = parseInt(e.target.id);
        var inputValue = document.getElementById(`val-${e.target.id}`);

        await updateAmount({
            "UserId": parseInt(getKey("Id")),
            "ProductId": parseInt(e.target.id),
            "Amount": parseInt(inputValue.value)
        }).then(resp => {
            toast.success("Updated Amount", {position: toast.POSITION.BOTTOM_RIGHT});
        });
    }

    handleOnchange = async (e) => {
        let formData = Object.assign({}, this.state.formData);
        console.log(e.target.name);
        formData[e.target.name] = e.target.value;
        await this.setState({formData: formData});
    }


    render() {
        return <div>
            <NavBar/>
            <div>
                {this.state.products.map(p => {
                    return <div className={"container"} style={{marginTop: "2%"}}>
                        <img src={p.product.file} style={{maxHeight: "200px", maxWidth: "100%", minHeight: "200px"}}/>
                        <p><span>Name : </span>{p.product.name}</p>
                        <p><span>Price : </span>{p.product.price}</p>
                        <form>
                            <label>Amount</label>
                            <input
                                name={p.product.id.toString()}
                                onChange={this.handleOnchange}
                                style={{marginLeft: "2%"}}
                                id={`val-${p.product.id}`}
                                type="number"
                                min="1"
                                step="1"
                                value={this.state.formData[p.product.id]}
                            />
                            <button
                                id={p.product.id.toString()}
                                style={{marginLeft: "2%"}}
                                className='btn btn-success'
                                onClick={this.UpdateAmount}
                                type="button">Submit
                            </button>
                        </form>
                    </div>
                })}
                <div style={{textAlign: "center"}}>
                    <button
                        className={'btn btn-success'}
                        type='button'
                    >Create Order
                    </button>
                </div>
            </div>
        </div>
    }
}

export default CartPage;