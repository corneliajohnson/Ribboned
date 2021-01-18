import React from "react";
import { Link } from "react-router-dom";
import "./NavBar.css";

export const NavBar = (props) => {
  return (
    <nav>
      <ul className="navbar">
        <li className="navbar__item active">
          <Link className="navbar__link" to="/">
            Account
          </Link>
        </li>
        <li className="navbar__item">
          <Link className="navbar__link" to="/create/ribbon">
            Add Ribbon
          </Link>
        </li>
        <li className="navbar__item">
          <Link className="navbar__link" to="/ribbons">
            My Ribbons
          </Link>
        </li>
        <li className="navbar__item">
          <Link className="navbar__link" to="/login">
            Log Out
          </Link>
        </li>
      </ul>
    </nav>
  );
};
