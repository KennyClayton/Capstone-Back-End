import { useState } from "react";
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
} from "reactstrap";
import DudeWorkItLogo from "./DudeWorkIt.png";
import "./auth/Login.css";

import { logout } from "../managers/authManager";

export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);

  // const toggleNavbar = () => setOpen(!open);

  return (
    <div>
      <Navbar color="info" light fixed="true" expand="lg">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
          {/* 📚 👷 DudeWorkIt 🔨 🎓  */}
          <div className="logo-container">
            <img src={DudeWorkItLogo} alt="Logo" className="sizeDownLogo" />
          </div>
        </NavbarBrand>
        {loggedInUser ? (
          <>
            {/* <NavbarToggler onClick={toggleNavbar} /> */}
            <Collapse isOpen={open} navbar>
              <Nav navbar></Nav>
            </Collapse>
            <Button
              color="light"
              outline
              size="md"
              onClick={(e) => {
                e.preventDefault();
                setOpen(false);
                logout().then(() => {
                  setLoggedInUser(null);
                  setOpen(false);
                });
              }}
            >
              Logout
            </Button>
          </>
        ) : (
          <Nav navbar>
            <NavItem>
              <NavLink tag={RRNavLink} to="/login">
                <Button color="primary">Login</Button>
              </NavLink>
            </NavItem>
          </Nav>
        )}
      </Navbar>
    </div>
  );
}

//$ Note that we conditionally rendered the nav bar based on whether they are a loggedinUser (line 26)
