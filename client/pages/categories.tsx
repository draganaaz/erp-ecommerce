/* eslint-disable react-hooks/exhaustive-deps */
import React, { useEffect } from "react";
import { useRecoilState } from "recoil";
import { categoriesState } from "../atoms/atoms";
import CardWrapper from "../components/Card";
import GridHelper from "../components/GridHelper";
import getAllCategories from "../services/getAllCategories";
import { ICategory } from "../types/types";

const Categories = () => {
  const [categories, setCategories] = useRecoilState(categoriesState);

  useEffect(() => {
    getAllCategories().then((res: any) => setCategories(res));
  }, []);
  
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
