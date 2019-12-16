import constant from "../../src/constants";
import * as httpService from "./HTTPService" ;

async function addOrder(order) {
    return await httpService.post(constant.addOrder, order);
}

async function getOrders() {
    return await httpService.get(constant.getOrders);
}

export {addOrder, getOrders}