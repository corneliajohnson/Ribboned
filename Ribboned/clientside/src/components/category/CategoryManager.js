import React from "react";
import { CategoryForm } from "./CategoryForm";
import { CategoryList } from "./CategoryList";
import { Link } from "react-router-dom";
import Logo from "../../img/RibbonedWordOnly.png";

export const CategoryManager = () => {
  return (
    <div className="container my-5">
      <Link className="m-5" to="/account">
        <img alt="ribboned logo" src={Logo} />
      </Link>
      <h1 className="text-center mt-4">Manage Categories</h1>
      <div className="row">
        {" "}
        <div className="col-lg-4 col-sm-12 mt-5">
          <CategoryForm />
        </div>
        <div className="col-lg-8 col-sm-12 mt-3">
          <CategoryList />
        </div>
      </div>
    </div>
  );
};
