import React, { useContext } from "react";
import { Button } from "reactstrap";
import { CategoryContext } from "../../providers/CategoryProvider";
import { CategoryDelete } from "./CaregoryDelete";

export const CategoryDetail = ({ category }) => {
  const { setCategory } = useContext(CategoryContext);
  return (
    <>
      <div className="col-lg-3 col-md-4 col-sm-6 m-1 border p-2">
        <h5>{category.name} </h5>
        <span className="float-right">
          <Button
            className="btn btn-sm mx-1"
            color="primary"
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
      </div>
    </>
  );
};
