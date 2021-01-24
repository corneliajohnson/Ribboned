import React from "react";
import { Route } from "react-router-dom";
import { Home } from "./Home";
import { RibbonDetail } from "./Ribbon/RibbonDetail";
import { Login } from "./login/Login";
import { UserProfileProvider } from "../providers/UserProfileProvider";
import { Register } from "./register/Register";

export const ApplicationViews = () => {
  return (
    <>
      <Route exact path="/login">
        <Login />
      </Route>
      <Route exact path="/register">
        <Register />
      </Route>

      <Route exact path="/">
        <Home />
      </Route>

      <Route exact path="/ribbon">
        <RibbonDetail />
      </Route>
    </>
  );
};
