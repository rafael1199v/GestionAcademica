import React, { useState } from "react";
import SideBarItem from "./side-bar__item";
import { SIDE_BAR_ITEM } from "../../config/side-bar__item-const";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { useNavigate } from "react-router-dom";
import {
  HomeIcon,
  ArrowLeftIcon,
  UsersIcon,
  AcademicCapIcon,
  ClipboardDocumentCheckIcon,
} from "@heroicons/react/16/solid";

export function SideBar() {
  const [selectedItem, setSelectedItem] = useState(SIDE_BAR_ITEM.PROFESSORS);
  const navigate = useNavigate();
  const { setUsersession } = useAuthContext();

  const handleLogOut = async (e) => {
    try {
      localStorage.removeItem('userId');
      localStorage.removeItem('roleId');
      setUsersession(null);
      
      navigate("/login");
    } catch (err) {
      console.log(err.message);
    }
  };

  return (
    <div className="w-64 h-screen flex-col justify-between border-e border-gray-100 bg-white">
      <div className="px-4 py-6">
        <span className="grid h-10 w-32 place-content-center rounded-lg bg-gray-100 text-xs text-gray-600">
          Gestion Academica
        </span>

        <ul className="mt-6 space-y-1">
          <SideBarItem
            text="General"
            isSelected={selectedItem === SIDE_BAR_ITEM.HOME}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.HOME);
            }}
            icon={<HomeIcon className="w-4 h-4" />}
            navigateTo="/"
          />
          <SideBarItem
            text="Docentes"
            isSelected={selectedItem === SIDE_BAR_ITEM.PROFESSORS}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.PROFESSORS);
            }}
            icon={<UsersIcon className="w-4 h-4" />}
            navigateTo="/docentes"
          />
          <SideBarItem
            text="Vacantes"
            isSelected={selectedItem === SIDE_BAR_ITEM.REPORTS}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.REPORTS);
            }}
            icon={<ClipboardDocumentCheckIcon className="w-4 h-4" />}
            navigateTo="/vacancies"
          />
          <SideBarItem
            text="Materias"
            isSelected={selectedItem === SIDE_BAR_ITEM.SUBJECTS}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.SUBJECTS);
            }}
            icon={<AcademicCapIcon className="w-4 h-4" />}
            navigateTo="/materias"
          />
          {/* <SideBarItem
            text="Vacantes"
            isSelected={selectedItem === SIDE_BAR_ITEM.VACANCIES}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.VACANCIES);
            }}
            icon={<FolderPlusIcon className="w-4 h-4" />}
            navigateTo="/vacantes"
          />
          <SideBarItem
            text="Postulaciones"
            isSelected={selectedItem === SIDE_BAR_ITEM.APPLICATIONS}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.APPLICATIONS);
            }}
            icon={<InboxArrowDownIcon className="w-4 h-4" />}
            navigateTo="/postulaciones"
          /> */}
          <SideBarItem
            text="Cerrar sesion"
            isSelected={selectedItem === SIDE_BAR_ITEM.SIGN_OUT}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.HOME);
              handleLogOut();
            }}
            icon={<ArrowLeftIcon className="w-4 h-4" />}
          />
        </ul>
        {/*// TODO: Filter the items based on the user role */}
      </div>
    </div>
  );
}

export default SideBar;
