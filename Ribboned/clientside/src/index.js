import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter as Router } from "react-router-dom";
import { Ribboned } from "./components/Ribboned";
import "./index.css";
import firebase from "../node_modules/firebase";
import { UserProfileProvider } from "./providers/UserProfileProvider";

const firebaseConfig = {
  apiKey: process.env.REACT_APP_FIREBASE_API_KEY,
};
firebase.initializeApp(firebaseConfig);

ReactDOM.render(
  <React.StrictMode>
    <Router>
      <UserProfileProvider>
        <Ribboned />
      </UserProfileProvider>
    </Router>
  </React.StrictMode>,
  document.getElementById("root")
);
