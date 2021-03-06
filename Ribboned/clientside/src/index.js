import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter as Router } from "react-router-dom";
import { Ribboned } from "./components/Ribboned";
import "./index.css";
import firebase from "../node_modules/firebase";
import { UserProfileProvider } from "./providers/UserProfileProvider";
import { CategoryProvider } from "./providers/CategoryProvider";
import { SourceProvider } from "./providers/SourceProvider";
import { RibbonProvider } from "./providers/RibbonProvider";

const firebaseConfig = {
  apiKey: process.env.REACT_APP_FIREBASE_API_KEY,
};
firebase.initializeApp(firebaseConfig);

ReactDOM.render(
  <React.StrictMode>
    <Router>
      <RibbonProvider>
        <SourceProvider>
          <CategoryProvider>
            <UserProfileProvider>
              <Ribboned />
            </UserProfileProvider>
          </CategoryProvider>
        </SourceProvider>
      </RibbonProvider>
    </Router>
  </React.StrictMode>,
  document.getElementById("root")
);
