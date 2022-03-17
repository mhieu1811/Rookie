import React, { Component, useEffect, useState } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../../store/Category';
import axios from 'axios';
import { post } from 'jquery';
import {add} from '../../Service/CategoryService'


export default  function AddCategory() {
    function createGuid()  
    {  
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {  
            var r = Math.random()*16|0, v = c === 'x' ? r : (r&0x3|0x8);  
            return v.toString(16);  
        });  
    } 
    // const [listCate,setListCate] =useState();
    // useEffect(async()=>{
    //     const data = await add().then(res=>setListCate(res)) 
    // },[])
    const [cate,setCate]=useState( {
        id: createGuid(),
        CategoryName:"",
        pubished: true,
        createdDate:new Date().toISOString(),
        updatedDate: new Date().toISOString(),
        categoryPicture:"test",
        picture:null
    })
    // console.log(listCate)
    const handleChange = e => {
        const { name, value } = e.target;
        setCate(prevState => ({
            ...prevState,
            [name]: value
        }));
        console.log(cate)

    };
    const handleChangeFile = e =>{
        const { name, files, value } = e.target;
        setCate(prevState => ({
            ...prevState,
            [name]: files[0]
        }));

        setCate(prevState => ({
            ...prevState,
            categoryPicture: value
        }));
        console.log(cate)
    }
    const btnOnClick=async ()=>{
        var bodyFormData = new FormData();
        bodyFormData.append("CategoryName",cate.CategoryName)
        bodyFormData.append("CategoryPicture",cate.categoryPicture)
        bodyFormData.append("Picture",cate.picture)
        bodyFormData.append("CreatedDate",cate.createdDate)
        bodyFormData.append("UpdateDate",cate.updatedDate)
        bodyFormData.append("Pubished",cate.pubished)
        bodyFormData.append("Id",cate.id)
        const response = await add(bodyFormData)
        console.log(bodyFormData)
        // const response = await axios.post("https://localhost:5011/api/Category",cate) 
        // const get = await axios.get("https://localhost:5011/api/Category")
        // console.log(get.data)
    }
    return (
        <div>
            {/* <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Desc</th>
                    </tr>
                </thead>
                <tbody>
                    {props.categories.map(cat =>
                        <tr key={cat.id}>
                            <td>{cat.id}</td>
                            <td>{cat.categoryName}</td>
                            <td>{cat.desc}</td>
                        </tr>
                    )}
                </tbody>
                </table> */}

        <img src={cate.categoryPicture}/>
        <input
            value={cate.categoryName}
            type="text"
            onChange={handleChange}
            name="CategoryName"
        />
       <input
            type="file"
            accept="image/png, image/jpeg"
            onChange={handleChangeFile}
            name="picture"
        />
        <button onClick={btnOnClick}>Confirm Edit</button>
            </div>
     
    );
}