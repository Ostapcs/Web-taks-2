import React from "react";
import {Route} from "react-router-dom";
import {Redirect} from "react-router-dom";

const IsAuthorized = {
    isAuthenticated: false,
    authenticate(path) {
        if (localStorage.getItem("Token")) {
            return this.isAuthenticated = true;
        }
        UnAuthorizeAccess.location = path;
    },
    logout() {
        localStorage.clear();
        this.isAuthenticated = false;
    }
};

const UnAuthorizeAccess = {
    pathname: ""
};

const privateRoute = ({component: Component, ...rest}) => (
    <Route {...rest} render={
        (props) => {
            if (IsAuthorized.authenticate(props.location.pathname)) {
                return <Component {...props}/>
            }

            return <Redirect to='/'/>
        }

    }/>
);

export  {privateRoute as default, UnAuthorizeAccess};