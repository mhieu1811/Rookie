import React from 'react';
import { connect } from 'react-redux';

import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Category from './components/Category/Category';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import 'antd/dist/antd.css';    
import '@fortawesome/fontawesome-free/css/all.min.css';
import CallbackPage from './components/callback/CallbackPage';
import ProfilePage from './components/profile/ProfilePage';
import Product from './components/Product/Product';
import AddCategory from './components/Category/AddCategory';
import EditCategory from './components/Category/EditCategory';
import AddProduct from './components/Product/AddProduct';
import EditProduct from './components/Product/EditProduct';
import { Component } from 'react/cjs/react.production.min';
import { Button } from 'antd';
import userManager from '../src/utils/userManager';
import User from './components/User/User';


                    export default () => (

                        <Layout>
                            <Route exact path="/" component={Home} />
                            <Route path="/counter" component={Counter} />
                            <Route path="/category/:page?" component={Category} />
                            <Route path="/fetch-data/:startDateIndex?" component={FetchData} />
                            <Route path="/addcate" component={AddCategory} />
                            <Route path="/addpro" component={AddProduct} />
                            <Route path="/editpro/:id" component={EditProduct} />

                            <Route path="/editcate/:id" component={EditCategory} />
                            <Route path="/callback" component={CallbackPage} />
                            <Route path="/product/:page?" component={Product} />
                            <Route path="/user/:page?" component={User} />

                            <Route path="/profile" component={ProfilePage} />
                        </Layout>
    
                    );

                    // class App extends React.Component{
                        
                    //     render(){
                    //         const { user, isAuthenticated } = this.props;
                    //         const isAdmin = isAuthenticated && user.profile['Role'] === 'Admin';
                           
                    //             return(
                    //                 <Layout>
                    //                     {/* {isAdmin ?(
                    //                             <Route exact path="/" component={Home} />
                    //                             <Route path="/counter" component={Counter} />
                    //                             <Route path="/category/:page?" component={Category} />
                    //                             <Route path="/fetch-data/:startDateIndex?" component={FetchData} />
                    //                             <Route path="/addcate" component={AddCategory} />
                    //                             <Route path="/addpro" component={AddProduct} />
                    //                             <Route path="/editpro/:id" component={EditProduct} />
                    //                             <Route path="/editcate/:id" component={EditCategory} />
                    //                             <Route path="/callback" component={CallbackPage} />
                    //                             <Route path="/product/:page?" component={Product} />
                    //                             <Route path="/user/:page?" component={User} />
                    //                             <Route path="/profile" component={ProfilePage} />
                    //                     ):( */}
                    //                             <Route exact path="/" component={Home} />
                    //                             <Route path="/callback" component={CallbackPage} />
                                            
                    //                     {/* )} */}
                    //                 </Layout>
                                        
        
                    //             )

                            
                                
                                
                            
                    //     }
                    // }
        
function mapStateToProps(state) {
  return {
    user: state.oidc.user,
    isAuthenticated: state.oidc.user && !state.oidc.user.expired
  };
}

// export default connect(mapStateToProps)(App);
