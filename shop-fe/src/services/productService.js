import constant from "../../src/constants";
import * as httpService from "./HTTPService" ;

async function getProducts() {
    return await httpService.get(constant.getProductUrl);
}

async function getProductById(id) {
    return await httpService.get(constant.getProductById + id.toString())
}

export {getProducts, getProductById}