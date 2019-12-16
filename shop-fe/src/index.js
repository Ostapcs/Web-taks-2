import React from 'react';
import ReactDOM from 'react-dom';
import {BrowserRouter as Router, Route, Switch} from "react-router-dom";
import LoginForm from "./Components/CustomForms/LoginForm";
import {ToastContainer} from "react-toastify";
import HomePage from "./Components/Home";
import NotFound from "./Components/NotFoundPage";
import Product from "./Components/Product";
import PrivateRouteComponent from "./Components/PrivateRoute";
import RegisterForm from "./Components/CustomForms/RegisterForm";
import UpdateUserForm from "./Components/CustomForms/UpdateUserForm";
import CartPage from "./Components/Cart";
import CreateProductForm from "./Components/CustomForms/CreateProductForm";
import UpdateProductForm from "./Components/CustomForms/UpdateProductForm";
// import * as serviceWorker from './serviceWorker';

ReactDOM.render(
    <Router>
        <ToastContainer/>
        <Switch>
            <Route exact path="/login" component={LoginForm}/>
            <Route exact path="/register" component={RegisterForm}/>
            <Route exact path="/user/update" component={UpdateUserForm}/>
            <Route exact path="/Home" component={HomePage}/>
            <Route exact path="/cart" component={CartPage}/>
            <Route exact path="/product/create" component={CreateProductForm}/>
            <Route path="/product/update/:id(\d+)" component={UpdateProductForm}/>
            <Route path="/product/:id(\d+)" component={Product}/>
            <Route component={NotFound}/>
        </Switch>
    </Router>,
    document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
// serviceWorker.unregister();
