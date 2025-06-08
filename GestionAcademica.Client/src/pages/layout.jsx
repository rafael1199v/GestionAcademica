import { Outlet } from "react-router-dom";
import SideBar from "../components/side-bar";

function Layout({ children }) {
  return (
    <div className="flex min-h-screen">
      <SideBar />
      <div className="flex-1 p-8">
        <Outlet />
      </div>
    </div>
  );
}

export default Layout;
