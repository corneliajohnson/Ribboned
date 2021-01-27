import React, { useState, createContext } from "react";
import firebase from "firebase/app";
import "firebase/auth";

export const RibbonContext = createContext();

export const RibbonProvider = (props) => {
  const getToken = () => firebase.auth().currentUser.getIdToken();
  const [ribbons, setRibbons] = useState([]);

  const apiUrl = "/api/ribbon";

  const getUserRibbons = () => {
    const userId = JSON.parse(localStorage.getItem("userProfile")).id;
    getToken().then((token) =>
      fetch(`${apiUrl}/getbyuser/${userId}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((res) => res.json())
        .then((ribbons) => {
          setRibbons(ribbons);
        })
    );
  };

  const updateRibbon = (ribbon) => {
    getToken().then((token) => {
      return fetch(`${apiUrl}/${ribbon.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(ribbon),
      });
    });
  };

  const addRibbon = (ribbon) => {
    getToken().then((token) => {
      return fetch(apiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(ribbon),
      });
    });
  };

  const deleteRibbon = (id) => {
    getToken().then((token) => {
      return fetch(`/api/ribbon/${id}`, {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
    });
  };

  const getRibbonById = (id) => {
    getToken().then((token) => {
      return fetch(`/api/ribbon/${id}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }).then((res) => res.json());
    });
  };

  const searchRibbons = (searchQuery) => {
    getToken().then((token) => {
      fetch(`${apiUrl}/search/${searchQuery}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }).then((res) => res.json());
    });
  };

  return (
    <RibbonContext.Provider
      value={{
        ribbons,
        getUserRibbons,
        updateRibbon,
        addRibbon,
        deleteRibbon,
        searchRibbons,
        getRibbonById,
      }}
    >
      {props.children}
    </RibbonContext.Provider>
  );
};
