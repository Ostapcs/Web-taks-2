import constant from "../../src/constants";
import * as httpService from "./HTTPService" ;

async function addComment(comment) {
    return await httpService.post(constant.addComment, comment);
}

export {addComment};