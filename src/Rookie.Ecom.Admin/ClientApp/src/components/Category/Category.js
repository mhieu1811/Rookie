import React, { Component, useState } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link,useHistory } from 'react-router-dom';
import { actionCreators } from '../../store/Category';
import axios from 'axios';
import { post } from 'jquery';

class Category extends Component {
    componentDidMount() {
        // This method is called when the component is first added to the document
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        // This method is called when the route parameters change
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        console.log(this.props.match.params.page);
        const page = parseInt(this.props.match.params.page, 5) || 0;
        console.log(page);
        this.props.requestCategories(page);
    }

    render() {  
        return (
            <div>
                <h1>Weather forecast</h1>
                <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
                {renderCategoryTable(this.props)}
                {renderPagination(this.props)}
            </div>
        );
            }
}

function renderCategoryTable(props) {
    console.log(props);

    //   var temp=[]
    //   useEffect(async()=>{
          
    //        await DiaChi.map((val)=>{
    //          Axios.post("https://rental-apartment-huflit.herokuapp.com/api/customer/getAddressApartment",{id:val.MaDiaChi}).then((respone_1)=>{
    //             temp.push(respone_1.data)
    //        })
           
    //     })
    //     console.log(temp)
    //       setDiaChi_1(temp)
    //   },[DiaChi])
    return (
        <div>
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Desc</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {props.categories.map(cat =>
                        <tr key={cat.id}>
                            <td>{cat.id}</td>
                            <td>{cat.categoryName}</td>
                            <td>{cat.desc}</td>
                            <td><a href={'/editcate/'+cat.id}>Edit</a></td>
                        </tr>
                    )}
                </tbody>
                </table>
            </div>
    );
}

function renderPagination(props) {
    const prevStartDateIndex = (props.page || 0) - 1;
    const nextStartDateIndex = (props.page || 0) + 1;

    return <p className='clearfix text-center'>
        <Link className='btn btn-default pull-left' to={`/category/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/category/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => state.categories,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Category);