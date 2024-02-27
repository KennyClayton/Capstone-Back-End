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

// if (!loggedInUser) {
//   return null;
// }

  return (
    <div>
      <Navbar color="info" light fixed="true" expand="lg">
        {/* The NavbarBrand element is only affecting the left side of my Nav bar*/}
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
          <div className="logo-container">
            <img src={DudeWorkItLogo} alt="Logo" className="sizeDownLogo" />
          </div>
          {loggedInUser ? (
            <span style={{ marginLeft: "20px" }}>
              Welcome, {loggedInUser.fullName}
            </span>
          ) : null}
        </NavbarBrand>

        {loggedInUser ? (
          <>
            {/* <NavbarToggler onClick={toggleNavbar} /> */}
            {/* <Collapse isOpen={open} navbar>
              <Nav navbar></Nav>
            </Collapse> */}
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
        ) 
        // this ternary colon below says if the above loggedInUser (line 39 or so) is falsey, meaning no one is logged in...then do the next piece of code here below
        : 
        (
          null
          // <Nav navbar>
          //   <NavItem>
          //     <NavLink tag={RRNavLink} to="/login">
          //       <Button color="primary">Login</Button>
          //     </NavLink>
          //   </NavItem>
          // </Nav>
        )
        }
      </Navbar>
    </div>
  );
}

//$ Note that we conditionally rendered the nav bar based on whether they are a loggedinUser (line 26)
