import { Navigate } from "react-router-dom"
import { Outlet } from "react-router-dom"

const ProtectedRoute = ({ canActivate, redirectPath = '/' }) => {
    
    if(!canActivate) {
        return <Navigate to={redirectPath} replace/>
    }

    return <Outlet />
}


export default ProtectedRoute
