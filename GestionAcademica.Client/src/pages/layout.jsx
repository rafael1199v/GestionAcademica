import React, { useEffect } from "react";
import SideBar from "../components/side-bar";
import { useAuth } from "./AuthContext";
import { useNavigate, useLocation } from "react-router-dom";

function Layout({ children }) {
  const { isAuthenticated } = useAuth();
  const navigate = useNavigate();
  const location = useLocation();

  useEffect(() => { 
    if (!isAuthenticated) {
      navigate("/login");
      console.log("ASDASDASD"); 
    };
  }, []);

  const isLoginPage = location.pathname === "/login";

  if (isLoginPage) {
    return <div className="flex-1">{children}</div>;
  }
  
  return (
    <div className="flex min-h-screen">
      <SideBar />
      <div className="flex-1 p-8">{children}</div>
    </div>
  );
}

export default Layout;
