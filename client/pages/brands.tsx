/* eslint-disable react-hooks/exhaustive-deps */
import React, { useEffect } from "react";
import { useRecoilState, useRecoilValue } from "recoil";
import { brandsState } from "../atoms/atoms";
import CardWrapper from "../components/Card";
import GridHelper from "../components/GridHelper";
import getAllBrands from "../services/getAllBrands";
import { IBrand } from "../types/types";

const Brands = () => {
  const [brands, setBrands] = useRecoilState(brandsState);

  useEffect(() => {
    getAllBrands().then((res: any) => setBrands(res));
  }, []);

  return (
    <GridHelper key={Math.random()} colCount={3} md={4}>
      {!!brands && brands.map((brand: IBrand) => (
        <CardWrapper key={brand.brandId} id={brand.brandId} product={brand} />
      ))}
    </GridHelper>
  );
};

export default Brands;
