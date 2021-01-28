import React, { useContext, useEffect } from "react";
import { CategoryContext } from "../../providers/CategoryProvider";
import { CategoryDetail } from "./CategoryDetail";

export const CategoryList = () => {
  const { categories, getCategories } = useContext(CategoryContext);

  //get all user categories
  useEffect(() => {
    getCategories();
  }, []);

  if (!categories) {
    return null;
  }

  return (
    <>
      <h3 className="text-center">All Categories</h3>
      {categories.length === 0 ? (
        <p className="text-center">None</p>
      ) : (
        <div className="row d-flex flex">
          {categories.map((category) => (
            <CategoryDetail key={category.id} category={category} />
          ))}
        </div>
      )}
    </>
  );
};
