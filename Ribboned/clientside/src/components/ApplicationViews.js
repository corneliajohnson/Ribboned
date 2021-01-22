import React from "react";
import { Route } from "react-router-dom";
import { Home } from "./Home";
import { RibbonDetail } from "./Ribbon/RibbonDetail";

export const ApplicationViews = () => {
  return (
    <>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/ribbon">
        <RibbonDetail />
      </Route>
    </>
  );
};
