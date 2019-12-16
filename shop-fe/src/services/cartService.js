import constant from "../../src/constants";
import * as httpService from "./HTTPService" ;

async function addToCart(cart) {
    return await httpService.post(constant.addToCart, cart);
}

async function getCart(userId) {
    return await httpService.get(constant.getCart + userId.toString())
}

async function updateAmount(cart) {
    return await httpService.put(constant.updateAmount, cart);
}

export {addToCart, getCart, updateAmount};