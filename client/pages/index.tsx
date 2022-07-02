/* eslint-disable react-hooks/exhaustive-deps */
import type { NextPage } from "next";
import { useRecoilState, useRecoilValue } from "recoil";
import { productsState, paginatedProductsState } from "../atoms/atoms";
import Grid from "../components/Grid";
import { useEffect } from "react";
import getPaginatedProducts from "../services/getPaginatedProducts";

const Home: NextPage = () => {
  const [products, setProducts] = useRecoilState(productsState);
  const [paginatedProducts, setPaginatedProducts] = useRecoilState(
    paginatedProductsState
  );

  // Fetch all products
  // pageNumber and pageSize are going to change in sub-components (pagination bar)
  // and products need to be fetched accordingly
  useEffect(() => {
    getPaginatedProducts({
      pageNumber: paginatedProducts.pageNumber,
      pageSize: paginatedProducts.pageSize,
    }).then((res) => {
      setProducts(res.data);
      setPaginatedProducts(res);
    });
  }, [paginatedProducts.pageNumber, paginatedProducts.pageSize]);

  return <div style={{ backgroundColor: "beige" }}>{products && <Grid />}</div>;
};

export default Home;
