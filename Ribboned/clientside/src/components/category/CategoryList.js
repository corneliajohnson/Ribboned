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
    <div class="list-group">
      <li href="#" class="list-group-item list-group-item-action active">
        All Categories
      </li>
      {categories.length === 0 ? (
        <li className="list-group-item list-group-item-action">None</li>
      ) : (
        categories.map((category) => (
          <CategoryDetail key={category.id} category={category} />
        ))
      )}
    </div>
  );
};
