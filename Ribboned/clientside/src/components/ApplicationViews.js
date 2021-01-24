import React, { useContext } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { Home } from "./Home";
import { RibbonDetail } from "./Ribbon/RibbonDetail";
import { Login } from "./login/Login";
import { Register } from "./register/Register";
import { UserProfileContext } from "../providers/UserProfileProvider";

export const ApplicationViews = () => {
  const { isLoggedIn } = useContext(UserProfileContext);
  return (
    <Switch>
      <Route exact path="/login">
        <Login />
      </Route>
      <Route exact path="/register">
        <Register />
      </Route>

      <Route exact path="/">
        {isLoggedIn ? <Home /> : <Redirect to="/login" />}
      </Route>

      <Route exact path="/ribbon">
        {isLoggedIn ? <RibbonDetail /> : <Redirect to="/login" />}
      </Route>
    </Switch>
  );
};
