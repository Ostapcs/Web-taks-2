import React from "react";
import {getCart, updateAmount} from "../services/cartService";
import {getKey} from "../services/localStorageService";
import 'react-toastify/dist/ReactToastify.css';
import NavBar from "./NavBar";
import Form from "./Form";
import {toast} from "react-toastify";
import {addOrder} from "../services/orderService";

class CartPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            products: [],
            validatedObjects: {},
            formData: {},
            totalPrice : 0
        }
    }

    async componentDidMount() {
        await getCart(getKey("Id"))
            .then(resp => {

                let formdata = {};
                let total = 0;
                resp.map(r => {
                    formdata[r.product.id] = r.amount;
                    total += parseInt(r.amount) * parseFloat(r.product.price);
                });
                this.setState({
                    products: resp,
                    formData: formdata,
                    totalPrice : total
                });
            })
    }

    UpdateAmount = async (e) => {
        var productId = parseInt(e.target.id);
        var inputValue = document.getElementById(`val-${e.target.id}`);

        await updateAmount({
            "UserId": parseInt(getKey("Id")),
            "ProductId": parseInt(e.target.id),
            "Amount": parseInt(inputValue.value)
        }).then(resp => {
            toast.success("Updated Amount", {position: toast.POSITION.BOTTOM_RIGHT});

        });
        let prod = this.state.products;
        let total = 0;
        prod.map(p => {
            if(p.product.id === productId)
                p.amount = inputValue.value;
            total += parseInt(p.amount) * parseFloat(p.product.price);
        });

        this.setState({products : prod, totalPrice : total})
    };

    handleOnchange = async (e) => {
        let formData = Object.assign({}, this.state.formData);
        console.log(e.target.name);
        formData[e.target.name] = e.target.value;
        await this.setState({formData: formData});
    };

    addOrder = async () => {
        let userId = getKey("Id");
        let price = this.state.totalPrice;
        let delivaryOpt = document.getElementById('delivery').value
        let productId = [];
        this.state.products.map(p => {
            productId.push(p.product.id)
        });

        await addOrder({
            "UserId" : parseInt(userId),
            "Price" : parseFloat(price),
            "DeliveryOpt" : delivaryOpt,
            "ProductIds" : productId
        }).then(resp =>
            toast.success("Add Order", {position: toast.POSITION.BOTTOM_RIGHT})
        );

    };

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
                <div style={{textAlign : "center", margin : "2%"}}>
                    <h2>Total price : {this.state.totalPrice}</h2>
                </div>
                <div style={{textAlign : "center", margin : "2%"}}>
                    <select id='delivery'>
                        <option value="New Post">New Post</option>
                        <option value="Ukr Post">Ukr Post</option>
                    </select>
                </div>
                <div style={{textAlign: "center"}}>
                    <button
                        className={'btn btn-success'}
                        type='button'
                        onClick={this.addOrder}
                    >Create Order
                    </button>
                </div>
            </div>
        </div>
    }
}

export default CartPage;