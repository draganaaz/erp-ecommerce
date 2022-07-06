import React from "react";
import { useRecoilValue } from "recoil";
import { brandsState } from "../atoms/atoms";
import CardWrapper from "../components/Card";
import GridHelper from "../components/GridHelper";
import { IBrand } from "../types/types";

const Brands = () => {
  const brands = useRecoilValue(brandsState);

  return (
    <GridHelper key={Math.random()} colCount={3} md={4}>
      {!!brands &&
        brands.map((brand: IBrand) => (
          <CardWrapper key={brand.brandId} id={brand.brandId} product={brand} />
        ))}
    </GridHelper>
  );
};

export default Brands;
