import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter as Router } from "react-router-dom";
import { Ribboned } from "./components/Ribboned";
import "./index.css";

ReactDOM.render(
  <React.StrictMode>
    <Router>
      <Ribboned />
    </Router>
  </React.StrictMode>,
  document.getElementById("root")
);
