import React from "react";
import SideBar from "../components/side-bar";
import { useAuth } from "./AuthContext";
import { useNavigate, useLocation } from "react-router-dom";

function Layout({ children }) {
  const { isAuthenticated } = useAuth();
  const navigate = useNavigate();
  const location = useLocation();

  const isLoginPage = location.pathname === "/login";

  if (isLoginPage) {
    return <div className="flex-1">{children}</div>;
  }
  if (!isAuthenticated) {
    navigate("/login");
    return null;
  }

  return (
    <div className="flex min-h-screen">
      <SideBar />
      <div className="flex-1 p-8">{children}</div>
    </div>
  );
}

export default Layout;
