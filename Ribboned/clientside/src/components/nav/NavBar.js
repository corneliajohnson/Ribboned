import React, { useContext } from "react";
import { Link, useHistory } from "react-router-dom";
import "./NavBar.css";
import Logo from "../../img/RibbonedWordOnly.png";
import { List, NavLink } from "reactstrap";
import { UserProfileContext } from "../../providers/UserProfileProvider";

export const NavBar = (props) => {
  const { getCurrentUser, logout } = useContext(UserProfileContext);
  const user = getCurrentUser();
  const history = useHistory();

  const logoutAndReturn = () => {
    return logout().then(() => {
      history.push("/login");
    });
  };

  return (
    <>
      {user ? (
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
            <li className="navbar__item fixed-bottom ml-2 mb-5">
              <NavLink className="navbar__link" onClick={logoutAndReturn}>
                Log Out
              </NavLink>
            </li>
          </List>
        </nav>
      ) : (
        ""
      )}
    </>
  );
};
