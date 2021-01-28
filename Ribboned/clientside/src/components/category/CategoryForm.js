import React, { useContext, useEffect, useState } from "react";
import { CategoryContext } from "../../providers/CategoryProvider";
import { Form, FormGroup, Input, Button, FormText, Card } from "reactstrap";

export const CategoryForm = () => {
  const {
    addCategory,
    category,
    setCategory,
    updateCategory,
    getCategories,
  } = useContext(CategoryContext);
  const userId = JSON.parse(localStorage.getItem("userProfile")).id;
  const [loading, setLoading] = useState(false);

  const handleInputControl = (event) => {
    const newCategory = { ...category };
    newCategory[event.target.name] = event.target.value;
    setCategory(newCategory);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (category.id) {
      category.userProfileId = userId;
      updateCategory(category);
    } else {
      category.userProfileId = userId;
      addCategory(category);
    }
    setCategory({ id: 0, name: "", userProfileId: userId });
  };

  return (
    <div className="col">
      <Card className="card mb-3 shadow-lg bg-white rounded">
        <h2 className="my-2 text-center">Add A New Category</h2>
        <Form onSubmit={handleSubmit}>
          <FormGroup className="m-3">
            <Input
              type="text"
              name="name"
              value={category.name}
              onChange={handleInputControl}
              required="required"
            />
            <FormText>Duplicates will not be displayed.</FormText>
          </FormGroup>
          <Button className="btn-block" color="dark" disabled={loading}>
            submit
          </Button>
        </Form>
      </Card>
    </div>
  );
};
