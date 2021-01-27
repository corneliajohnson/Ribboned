import React, { useContext } from "react";
import { Button } from "reactstrap";
import { CategoryContext } from "../../providers/CategoryProvider";

export const CategoryDetail = ({ category }) => {
  const { setCategory } = useContext(CategoryContext);
  return (
    <li href="#" className="list-group-item list-group-item-action">
      {category.name}{" "}
      <span className="float-righ">
        <Button
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
      </span>
    </li>
  );
};
