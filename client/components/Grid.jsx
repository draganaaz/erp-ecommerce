/* eslint-disable react-hooks/exhaustive-deps */
import React, { useState, useEffect } from "react";
import GridHelper from "./GridHelper";
import CardWrapper from "./Card";
import { useRecoilState } from "recoil";
import { productsState } from "../atoms/atoms";
import { sortOrder } from "../types/types";
import Select from "./Select";
import sortProducts from "../services/sortProducts";

const Grid = () => {
  const [sortBy, setSortBy] = useState("");
  const [products, setProducts] = useRecoilState(productsState);

  // Sort products by passed sort order
  useEffect(() => {
    sortProducts(sortBy).then((res) => setProducts(res));
  }, [sortBy]);

  return (
    <>
      <Select items={sortOrder} setSelected={setSortBy} />
      <GridHelper key={Math.random()} colCount={3} md={4}>
        {products.length > 0 ? (
          products.map((product, index) => (
            <CardWrapper key={index} id={product.id} product={product} />
          ))
        ) : (
          <p>No search results for qiven query.</p>
        )}
      </GridHelper>
    </>
  );
};

export default Grid;
