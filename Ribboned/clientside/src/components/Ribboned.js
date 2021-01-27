import React from "react";
import { NavBar } from "./nav/NavBar";
import { Footer } from "./footer/Footer";
import { ApplicationViews } from "./ApplicationViews";
import "bootswatch/dist/lux/bootstrap.min.css";

export const Ribboned = () => (
  <>
    <NavBar />
    <ApplicationViews />
    <Footer />
  </>
);
