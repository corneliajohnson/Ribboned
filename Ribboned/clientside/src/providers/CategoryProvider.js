import React, { useState, createContext } from "react";
import firebase from "firebase/app";
import "firebase/auth";

export const CategoryContext = createContext();

export const CategoryProvider = (props) => {
  const getToken = () => firebase.auth().currentUser.getIdToken();
  const [categories, setCategories] = useState([]);
  const [category, setCategory] = useState({});
  const apiUrl = "/api/category";

  const getCategories = () => {
    const userId = JSON.parse(localStorage.getItem("userProfile")).id;
    getToken().then((token) =>
      fetch(`${apiUrl}/getbyuserid/${userId}`, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
        .then((res) => res.json())
        .then((categories) => {
          setCategories(categories);
        })
    );
  };

  const updateCategory = (category) => {
    getToken().then((token) => {
      return fetch(`${apiUrl}/${category.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(category),
      });
    });
  };

  const addCategory = (category) => {
    getToken().then((token) => {
      return fetch(apiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify(category),
      });
    });
  };

  const deleteCategory = (id) => {
    getToken().then((token) => {
      return fetch(`/api/category/${id}`, {
        method: "DELETE",
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
    });
  };

  return (
    <CategoryContext.Provider
      value={{
        categories,
        getCategories,
        updateCategory,
        addCategory,
        deleteCategory,
        setCategory,
        category,
      }}
    >
      {props.children}
    </CategoryContext.Provider>
  );
};
