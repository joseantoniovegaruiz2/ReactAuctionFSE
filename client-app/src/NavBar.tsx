import { NavLink } from 'react-router-dom';
import { Button, Container, Menu } from 'semantic-ui-react';
import React from 'react';


export default function NavBar() {
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} exact to='/' header>
                    <img src='/assets/logo.png' alt='logo' style={{ marginRight: '10px' }} />
                    Bids
                </Menu.Item>
                <Menu.Item as={NavLink} to='/bids' name='Bids' />
                <Menu.Item as={NavLink} to='/errors' name='Errors' />
                <Menu.Item>
                    <Button as={NavLink} to='/createBid' positive content='Create Bid' />
                </Menu.Item>
            </Container>
        </Menu>
    )
}