import React, { useState } from "react";
import { Modal, Form, Button } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { showModalState } from "../atoms/atoms";
import addBrand from "../services/addBrand";
import updateBrand from "../services/updateBrand";

interface BrandModalProps {
  data: any;
  isUpdate: boolean;
}

const BrandModal = ({ data, isUpdate }: BrandModalProps) => {
  const [brandName, setBrandName] = useState("");
  const [brandImage, setBrandImage] = useState("");
  const [show, setShow] = useRecoilState(showModalState);

  const handleClose = () => setShow(false);

  const handleSaveClick = () => {
    isUpdate ? updateBrand() : addBrand({ brandName, image: brandImage });
  };

  return (
    <>
      <Modal.Header closeButton>
        <Modal.Title>{isUpdate ? "Update" : "Add"} Brand</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
            <Form.Label>Brand name</Form.Label>
            <Form.Control
              type="text"
              autoFocus
              defaultValue={data.brandName}
              onChange={(e) => setBrandName(e.target.value)}
            />
            <Form.Label>Brand image</Form.Label>
            <Form.Control
              type="text"
              defaultValue={data.image}
              onChange={(e) => setBrandImage(e.target.value)}
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

export default BrandModal;
