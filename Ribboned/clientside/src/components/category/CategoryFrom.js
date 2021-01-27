import React, { useContext, useEffect } from "react";
import { CategoryContext } from "../../providers/CategoryProvider";
import {
  Form,
  FormGroup,
  Input,
  Button,
  FormText,
  CardTitle,
  Card,
} from "reactstrap";

export const CategoryForm = () => {
  const handleSubmit = (e) => {
    e.prevent.Default();
  };

  return (
    <div className="d-flex justify-content-center" onSubmit={handleSubmit}>
      <Card className="w-50 card text-white bg-primary mb-3">
        <CardTitle>Add A New Category</CardTitle>
        <Form>
          <FormGroup className="m-3">
            <Input />
            <FormText>You Cannot Add An Exact Duplicate</FormText>
          </FormGroup>
          <Button className="btn-block" color="dark">
            submit
          </Button>
        </Form>
      </Card>
    </div>
  );
};
