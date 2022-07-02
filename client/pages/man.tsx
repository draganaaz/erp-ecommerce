/* eslint-disable react-hooks/exhaustive-deps */
import React, { useEffect } from "react";
import { useRecoilState } from "recoil";
import { paginatedProductsState } from "../atoms/atoms";
import CardWrapper from "../components/Card";
import GridHelper from "../components/GridHelper";
import getPaginatedProducts from "../services/getPaginatedProducts";
import { IProduct, productTypes } from "../types/types";

const Man = () => {
  const [paginatedProducts, setPaginatedProducts] = useRecoilState(
    paginatedProductsState
  );

  useEffect(() => {
    getPaginatedProducts({ productType: productTypes.man }).then((res) => {
      setPaginatedProducts(res);
    });
  }, []);

  return (
    <GridHelper key={Math.random()} colCount={3} md={4}>
      {paginatedProducts.data && paginatedProducts.data.length > 0 ? (
        paginatedProducts.data.map((product: IProduct) => (
          <CardWrapper
            key={product.productId}
            id={product.productId}
            product={product}
          />
        ))
      ) : (
        <p>No products to display.</p>
      )}
    </GridHelper>
  );
};

export default Man;
