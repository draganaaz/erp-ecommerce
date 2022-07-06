import React from "react";
import { useRecoilValue } from "recoil";
import { categoriesState } from "../atoms/atoms";
import CardWrapper from "../components/Card";
import GridHelper from "../components/GridHelper";
import { ICategory } from "../types/types";

const Categories = () => {
  const categories = useRecoilValue(categoriesState);

  return (
    <GridHelper key={Math.random()} colCount={3} md={4}>
      {categories.map((category: ICategory) => (
        <CardWrapper
          key={category.categoryId}
          id={category.categoryId}
          product={category}
        />
      ))}
    </GridHelper>
  );
};

export default Categories;
