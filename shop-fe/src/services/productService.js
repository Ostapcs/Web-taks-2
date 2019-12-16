import constant from "../../src/constants";
import * as httpService from "./HTTPService" ;

async function getProducts() {
    return await httpService.get(constant.getProductUrl);
}

async function getProductById(id) {
    return await httpService.get(constant.getProductById + id)
}

async function createProduct(product){
    return await httpService.post(constant.createProduct, product);
}

async function updateProduct(product){
    return await httpService.put(constant.updateProduct, product);
}

async function removeProduct(id){
    return await httpService.deleteObject(constant.deleteProduct + id)
}

export {getProducts, getProductById, createProduct, updateProduct, removeProduct}