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
import PicturesWall from './components/Product/test';


export default () => (

                        <Layout>
                            <Route exact path="/" component={Home} />
                            <Route path="/counter" component={Counter} />
                            <Route path="/category/:page?" component={Category} />
                            <Route path="/fetch-data/:startDateIndex?" component={FetchData} />
                            <Route path="/addcate" component={AddCategory} />
                            <Route path="/addpro" component={AddProduct} />
                            <Route path="/test" component={PicturesWall} />

                            <Route path="/editcate/:id" component={EditCategory} />
                            <Route path="/callback" component={CallbackPage} />
                            <Route path="/product/:page?" component={Product} />
                            <Route path="/profile" component={ProfilePage} />
                        </Layout>
    
                    );
        

