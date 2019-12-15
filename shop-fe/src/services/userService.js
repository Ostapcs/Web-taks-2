import constant from "../../src/constants";
import * as httpService from "./HTTPService" ;

async function updateUser(user) {
    return await httpService.put(constant.updateUser, user);
}

export {updateUser}