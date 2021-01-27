import React, { useContext } from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { Home } from "./Home";
import { RibbonDetail } from "./ribbon/RibbonDetail";
import { Login } from "./login/Login";
import { Register } from "./register/Register";
import { UserProfileContext } from "../providers/UserProfileProvider";
import { CategoryManager } from "./category/CategoryManager";

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

      <Route exact path="/categories">
        {isLoggedIn ? <CategoryManager /> : <Redirect to="/login" />}
      </Route>

      <Route exact path="/ribbon">
        {isLoggedIn ? <RibbonDetail /> : <Redirect to="/login" />}
      </Route>
    </Switch>
  );
};
