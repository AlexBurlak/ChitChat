import { useSelector } from "react-redux";
import { Navigate, useLocation } from 'react-router-dom';

const PrivateRoute = ({children}) => {
    let location = useLocation();

    const isAuthenticated = useSelector(state => state.authentication.isLogged);

    if (!isAuthenticated) {
        return <Navigate to='/login' state={{from: location}} />;
    }

    return children;
};

export default PrivateRoute;