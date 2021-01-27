import React, { useState, createContext } from "react";
import firebase from "firebase/app";
import "firebase/auth";

export const SourceContext = createContext();

export const SourceProvider = (props) => {
  const getToken = () => firebase.auth().currentUser.getIdToken();
  const [sources, setSources] = useState([]);

  const apiUrl = "/api/source";

  const getSources = () => {
    getToken().then((token) =>
      fetch(`${apiUrl}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((res) => res.json())
        .then((sources) => {
          setSources(sources);
        })
    );
  };

  return (
    <SourceContext.Provider value={{ sources, getSources }}>
      {props.children}
    </SourceContext.Provider>
  );
};
