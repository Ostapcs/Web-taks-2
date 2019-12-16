import React from "react";
import {Link, Redirect} from "react-router-dom";
import {getKey} from "../services/localStorageService";
import {get} from "../services/HTTPService";

class NavBar extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            redirect: false
        };
    }


    setRedirect = () => {
        this.setState({
            redirect: true
        })
    };
    renderRedirect = () => {
        if (this.state.redirect) {
            return <Redirect to='/'/>
        }
    };

    logOut = () => {
        localStorage.clear();
        this.setRedirect();
        //return <Redirect to={'/'}/>
    };


    render() {
        return <div style={{display: 'flex'}}>
            <div style={{width: '-webkit-fill-available'}}>
                <nav className="navbar navbar-expand-lg bg-dark">
                    <ul className=" nav nav-pills ">
                        <li className="nav-item"><Link className="nav-link" to="/Home">All</Link></li>
                        <li className="nav-item"><Link className="nav-link" to="/urls">T-Shirts</Link></li>
                        <li className="nav-item"><Link className="nav-link" to="/users">Shirts</Link></li>
                    </ul>

                    {getKey("Token") && <div>
                        {this.renderRedirect()}
                        <button className='btn btn-danger'
                                style={{
                                    height: '56px',
                                    borderRadius: '0px',
                                    position: "absolute",
                                    right: "5px"
                                }}
                                onClick={this.logOut}>LogOut
                        </button>
                        <button
                            className='btn btn-info'
                            style={{
                                // position: "absolute",
                                height: "56px",
                                borderRadius: 0,
                                // right: "205px",
                                // top: 0,
                            }}
                        ><Link className="nav-link" to="/cart">Cart</Link></button>
                    </div>}
                    {getKey("Role") ==="Admin" &&
                    <button
                        className='btn btn-info'
                        style={{
                            // position: "absolute",
                            height: "56px",
                            borderRadius: 0,
                            // right: "205px",
                            // top: 0,
                        }}
                    ><Link className="nav-link" to="/orders">Orders</Link></button>
                    }
                    {!getKey("Token") && <div>
                        <button className='btn btn-warning'
                                style={{
                                    position: "absolute",
                                    height: "56px",
                                    borderRadius: 0,
                                    right: 0,
                                    top: 0,
                                }}
                        ><Link className="nav-link" to="/login">Sign in</Link></button>
                        <button className='btn btn-warning'
                                style={{
                                    position: "absolute",
                                    height: "56px",
                                    borderRadius: 0,
                                    right: "105px",
                                    top: 0,
                                }}
                        ><Link className="nav-link" to="/register">Register</Link></button>

                    </div>}

                </nav>
            </div>


        </div>
    }
}


export default NavBar;