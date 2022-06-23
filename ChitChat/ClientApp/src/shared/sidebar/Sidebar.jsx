import { useDispatch } from "react-redux";
import { NavLink, useNavigate } from "react-router-dom";
import { Nav, NavItem } from "reactstrap";
import { clearToken } from "../../stores/authentication/authentication.slice";

import './Sidebar.scss';

export function Sidebar() {
    const navigate = useNavigate();
    const dispatch = useDispatch();

    function logout() {
        dispatch(clearToken());
        navigate('/login');
    }

    return (
        <div className="sidebar bg-primary">
            <Nav className="me-auto"
                vertical>
                <NavItem>
                    <NavLink to="/" className='link-dark text-decoration-none'>
                        <h3 className="px-3 py-2"><i className="bi bi-house"></i></h3>
                    </NavLink>
                </NavItem>
                <NavItem>
                    <a href='#' onClick={logout} className='link-dark text-decoration-none'>
                        <h3 className="px-3 py-2"><i className="bi bi-x-lg"></i></h3>
                    </a>
                </NavItem>
            </Nav>
        </div>
    );
}