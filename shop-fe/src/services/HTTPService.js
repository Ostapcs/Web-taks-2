import axios from "axios";
import {getKey} from "./localStorageService";

const localhostUrl = "https://localhost:5001/api";
const getTokenUrl = "https://localhost:5001/api/account";

async function login(url, data) {
    let result;
    await axios.post(
        getTokenUrl + url,
        data,
        {headers: {"Content-Type" : "application/x-www-form-urlencoded"}}
    )
        .then(response => {
            result = response.data
        })
        .catch(error => {
            console.log(error)
        });

    return result;
}

async function get(url) {
    let result;
    await axios.get(
        localhostUrl + url,
        {
            headers: {
                "Authorization": "Bearer " + getKey('Token'),
                "Content-Type" : "application/json"
            }
        },
    )
        .then(response => {
            result = response.data;
        })
        .catch((error) => {
            if (error.response !== undefined) {
                result = error.response.data
            } else {
                result = error;
            }
        });

    return result;
}

async function post(url, data) {
    let result;
    await axios.post(
        localhostUrl + url,
        data,
        {
            headers: {
                "Authorization": "Bearer " + getKey('Token'),
                "Content-Type" : "application/json"
        }}
    )
        .then((response) => {
                result = response.data;
            }
        )
        .catch(error => {
            if (error.response !== undefined) {
                result = error.response.data
            } else {
                result = error;
            }
        });


    return result;
}

async function put(url, data) {
    let result;
    await axios.put(
        localhostUrl + url,
        data,
        {
            headers: {
                "Authorization": "Bearer " + getKey('Token'),
                "Content-Type" : "application/json"
            }},
    )
        .then((response) => {
                result = response.data;
            }
        ).catch(error => {
            if (error.response !== undefined) {
                result = error.response.data
            } else {
                result = error;
            }
        });


    return result;
}

async function deleteObject(url) {
    let result;
    await axios.delete(
        localhostUrl + url,
        {headers: {"Authorization": "Bearer " + getKey('Token')}},
    )
        .then((response) => {
                result = response.data;
            }
        ).catch(error => {
            if (error.response !== undefined) {
                result = error.response.data
            } else {
                result = error;
            }
        });


    return result;
}

export {login, get, post, put, deleteObject};