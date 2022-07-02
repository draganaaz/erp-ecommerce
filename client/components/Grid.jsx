/* eslint-disable react-hooks/exhaustive-deps */
import React, { useState, useEffect } from "react";
import GridHelper from "./GridHelper";
import CardWrapper from "./Card";
import { useRecoilState } from "recoil";
import { paginatedProductsState } from "../atoms/atoms";
import { sortOrder } from "../types/types";
import Select from "./Select";
import Pagination from "./Pagination";
import getPaginatedProducts from "../services/getPaginatedProducts";

const Grid = () => {
  const [sortBy, setSortBy] = useState("");
  const [paginatedProducts, setPaginatedProducts] = useRecoilState(
    paginatedProductsState
  );

  // Sort products by passed sort order
  useEffect(() => {
    sortBy !== "" &&
      getPaginatedProducts({
        pageNumber: paginatedProducts.pageNumber,
        pageSize: paginatedProducts.pageNumber,
        sortOrder: sortBy,
      }).then((res) => setPaginatedProducts(res));
  }, [sortBy]);

  return (
    <>
      <Select items={sortOrder} setSelected={setSortBy} />
      <GridHelper key={Math.random()} colCount={3} md={4}>
        {paginatedProducts.data && paginatedProducts.data.length > 0 ? (
          paginatedProducts.data.map((product, index) => (
            <CardWrapper key={index} id={product.id} product={product} />
          ))
        ) : (
          <p>No search results for qiven query.</p>
        )}
      </GridHelper>
      <Pagination />
    </>
  );
};

export default Grid;
