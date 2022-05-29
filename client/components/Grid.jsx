import React from "react";
import GridHelper from "./GridHelper";
import CardWrapper from "./Card";
import { useRecoilValue } from "recoil";
import { productsState } from "../atoms/atoms";

const Grid = () => {
  const products = useRecoilValue(productsState);

  return (
    <GridHelper key={Math.random()} colCount={2} md={6}>
      {products.length > 0 ? (
        products.map((product) => (
          <CardWrapper
            key={product.id}
            id={product.id}
            product={product}
          />
        ))
      ) : (
        <p>No search results for qiven query.</p>
      )}
    </GridHelper>
  );
};

export default Grid;
