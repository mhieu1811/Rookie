import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../../store/Product';

class Product extends Component {
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
        this.props.requestProducts(page);
    }

    render() {  
        const { user, products} = this.props;               

        return (
            <div>
                {(user !== null && user.profile['Role']==='Admin')?(
                    <div>
                        <h1>Product</h1>
                        <Link to="/addpro">Add Category</Link>
                        {renderProductTable(products)}
                        {renderPagination(products)}
                        
                    </div>
                    ):(
                        <h1>Please Login</h1>
                        )}
            </div>
        );
            }
}

function renderProductTable(props) {
    console.log(props);
    return (
        <div>
            <table className='table table-striped'>
                <thead>
                    <tr>
                        <th>Picture</th>
                        <th>Name</th>
                        <th>Desc</th>
                        <th>Price</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {props.products.map(pro =>
                        <tr key={pro.id}>
                            <td><img src={`https://localhost:5011/Picture/${pro.productPictures[0].pictureUrl}`} style={{height:"30px"}}></img></td>
                            <td>{pro.productName}</td>
                            <td>{pro.quantity}</td>
                            <td>{pro.price.toLocaleString('it-IT', {style : 'currency', currency : 'VND'})}</td>
                            <td><a href={'/editpro/'+pro.id}>Edit</a></td>
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
        <Link className='btn btn-default pull-left' to={`/product/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/product/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => ({ products: state.products, user: state.oidc.user, isAuthenticated: state.oidc.user && !state.oidc.user.expired}),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Product);