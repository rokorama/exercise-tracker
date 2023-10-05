import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import './custom.css';
import Login from "./components/Login/Login"
import useToken from "./useToken";

export default class App extends Component {
  static displayName = App.name;

  render() {
    const { token, setToken } = useToken();

    if (!token) {
      return <Login setToken={setToken} />
    }
    
      return (
       <Layout>
         <Routes>
           {AppRoutes.map((route, index) => {
             const { element, ...rest } = route;
             return <Route key={index} {...rest} element={element} />;
           })}
        </Routes>
       </Layout>
      )}
}