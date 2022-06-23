import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Button, Col, Form, FormGroup, Input, Label, Row } from 'reactstrap';
import { setToken } from '../../stores/authentication/authentication.slice';

import './LoginForm.scss';

export function LoginForm() {
    const isLogged = useSelector(state => state.authentication.isLogged);
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const [state, setState] = useState({
        email: '',
        password: ''
    });

    function handleInputChange(event) {
        event.preventDefault();
        const target = event.target;
        setState({
            ...state,
            [target.name]: target.value,
        });
    };

    function handleSubmit(event) {
        event.preventDefault();
        dispatch(setToken(state.email));
        navigate('/');
    };

    useEffect(() => {
        if (isLogged) {
            navigate('/');
        }
    }, [isLogged, navigate]);

    return (
        <Row className='login-form'>
            <div className='col-6 bg-dark mx-auto px-5 py-5 ' style={{borderRadius: "15px"}}>
                <h2 className='text-center text-light '>Login</h2>
                <Form onSubmit={handleSubmit}>
                    <FormGroup className='mb-3'>
                        <Label for='email'>Email</Label>
                        <Input type='email'
                               value={state.email}
                               onChange={handleInputChange} 
                               name='email'
                               className='text-dark'/>
                    </FormGroup>
                    <FormGroup className='mb-3'>
                        <Label for='password'>Password</Label>
                        <Input type='password' 
                               value={state.password} 
                               onChange={handleInputChange} 
                               name='password'
                               className='text-dark'/>
                    </FormGroup>
                    <Col className='d-flex justify-content-between'>
                        <Button color="primary" type='submit'>Login</Button>
                        <a href={'/register'} className='text-end text-primary'>Register</a>
                    </Col>
                </Form>
            </div>
        </Row>
    );
}