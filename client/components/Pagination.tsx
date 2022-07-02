import React from "react";
import { paginatedProductsState } from "../atoms/atoms";
import { useRecoilState } from "recoil";
import { IPaginatedResponse } from "../types/types";

const Pagination = () => {
  const [paginatedProducts, setPaginatedProducts] = useRecoilState(
    paginatedProductsState
  );
  const currentPage = paginatedProducts.pageNumber;

  // Change the state to trigger getProducts call
  const updatePageNumber = (pageNumber: number) => {
    const newState = {
      ...paginatedProducts,
      pageNumber,
    } as IPaginatedResponse;
    setPaginatedProducts(newState);
  };

  const updatePageSize = (pageSize: number) => {
    const newState = {
      ...paginatedProducts,
      pageSize,
    } as IPaginatedResponse;
    setPaginatedProducts(newState);
  };

  return (
    <div className="pagination">
      <button onClick={() => updatePageNumber(1)} disabled={currentPage === 1}>
        {"<<"}
      </button>
      <button
        onClick={() => updatePageNumber(currentPage - 1)}
        disabled={currentPage === 1}
      >
        {"<"}
      </button>
      <button
        onClick={() => updatePageNumber(currentPage + 1)}
        disabled={currentPage === paginatedProducts.totalPages}
      >
        {">"}
      </button>
      <button
        onClick={() => updatePageNumber(paginatedProducts.totalPages)}
        disabled={currentPage === paginatedProducts.totalPages}
      >
        {">>"}
      </button>
      <span>
        Page
        <strong>
          {paginatedProducts.pageNumber} of {paginatedProducts.totalPages}
        </strong>
      </span>
      <select
        value={paginatedProducts.pageSize}
        onChange={(e) => {
          updatePageSize(Number(e.target.value));
        }}
      >
        {[5, 10, 20, 30, 40, 50].map((size) => (
          <option key={size} value={size}>
            Show {size} items
          </option>
        ))}
      </select>
    </div>
  );
};

export default Pagination;
