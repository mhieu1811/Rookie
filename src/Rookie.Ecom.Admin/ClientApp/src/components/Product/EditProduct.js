import React, { Component, useEffect, useState } from 'react';
 import { Form, Input, Button,Select, DatePicker,Checkbox, InputNumber, Space, Skeleton,Upload ,notification,Carousel} from 'antd';
// import CurrencyInput from 'react-currency-input-field';
import moment from 'moment';
import { get } from 'jquery';
import {  edit, getList, getListcate } from '../../Service/CategoryService';
import { add,getobject,editpro } from '../../Service/ProductService';
import {Redirect} from 'react-router-dom'
import FormItem from 'antd/lib/form/FormItem';
import TextArea from 'antd/lib/input/TextArea';
// import "./AddProduct.css"
export default  function EditProduct(props) {
    const {id}=props.match.params;
    const date = Date.now();
    let today= new Date(date);
    function createGuid()  
    {  
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {  
            var r = Math.random()*16|0, v = c === 'x' ? r : (r&0x3|0x8);  
            return v.toString(16);  
        });  
    } 
    // const history=useHistory();

    const [form] = Form.useForm();   
    const[cate,setCate]=useState([])
    const[product, setProduct] = useState();
    const[checkedCate, setCatechecked] = useState([]);
    var temp=[]
    useEffect(()=>{
        
          getListcate().then(res=>setCate(res))
          const abc=   getobject(id).then(res=>{
                                 setProduct(res);
                                    res.productDetails.forEach(element => {
                                    temp.push(element.categoryID)
                                    setCatechecked(temp)
                                });
                            })
                console.log(product)
          
        
    },[])
    const onChangeCate =(list)=>{
        setCatechecked(list);
    }
    console.log(product)
      const onFinishFailed = (errorInfo) => {
          
        console.log('Failed:', errorInfo);
      };

      const [status, setStatus]=useState(false);
    const onFinish = async (values) => {

        values.Id=product.id;
        values.CreatedDate=product.createdDate
        values.UpdatedDate = new Date().toISOString();
        console.log(values.Cate)
        var bodyFormData = new FormData();
        for ( var key in values ) {
            if(key!="Picture"&& key!="Cate"){
                bodyFormData.append(key, values[key]);
            }
        }
        if(values.Picture!=null)
        {

            for(var x = 0; x < values.Picture.length; x++) {
                // the name has to be 'files' so that .NET could properly bind it
                bodyFormData.append('Picture', values.Picture.item(x));    
            }
        }
            for(var x = 0; x < checkedCate.length; x++) {
                // the name has to be 'files' so that .NET could properly bind it
                bodyFormData.append('Cate', checkedCate[x]);    
            }


        const res =await editpro(bodyFormData)
        console.log(res.status)
        if(res.status==204){
            openNotificationWithIcon('success','Edit Product Success','Done')           
        }else{
            openNotificationWithIcon('error','Edit Product Failed','Please try again')           
        }
      };

      const openNotificationWithIcon = (type,title,desc) => {
        notification[type]({
          message: title,
          description:
           desc,
        });
      };
const onClick=()=>{
    console.log(product)
}
        return (

            <div style={{marginTop:'30px'}}>
                <h1 style={{textAlign:'center',fontWeight:'bold',textTransform:'uppercase'}}>Edit Product</h1>
                {(product===undefined||cate.length===0)?(<Skeleton/>):(
                <div className="container">
                    {console.log(checkedCate)}
                    <div className="row">
                        <div className="col-lg-3">
                        <Carousel>
                            {product.productPictures.map((e)=>{
                                return (
                                    <div>
                                        <img style={{height:'250px'}} src= {`https://localhost:5011/Picture/${e.pictureUrl}`} />
                                    </div>
                                )
                            })}
                            
                            {/* <div>
                            <h3 style={contentStyle}>2</h3>
                            </div>
                            <div>
                            <h3 style={contentStyle}>3</h3>
                            </div>
                            <div>
                            <h3 style={contentStyle}>4</h3>
                            </div> */}
                        </Carousel>
                            {/* <div className="col--detail--1">
                            <img src={pic[0]}  />  */}
                            {/* <h1>Select Image</h1> */}
                            {/* <input type="file" name="myImage" onChange={handleFileInput} style={{marginTop:'10px',cursor: 'pointer'}} /> */}
                            {/* <p>Nếu không thêm hình, thì sẽ lấy ảnh default</p>
                            </div> */}
                        </div> 
                        <div className="col-lg-8 ">
                        <Form 
                            form={form}
                                onFinish={onFinish}
                            onFinishFailed={onFinishFailed}
                            className="col-lg-8-detalis"
                            initialValues={product}
                        >
                            <Form.Item
                                name="productName"
                                rules={[
                                    { required: true, message: 'Không được bỏ trống tên voucher' },
                                ]}
                                label="Product Name: "
                                className="form__row"
                            >
                                <Input initialValues={product.productName} placeholder="Product Name ..."/>
                            </Form.Item>
                    
                    
                            <Form.Item
                                name="quantity"
                                rules={[
                                    { required: true, message: 'Required' },
                                    {validator(value){
                                        if(document.getElementById("sl").value>0)
                                        {
                                            return Promise.resolve()
                                        }
                                        else
                                            return Promise.reject(new Error('Quantity must > 0'));
                                        
                                        
                                    }},
                                ]}  
                                label="Quantity"
                                className="form__row"
                            >
                                <Input type="number" id="sl" className="form__input" placeholder="Quantity ..." />

                            </Form.Item>
                
                    
                            <Form.Item
                                name="Cate"
                                    rules={[
                                        {validator(value){
                                            if(checkedCate.length>0)
                                            {
                                                return Promise.resolve()
                                            }
                                            else
                                                return Promise.reject(new Error('Required'));
                                            
                                            
                                        }},
                                    ]}
                                label="Catgory"
                                className="form__row"
                                valuePropName={checkedCate}
                                defaultValue={checkedCate}

                            >
                                <Checkbox.Group onChange={onChangeCate} value={checkedCate} >
                                    <Space wrap >
                                        {
                                            cate.map((val)=>{
                                            return <Checkbox key={val.id} value={val.id}>{val.categoryName}</Checkbox>
                                        })}
                                    </Space>
                                </Checkbox.Group>       
                            
                            </Form.Item>
                        

                    
                            <Form.Item
                                name="price"
                                rules={[
                                    { required: true, message: 'Required' },
                                    {validator(value){
                                        if(document.getElementById("price").value>10000)
                                        {
                                            return Promise.resolve()
                                        }
                                        else
                                            return Promise.reject(new Error('Price must > 10.000 VNĐ'));
                                        
                                        
                                    }},
                                ]}
                                    label="Price (VNĐ)"
                                    className="form__row"
                                >
                                <Input id="price" type="number"  className="form__input" />
                            </Form.Item>

                            <Form.Item
                                name="desc"
                                label="Description"
                                className="form__row"
                                rules={[
                                    { required: true, message: 'Chose at least one category' }                             
                                ]}
                            >
                                
                                <TextArea type="number"  className="form__input"/>
                            </Form.Item>
                            <Form.Item
                                name="pictures"
                                label="Picture"
                                className="form__row"
                                
                                valuePropName= 'files'
                                >
                                        <input type='file' multiple/>
                            </Form.Item>
                            <Form.Item
                                name="isFeatured"
                                label="IsFeatured:"
                                className="form__row"
                                valuePropName= 'checked'

                                >
                                <Checkbox  className="form__input" />
                            </Form.Item>
                            <Form.Item
                                name="status"
                                label="Status:"
                                className="form__row"
                                valuePropName= 'checked'
                                >
                                <Checkbox  className="form__input"/>
                            </Form.Item>
                            <Form.Item
                                name="Id"
                                className="form__row"
                                hidden
                                >
                                <input type="text"defaultValue={product.id}  className="form__input" />
                            </Form.Item>
                            <Form.Item
                                name="CreatedDate"
                                className="form__row"
                                hidden
                                >
                                
                                <input type="text" defaultValue={product.createdDate} className="form__input" />
                            </Form.Item>
                            <Form.Item
                                name="UpdatedDate"
                                className="form__row"
                                hidden
                                >
                                <input type="text" defaultValue={product.updatedDate} className="form__input" />
                            </Form.Item>
                            
                            <Form.Item className="form-btn-login">
                                <Button type="primary" htmlType="submit" className="btn--them text-right btn btn-primary" >
                                    Sửa
                                </Button>
                            </Form.Item>
                    </Form>
        
                        </div>
                    </div>
                </div>)}
            </div>)

      
}

{/* <Checkbox.Group style={{ width: '100%' }} onChange={onChange}>
    <Row>
      <Col span={8}>
        <Checkbox value="A">A</Checkbox>
      </Col>
      <Col span={8}>
        <Checkbox value="B">B</Checkbox>
      </Col>
      <Col span={8}>
        <Checkbox value="C">C</Checkbox>
      </Col>
      <Col span={8}>
        <Checkbox value="D">D</Checkbox>
      </Col>
      <Col span={8}>
        <Checkbox value="E">E</Checkbox>
      </Col>
    </Row>
  </Checkbox.Group> */}