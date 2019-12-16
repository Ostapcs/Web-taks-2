import React from "react";
import {getOrders} from "../services/orderService";
import Table from "./Table";

class OrderPage extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            headers: []
        }
    }

    async componentDidMount() {

        let response = await getOrders().then(resp => {
            //this.setState({orders : resp});
            return resp;
        });

        let orders = [];

        response.map(r => {
            let list = [];
            let product = r.productDtos.map(p => {
                list.push(
                    <li>Id - {p.id}; Name - {p.name}</li>
                )
            });

            let ul;


            let obj = {
                OrderId: r.id,
                TotalPrice: r.price,
                DeliveryOpt: r.deliveryOpt,
                User: `${r.userInfoDto.name} ${r.userInfoDto.surname}`,
                Address: r.userInfoDto.address,
                Email: r.userInfoDto.email,
                Products: <ul>{list}</ul>
            };
            orders.push(obj);
        });
        let headers = Object.keys(orders[0]);
        this.setState({data: orders, headers: headers})

    }

    render() {
        return <div>
            <Table
                setBaseState={this.setState.bind(this)}
                baseState={this.state}
                data={this.state.data}
                headers={this.state.headers}
            />
        </div>
    }

}

export default OrderPage;