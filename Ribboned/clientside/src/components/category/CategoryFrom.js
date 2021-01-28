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
  // const [category, setCategory] = useState({ name: "", userProfileId: userId });
  const [loading, setLoading] = useState(false);

  const handleInputControl = (event) => {
    const newCategory = { ...category };
    newCategory[event.target.name] = event.target.value;
    setCategory(newCategory);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (category.id) {
      updateCategory(category);
    } else {
      addCategory(category);
    }
    setCategory({ ...category, id: 0, name: "", userProfileId: userId });
  };

  return (
    <div className="col">
      <Card className="card text-white bg-primary mb-3">
        <h2 className="text-white m-3 text-center">Add A New Category</h2>
        <Form onSubmit={handleSubmit}>
          <FormGroup className="m-3">
            <Input
              type="text"
              name="name"
              value={category.name}
              onChange={handleInputControl}
              required
            />
            <FormText>You Cannot Add An Exact Duplicate</FormText>
          </FormGroup>
          <Button className="btn-block" color="dark" disabled={loading}>
            submit
          </Button>
        </Form>
      </Card>
    </div>
  );
};
