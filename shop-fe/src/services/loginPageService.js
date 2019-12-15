import {login as loginService, post} from "./HTTPService";
import constant from "../../src/constants.json";


async function getToken(login, password) {
    let data = `grant_type=password&email=${login}&password=${password}`;

    return await loginService(constant.loginUrl, data);
}

async function register(user){
    return await post(constant.register, user);
}

export {getToken, register};