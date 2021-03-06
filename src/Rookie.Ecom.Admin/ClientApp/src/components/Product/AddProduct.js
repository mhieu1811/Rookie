import React, { Component, useEffect, useState } from 'react';
 import { Form, Input, Button,Select, DatePicker,Checkbox, InputNumber, Space, Skeleton,Upload ,notification,UploadOutlined} from 'antd';
// import CurrencyInput from 'react-currency-input-field';
import moment from 'moment';
import { get } from 'jquery';
import {  getList, getListcate } from '../../Service/CategoryService';
import { add,editpro } from '../../Service/ProductService';
import {Redirect} from 'react-router-dom'
import FormItem from 'antd/lib/form/FormItem';
import TextArea from 'antd/lib/input/TextArea';
// import "./AddProduct.css"
export default  function AddProduct() {
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

    const[pic,setPicture]=useState([])


    useEffect(()=>{
        
        getListcate().then(res=>setCate(res))
        console.log(cate)
    },[])

      const onFinishFailed = (errorInfo) => {
          
        console.log('Failed:', errorInfo);
      };

      const [status, setStatus]=useState(false);
    const onFinish = async (values) => {
        values.Id=createGuid();
        values.CreatedDate =new Date().toISOString();
        values.UpdatedDate = new Date().toISOString();
        values.Status =true;
        console.log(values)
        var bodyFormData = new FormData();
        for ( var key in values ) {
            if(key!="Picture"&& key!="Cate"){
                bodyFormData.append(key, values[key]);
            }
        }
        for(var x = 0; x < values.Picture.fileList.length; x++) {
            // the name has to be 'files' so that .NET could properly bind it
            console.log( values.Picture.fileList[x].originFileObj)
            bodyFormData.append('Picture', values.Picture.fileList[x].originFileObj);    
        }
        for(var x = 0; x < values.Cate.length; x++) {
            // the name has to be 'files' so that .NET could properly bind it
            bodyFormData.append('Cate', values.Cate[x]);    
        }

        console.log(bodyFormData.data)
        const res =await add(bodyFormData)
        console.log(res.status)
        if(res.status==201){
            openNotificationWithIcon('success','Add Product Success','Done')           
            form.resetFields();        // <Redirect to="/" />
        }else{
            openNotificationWithIcon('error','Add Product Failed','Please try again')           
        }
      };

      const openNotificationWithIcon = (type,title,desc) => {
        notification[type]({
          message: title,
          description:
           desc,
        });
      };
        return (

            <div style={{marginTop:'30px'}}>
                
                <h1 style={{textAlign:'center',fontWeight:'bold',textTransform:'uppercase'}}>Add Product</h1>
                <div className="container">
                    <div className="row">
                        {/* <div className="col-lg-3">
                            <div className="col--detail--1">
                            <img src={pic[0]}  /> */}
                            {/* <h1>Select Image</h1> */}
                            {/* <input type="file" name="myImage" onChange={handleFileInput} style={{marginTop:'10px',cursor: 'pointer'}} /> */}
                            {/* <p>N???u kh??ng th??m h??nh, th?? s??? l???y ???nh default</p>
                            </div>
                        </div> */}
                        <div className="col-lg-8 ">
                        <Form 
                            form={form}
                                onFinish={onFinish}
                            onFinishFailed={onFinishFailed}
                            className="col-lg-8-detalis"
                        >
                            {/* <FormItem>
                                <Upload
                                    action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                                    listType="picture-card"
                                    fileList={fileList}
                                    onPreview={this.handlePreview}
                                    onChange={this.handleChange}
                                    >
                                    {fileList.length >= 8 ? null : uploadButton}
                                </Upload>
                                <Modal
                                visible={previewVisible}
                                title={previewTitle}
                                footer={null}
                                onCancel={this.handleCancel}
                                >
                                <img alt="example" style={{ width: '100%' }} src={previewImage} />
                                </Modal>
        
                            </FormItem> */}
                            <Form.Item
                                name="ProductName"
                                rules={[
                                    { required: true, message: 'Kh??ng ???????c b??? tr???ng t??n voucher' },
                                ]}
                                label="Product Name: "
                                className="form__row"
                            >
                                <Input  placeholder="Product Name ..."/>
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
                                        { required: true, message: 'Chose at least one category' },
                                    ]}
                                label="Catgory"
                                className="form__row"
                            >
                            {cate.length===0?<Skeleton/>:
                                <Checkbox.Group>
                                    <Space wrap >
                                        {
                                            cate.map((val)=>{
                                            return <Checkbox key={val.id} value={val.id}>{val.categoryName}</Checkbox>
                                        })}
                                    </Space>
                                </Checkbox.Group>}   
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
                                            return Promise.reject(new Error('Price must > 10.000 VN??'));
                                        
                                        
                                    }},
                                ]}
                                    label="Price (VN??)"
                                    className="form__row"
                                >
                                <Input id="price" type="number"  className="form__input" />
                            </Form.Item>
                            <Form.Item
                                name="Desc"
                                label="Description"
                                className="form__row"
                                rules={[
                                    { required: true, message: 'Chose at least one category' }                             
                                ]}
                            >
                                
                                <TextArea type="number" className="form__input"/>
                            </Form.Item>
                            <Form.Item
                                name="Picture"
                                label="Picture"
                                className="form__row"
                                rules={[
                                    { required: true, message: 'Chose at least one category' }                             
                                ]}
                                valuePropName= 'files'
                                >
                                        <Upload
                                             action= 'https://www.mocky.io/v2/5cc8019d300000980a055e76'
                                            //  onChange = {handleChange}
                                            accept="image/png, image/jpeg"                                             
                                            multiple = {true}
                                        >
                                             <Button > Upload</Button>
                                        </Upload>  
                                        {/* <input type='file'/> */}
                            </Form.Item>
                            <Form.Item
                                name="IsFeatured"
                                label="IsFeatured:"
                                className="form__row"
                                valuePropName= 'checked'

                                >
                                <input type="checkbox"  className="form__input" />
                            </Form.Item>
                            <Form.Item
                                name="Id"
                                className="form__row"
                                hidden
                                >
                                <input type="text"  className="form__input" />
                            </Form.Item>
                            <Form.Item
                                name="CreatedDate"
                                className="form__row"
                                hidden
                                >
                                <input type="text"  className="form__input" />
                            </Form.Item>
                            <Form.Item
                                name="UpdatedDate"
                                className="form__row"
                                hidden
                                >
                                <input type="text"  className="form__input" />
                            </Form.Item>
                            <Form.Item
                                name="Status"
                                className="form__row"
                                hidden
                                >
                                <input type="text"  className="form__input" onChange={(e)=>console.log(e.target.value)} />
                            </Form.Item>
                            <Form.Item className="form-btn-login">
                                <Button type="primary" htmlType="submit" className="btn--them text-right btn btn-primary" >
                                    Th??m
                                </Button>
                            </Form.Item>
                    </Form>
        
                        </div>
                    </div>
                </div>
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