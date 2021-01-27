import React from "react";
import { CategoryForm } from "./CategoryFrom";
import { CategoryList } from "./CategoryList";

export const CategoryManager = () => {
  return (
    <div className="container">
      <h1 className="text-center">Manage Categories</h1>
      <div className="row">
        {" "}
        <CategoryForm />
        <CategoryList />
      </div>
    </div>
  );
};
