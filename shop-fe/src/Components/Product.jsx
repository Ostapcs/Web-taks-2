import React from "react";
import {getProductById} from "../services/productService";
import NavBar from "./NavBar";

class Product extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            product: {
                comments: []
            },
            id: this.props.match.params.id,
        }
    }

    async componentDidMount() {
        await getProductById(this.state.id).then(resp =>
            this.setState({product: resp}))
    }


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
                        <p style={{wordBreak: "break-all"}}>{this.state.product.description}</p>
                        <p>{this.state.product.price}</p>
                        <button>Buy</button>
                    </div>

                </div>
            </div>

            <div >
                {this.state.product.comments.map(c => {
                    return <div className={"container"} style={{marginTop: "2%"}}>
                        <div>
                            <span>{`${c.user.name} ${c.user.surname}`}</span>
                        </div>
                        <div>
                            <p style={{wordBreak: "break-all"}}>c.text</p>
                        </div>
                    </div>
                })}
            </div>
        </div>
    }
}

export default Product