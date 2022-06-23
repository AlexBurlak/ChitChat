import React from 'react';
import { Container, Col, Row } from 'reactstrap';
import { useSelector } from 'react-redux';
import { Sidebar } from '../shared/sidebar/Sidebar';
import { Chatbar } from '../shared/chatbar/Chatbar';

import './Layout.scss';

export function Layout(props) {
  const logged = useSelector(state => state.authentication.isLogged);

  return (
    <div className='layout'>
      { logged && <Sidebar/> }
      { logged && <Chatbar/> }
      <Container>
        {props.children}
      </Container>
    </div>
  );
}
