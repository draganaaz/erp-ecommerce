import React from "react";
import Modal from "react-bootstrap/Modal";
import { useRecoilState } from "recoil";
import { showModalState } from "../../atoms/atoms";
import { tableTypes } from "../../types/types";
import BrandModal from "./BrandModal";
import CategoryModal from "./CategoriesModal";
import ProductModal from "./ProductsModal";

interface ModalWrapperProps {
  data: any;
  type: string;
  isUpdate: boolean;
}

const ModalWrapper = ({ data, type, isUpdate }: ModalWrapperProps) => {
  const [show, setShow] = useRecoilState(showModalState);
  const handleClose = () => setShow(false);

  const renderModalForm = () => {
    if (data) {
      switch (type) {
        case tableTypes.brands:
          return <BrandModal data={data} isUpdate={isUpdate} />;
        case tableTypes.categories:
          return <CategoryModal data={data} isUpdate={isUpdate} />;
        case tableTypes.products:
          return <ProductModal data={data} isUpdate={isUpdate} />;
      }
    }
  };

  return (
    <>
      <Modal show={show} onHide={handleClose}>
        {renderModalForm()}
      </Modal>
    </>
  );
};

export default ModalWrapper;
