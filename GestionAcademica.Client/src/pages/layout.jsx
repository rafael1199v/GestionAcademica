import { Outlet } from "react-router-dom";
import SideBar from "../features/side-bar/side-bar";

function Layout() {
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
