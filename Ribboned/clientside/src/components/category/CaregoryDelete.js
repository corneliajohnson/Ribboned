import React, { useState, useContext, useEffect } from "react";
import { CategoryContext } from "../../providers/CategoryProvider";
import { Button, Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

export const CategoryDelete = ({ category }) => {
  const { deleteCategory, getCategories } = useContext(CategoryContext);
  const [pendingDelete, setPendingDelete] = useState(false);

  useEffect(() => {
    getCategories();
  }, [pendingDelete]);

  const handleDelete = () => {
    deleteCategory(category.id);
    setPendingDelete(false);
  };

  return (
    <>
      <Button
        className="btn btn-sm btn-danger"
        onClick={(e) => setPendingDelete(true)}
      >
        Delete
      </Button>
      <Modal isOpen={pendingDelete}>
        <ModalHeader>Delete {category.name}?</ModalHeader>
        <ModalBody>Are you sure you want to delete this category?</ModalBody>
        <ModalFooter>
          <Button onClick={(e) => setPendingDelete(false)}>No, Cancel</Button>
          <Button className="btn btn-outline-danger" onClick={handleDelete}>
            Yes, Delete
          </Button>
        </ModalFooter>
      </Modal>
    </>
  );
};
