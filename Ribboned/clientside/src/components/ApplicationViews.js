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
      <UserProfileProvider>
        <Route exact path="/login">
          <Login />
        </Route>
      </UserProfileProvider>
      <UserProfileProvider>
        <Route exact path="/register">
          <Register />
        </Route>
      </UserProfileProvider>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/ribbon">
        <RibbonDetail />
      </Route>
    </>
  );
};
