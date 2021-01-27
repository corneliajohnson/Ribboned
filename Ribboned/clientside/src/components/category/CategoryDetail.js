import React, { useContext } from "react";
import { Button } from "reactstrap";
import { CategoryContext } from "../../providers/CategoryProvider";
import { CategoryDelete } from "./CaregoryDelete";

export const CategoryDetail = ({ category }) => {
  const { setCategory } = useContext(CategoryContext);
  return (
    <li href="#" className="list-group-item list-group-item-action">
      <div className="col-8">{category.name} </div>
      <span className="float-right">
        <Button
          className="btn btn-info mx-3"
          onClick={() =>
            setCategory({
              id: category.id,
              name: category.name,
              userProfileId: category.userProfileId,
            })
          }
        >
          Edit
        </Button>
        <CategoryDelete category={category} />
      </span>
    </li>
  );
};
