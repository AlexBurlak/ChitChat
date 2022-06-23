import React, { Component } from 'react';
import { Route, Routes } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { LoginForm } from './components/LoginForm/LoginForm';
import PrivateRoute from './hooks/PrivateRoute';

import './custom.scss'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Routes>
          <Route index path='/' element={
            <PrivateRoute>
              <Home />
            </PrivateRoute>
          } />
          <Route path='/counter' element={
            <PrivateRoute>
              <Counter />
            </PrivateRoute>
          }/>
          <Route path='/login' element={<LoginForm />} />
        </Routes>
      </Layout>
    );
  }
}
