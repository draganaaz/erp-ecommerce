import React, { useState } from "react";
import { Table } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { showModalState } from "../atoms/atoms";
import deleteBrand from "../services/deleteBrand";
import deleteCategory from "../services/deleteCategory";
import deleteProduct from "../services/deleteProduct";
import { IBrand, ICategory, IProduct, tableTypes } from "../types/types";
import ModalWrapper from "./Modals/Modal";

interface TableWrapperProps {
  data: any;
  type: string;
}

const TableWrapper = ({ data, type }: TableWrapperProps) => {
  const [, setShow] = useRecoilState(showModalState);
  const [currentItem, setCurrentItem] = useState({});
  const [isUpdate, setIsUpdate] = useState(false);

  // Open modal to edit currect object
  const handleUpdateItem = (item: any) => {
    setIsUpdate(true);
    setShow(true);
    setCurrentItem(item);
  };

  const handleDeleteItem = (item: any) => {
    switch (type) {
      case tableTypes.brands:
        deleteBrand(item.brandId);
      case tableTypes.categories:
        deleteCategory(item.categoryId);
      case tableTypes.products:
        deleteProduct(item.productId);
    }
  };

  // Open modal to save new object
  const handleAddItem = () => {
    setIsUpdate(false);
    setShow(true);
  };

  const renderTable = () => {
    if (data) {
      switch (type) {
        case tableTypes.brands:
          return data.map((item: IBrand, index: number) => (
            <tr key={index}>
              <td>{item.brandId}</td>
              <td>{item.brandName}</td>
              <td onClick={() => handleUpdateItem(item)}>Update</td>
              <td onClick={() => handleDeleteItem(item)}>Delete</td>
            </tr>
          ));
        case tableTypes.categories:
          return data.map((item: ICategory, index: number) => (
            <tr key={index}>
              <td>{item.categoryId}</td>
              <td>{item.categoryName}</td>
              <td onClick={() => handleUpdateItem(item)}>Update</td>
              <td onClick={() => handleDeleteItem(item)}>Delete</td>
            </tr>
          ));
        case tableTypes.products:
          return data.map((item: IProduct, index: number) => (
            <tr key={index}>
              <td>{item.productId}</td>
              <td>{item.name}</td>
              <td>{item.description}</td>
              <td>{item.image}</td>
              <td>{item.price}</td>
              <td>{item.discount}</td>
              <td>{item.isAvailable}</td>
              <td onClick={() => handleUpdateItem(item)}>Update</td>
              <td onClick={() => handleDeleteItem(item)}>Delete</td>
            </tr>
          ));
      }
    }
  };

  return (
    <>
      <Table striped bordered hover>
        <tbody>{renderTable()}</tbody>
        {currentItem && (
          <ModalWrapper data={currentItem} type={type} isUpdate={isUpdate} />
        )}
      </Table>
      <button onClick={() => handleAddItem()}>Add new item</button>
    </>
  );
};

export default TableWrapper;
