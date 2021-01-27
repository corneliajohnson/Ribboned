import React, { useState, createContext } from "react";
import firebase from "firebase/app";
import "firebase/auth";

export const SnagContext = createContext();

export const SnagProvider = (props) => {
  const getToken = () => firebase.auth().currentUser.getIdToken();
  const [snags, setSnags] = useState([]);

  const apiUrl = "/api/snag";

  const updateSnag = (snag) => {
    getToken().then((token) => {
      return fetch(`${apiUrl}/${snag.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(snag),
      });
    });
  };

  const addSnag = (snag) => {
    getToken().then((token) => {
      return fetch(apiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(snag),
      });
    });
  };

  const deleteSnag = (id) => {
    getToken().then((token) => {
      return fetch(`/api/snag/${id}`, {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
    });
  };

  const getByRibbonById = (ribbonId) => {
    getToken().then((token) => {
      return fetch(`/api/snag/getbyribbon/${ribbonId}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }).then((res) => res.json());
    });
  };

  return (
    <SnagContext.Provider
      value={{ snags, updateSnag, addSnag, deleteSnag, getByRibbonById }}
    >
      {props.children}
    </SnagContext.Provider>
  );
};
