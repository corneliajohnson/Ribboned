import React from "react";
import { Link } from "react-router-dom";
import "./NavBar.css";
import Logo from "../../img/RibbonedWordOnly.png";
import { List } from "reactstrap";

export const NavBar = (props) => {
  return (
    <nav>
      <List className="navbar">
        <li className="navbar__item active fixed-top">
          <Link className="navbar__link" to="/account m-5">
            Account
          </Link>
        </li>
        <li className="navbar__item fixed-top">
          <Link className="navbar__link" to="/account">
            <img className="logo" alt="ribboned logo" src={Logo} />
          </Link>
        </li>
        <li className="navbar__item nav__addribbonlink">
          <Link className="navbar__link" to="/create/ribbon">
            Add Ribbon
          </Link>
        </li>
        <li className="navbar__item nav__ribbonlink">
          <Link className="navbar__link" to="/ribbons">
            My Ribbons
          </Link>
        </li>
        <li className="navbar__item fixed-bottom">
          <Link className="navbar__link" to="/login">
            Log Out
          </Link>
        </li>
      </List>
    </nav>
  );
};
