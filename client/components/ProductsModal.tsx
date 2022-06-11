import React, { useState } from "react";
import { Modal, Form, Button } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { showModalState } from "../atoms/atoms";
import addProduct from "../services/addProduct";
import updateProduct from "../services/updateProduct";

interface ProductModalProps {
  data: any;
  isUpdate: boolean;
}

const ProductModal = ({ data, isUpdate }: ProductModalProps) => {
  const [name, setName] = useState("");
  const [description, setDescription] = useState("");
  const [price, setPrice] = useState("");
  const [discount, setDiscount] = useState("");
  const [isAvailable, setIsAvailable] = useState(false);
  const [image, setImage] = useState("");
  const [, setShow] = useRecoilState(showModalState);

  const handleClose = () => setShow(false);

  const handleSaveClick = () => {
    isUpdate
      ? updateProduct()
      : addProduct({
          name,
          description,
          image,
          price: Number(price),
          discount: Number(discount),
          isAvailable,
        });
  };

  return (
    <>
      <Modal.Header closeButton>
        <Modal.Title>{isUpdate ? "Update" : "Add"} Product</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
            <Form.Label>Name</Form.Label>
            <Form.Control
              type="text"
              autoFocus
              defaultValue={isUpdate ? data.name : ""}
              onChange={(e) => setName(e.target.value)}
            />
            <Form.Label>Description</Form.Label>
            <Form.Control
              type="text"
              defaultValue={isUpdate ? data.description : ""}
              onChange={(e) => setDescription(e.target.value)}
            />
            <Form.Label>Price </Form.Label>
            <Form.Control
              type="number"
              defaultValue={isUpdate ? data.price : ""}
              onChange={(e) => setPrice(e.target.value)}
            />
            <Form.Label>Discount</Form.Label>
            <Form.Control
              type="number"
              defaultValue={isUpdate ? data.discount : ""}
              onChange={(e) => setDiscount(e.target.value)}
            />
            <Form.Label>Available</Form.Label>
            <Form.Check
              type={"checkbox"}
              label={"Is Available"}
              id={"default-checkbox"}
              checked={isUpdate ? data.isAvailable : false}
              onChange={() => setIsAvailable(!isAvailable)}
            />
            <Form.Label>Product image</Form.Label>
            <Form.Control
              type="text"
              defaultValue={isUpdate ? data.image : ""}
              onChange={(e) => setImage(e.target.value)}
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

export default ProductModal;
