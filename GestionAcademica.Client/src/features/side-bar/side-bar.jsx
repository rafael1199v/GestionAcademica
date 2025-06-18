import React, { useState, useEffect } from "react";
import { ROLES } from "../../config/role-const";
import SideBarItem from "./components/side-bar__item";
import { SIDE_BAR_ITEM } from "../../config/side-bar__item-const";
import { useAuthContext } from "../../hooks/UseAuthContext";
import { useNavigate } from "react-router-dom";
import {
  HomeIcon,
  ArrowLeftIcon,
  UsersIcon,
  AcademicCapIcon,
  ClipboardDocumentCheckIcon,
  InboxArrowDownIcon,
} from "@heroicons/react/16/solid";
import { getRoleLink } from "../../services/AuthService";

export function SideBar() {
  const [selectedItem, setSelectedItem] = useState(SIDE_BAR_ITEM.HOME);
  const navigate = useNavigate();
  const { setUsersession } = useAuthContext();
  const { userSession } = useAuthContext();

  const handleLogOut = async (e) => {
    try {
      localStorage.removeItem("userId");
      localStorage.removeItem("roleId");
      setUsersession(null);

      navigate("/login");
    } catch (err) {
      console.log(err.message);
    }
  };

  const role = getRoleLink(userSession.roleId);

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
            navigateTo={role == "" ? "/" : role}
          />
          <SideBarItem
            text="Docentes"
            isSelected={selectedItem === SIDE_BAR_ITEM.PROFESSORS}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.PROFESSORS);
            }}
            icon={<UsersIcon className="w-4 h-4" />}
            navigateTo={role+"/professors"}
          />
          {userSession.userId == ROLES.ADMIN && (
          <SideBarItem
            text="Materias"
            isSelected={selectedItem === SIDE_BAR_ITEM.SUBJECTS}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.SUBJECTS);
            }}
            icon={<AcademicCapIcon className="w-4 h-4" />}
            navigateTo="/subjects"
          />)}
          {userSession.roleId != ROLES.STUDENT && (
          <SideBarItem
            text="Postulaciones"
            isSelected={selectedItem === SIDE_BAR_ITEM.APPLICATIONS}
            onClick={() => {
              setSelectedItem(SIDE_BAR_ITEM.APPLICATIONS);
            }}
            icon={<InboxArrowDownIcon className="w-4 h-4" />}
            navigateTo={role+"/applications"}
          />)}
          {userSession.roleId != ROLES.HR && (
            <SideBarItem
              text="Vacantes"
              isSelected={selectedItem === SIDE_BAR_ITEM.REPORTS}
              onClick={() => {
                setSelectedItem(SIDE_BAR_ITEM.REPORTS);
              }}
              icon={<ClipboardDocumentCheckIcon className="w-4 h-4" />}
              navigateTo={role == "" ? "/vacancies" : role + "/vacancies"}
            />
          )}
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

export default SideBar;
