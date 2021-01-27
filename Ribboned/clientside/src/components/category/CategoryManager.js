import React from "react";
import { CategoryForm } from "./CategoryFrom";
import { CategoryList } from "./CategoryList";

export const CategoryManager = () => {
  return (
    <div className="container">
      <h1>CategoryManager</h1>
      <CategoryForm />
      <CategoryList />
    </div>
  );
};
