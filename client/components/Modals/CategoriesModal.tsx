import React, { useState } from "react";
import { Modal, Form, Button } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { showModalState } from "../../atoms/atoms";
import addCategory from "../../services/addCategory";
import updateCategory from "../../services/updateCategory";

interface CategoryModalProps {
  data: any;
  isUpdate: boolean;
}

const CategoryModal = ({ data, isUpdate }: CategoryModalProps) => {
  const [categoryName, setCategoryName] = useState("");
  const [show, setShow] = useRecoilState(showModalState);

  const handleClose = () => setShow(false);

  const handleSaveClick = () => {
    isUpdate ? updateCategory() : addCategory({ categoryName });
  };

  return (
    <>
      <Modal.Header closeButton>
        <Modal.Title>{isUpdate ? "Update" : "Add"} Category</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
            <Form.Label>Category name</Form.Label>
            <Form.Control
              type="text"
              autoFocus
              defaultValue={isUpdate ? data.categoryName : ""}
              onChange={(e) => setCategoryName(e.target.value)}
            />
          </Form.Group>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          Close
        </Button>
        <Button variant="primary" onClick={handleSaveClick}>
          Save Changes
        </Button>
      </Modal.Footer>
    </>
  );
};

export default CategoryModal;
