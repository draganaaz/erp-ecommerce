/* eslint-disable react-hooks/exhaustive-deps */
import React, { useEffect } from "react";
import { useRecoilState } from "recoil";
import { productsState } from "../atoms/atoms";
import CardWrapper from "../components/Card";
import GridHelper from "../components/GridHelper";
import filterProducts from "../services/filterProducts";
import { IProduct, productTypes } from "../types/types";

const Kids = () => {
  const [products, setProducts] = useRecoilState(productsState);

  useEffect(() => {
    filterProducts({ productType: productTypes.kids }).then((res) => {
      setProducts(res);
    });
  }, []);

  return (
    <GridHelper key={Math.random()} colCount={3} md={4}>
      {!!products &&
        products.map((product: IProduct) => (
          <CardWrapper
            key={product.productId}
            id={product.productId}
            product={product}
          />
        ))}
    </GridHelper>
  );
};

export default Kids;
