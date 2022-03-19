import React from 'react';
import { connect } from 'react-redux';
import { Button } from 'antd';
import './Home.css'
const Home = props => (
  <div  className='align-content-center'>
    <Button className='btnMargin' style={{magrin:"20px"}}>Product</Button>
    <br/>
    <Button className='btnMargin' >Category</Button>
    <br/>
    <Button className='btnMargin' >User</Button>

  </div>
);

export default connect()(Home);
