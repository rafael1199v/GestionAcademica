import React, { useState } from "react";
import SideBarItem from "./side-bar__item";
import { SIDE_BAR_ITEM } from "../../config/side-bar__item-const";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { useNavigate } from "react-router-dom";
import {
  HomeIcon,
  ArrowLeftIcon,
  FolderPlusIcon,
  InboxArrowDownIcon
} from "@heroicons/react/16/solid";

export function SidebarApplicant() {
  const [selectedItem, setSelectedItem] = useState(SIDE_BAR_ITEM.HOME);
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
            navigateTo="/applicant"
          />
          <SideBarItem
            text="Vacantes"
            isSelected={selectedItem === SIDE_BAR_ITEM.VACANCIES}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.VACANCIES);
            }}
            icon={<FolderPlusIcon className="w-4 h-4" />}
            navigateTo="/applicant/vacancies"
          />
          <SideBarItem
            text="Postulaciones"
            isSelected={selectedItem === SIDE_BAR_ITEM.APPLICATIONS}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.APPLICATIONS);
            }}
            icon={<InboxArrowDownIcon className="w-4 h-4" />}
            navigateTo="/applicant/applications"
          />
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
      </div>
    </div>
  );
}

export default SidebarApplicant;
