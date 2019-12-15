function getKey(key){
    return localStorage.getItem(key);
}

function clear(){
    localStorage.clear()
}

export {getKey, clear}