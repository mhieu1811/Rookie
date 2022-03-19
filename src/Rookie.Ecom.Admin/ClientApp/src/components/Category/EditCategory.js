import React, { Component, useEffect, useState } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../../store/Category';
import axios from 'axios';
import { post } from 'jquery';
import { add, edit, getobject } from '../../Service/CategoryService'
import { Button, Image, notification } from 'antd';
import { Input,Label } from 'antd';
import './Category.css'

export default function EditCategory(props) {
    const { id } = props.match.params;
    const [listCate, setListCate] = useState();
    const [cate, setCate] = useState({
        id: "",
        categoryName: "",
        pubished: true,
        createdDate: new Date().toISOString(),
        updatedDate: new Date().toISOString(),
        categoryPicture: "",
        Picture: null
    })
    useEffect(() => {
        const data = getobject(id).then(res => setCate(res))
    }, [])
    // console.log(listCate)
    const handleChange = e => {
        const { name, value } = e.target;
        setCate(prevState => ({
            ...prevState,
            [name]: value
        }));
        console.log(cate)

    };

    const handleChangeFile = e => {
        const { name, files, value } = e.target;
        setCate(prevState => ({
            ...prevState,
            [name]: files[0]
        }));

        // setCate(prevState => ({
        //     ...prevState,
        //     categoryPicture: value
        // }));
        console.log(cate)
    }
    const openNotificationWithIcon = (type, title, desc) => {
        notification[type]({
            message: title,
            description:
                desc,
        });
    };
    const btnOnClick = async () => {
        console.log(cate)
        var bodyFormData = new FormData();
        bodyFormData.append("CategoryName", cate.categoryName)
        bodyFormData.append("CategoryPicture", cate.categoryPicture)
        bodyFormData.append("Picture", cate.Picture)
        bodyFormData.append("CreatedDate", cate.createdDate)
        bodyFormData.append("UpdateDate", new Date().toISOString())
        bodyFormData.append("Pubished", cate.pubished)
        bodyFormData.append("Id", cate.id)
        const response = await edit(bodyFormData)
        console.log(response)

        if (response.status == 204) {
            openNotificationWithIcon('success', 'Add Product Success', 'Done')
        } else {
            openNotificationWithIcon('error', 'Add Product Failed', 'Please try again')
        }
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
            <h1 className='text-center'>Edit Category</h1>
            <div className='edit-product-left'>
                <Image src={"https://localhost:5011/Picture/" + cate.categoryPicture} height={150} />

            </div>
            <div className='edit-product-right'>
                <div className='edit-product-right-group'>
                    <label for='categoryName' className="edit-product-right-group-label">Picture</label>
                    <Input
                        value={cate.categoryName}
                        type="text"
                        onChange={handleChange}
                        name="categoryName"
                        className="edit-product-right-group-input"
                    />

                </div>
                <div className='edit-product-right-group'>
                    <label for='Picture' className="edit-product-right-group-label">Picture</label>
                    <Input
                        type="file"
                        accept="image/png, image/jpeg"
                        onChange={handleChangeFile}
                        name="Picture"
                        className="edit-product-right-group-input"
                    />
                </div>
                <Button onClick={btnOnClick}>Edit</Button>
            </div>
            <div className='clear'></div>
        </div>
    );
}