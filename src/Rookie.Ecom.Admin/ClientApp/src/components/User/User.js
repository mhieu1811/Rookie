import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { actionCreators } from '../../store/User';

class User extends Component {
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
        this.props.requestUsers(page);
    }

    render() {
        const { user, users} = this.props;               
  
        return (

            <div>
               {(user !== null && user.profile['Role']==='Admin')?(
                       <div>
                        <h1>UpdatedDate</h1>
                        {renderProductTable(users)}
                        {renderPagination(users)}
                        
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
                        <th>Id</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email</th>
                        <th>Phone Number</th>
                    </tr>
                </thead>
                <tbody>
                    {props.users.map(pro =>
                        <tr key={pro.id}>
                            <td>{pro.id}</td>
                            <td>{pro.firstName}</td>
                            <td>{pro.lastName}</td>
                            <td>{pro.email}</td>
                            <td>{pro.phoneNumber}</td>

                        </tr>
                    )}
                </tbody>
                </table>
            </div>
    );
}

function renderPagination(props) {
    const prevStartDateIndex = (props.page || 0) - 5;
    const nextStartDateIndex = (props.page || 0) + 5;

    return <p className='clearfix text-center'>
        <Link className='btn btn-default pull-left' to={`/product/${prevStartDateIndex}`}>Previous</Link>
        <Link className='btn btn-default pull-right' to={`/product/${nextStartDateIndex}`}>Next</Link>
        {props.isLoading ? <span>Loading...</span> : []}
    </p>;
}

export default connect(
    state => ({ users: state.users, user: state.oidc.user, isAuthenticated: state.oidc.user && !state.oidc.user.expired}),
    dispatch => bindActionCreators(actionCreators, dispatch)
)(User);