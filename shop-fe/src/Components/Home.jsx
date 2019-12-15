import React from "react";
import {getProducts} from "../services/productService";
import "../css/main.css";
import NavBar from "./NavBar";

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

    render() {

        return <div>
            <NavBar/>
            <div style={{display: "flex"}} className="row row-cols-4">
                {this.state.products.map(p => {
                    return <div className={"container"} >
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