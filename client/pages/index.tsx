/* eslint-disable react-hooks/exhaustive-deps */
import type { NextPage } from "next";
import { useRecoilState } from "recoil";
import { productsState } from "../atoms/atoms";
import Grid from "../components/Grid";
import { useEffect } from "react";
import getAllProducts from "../services/getAllProducts";

const Home: NextPage = () => {
  const [products, setProducts] = useRecoilState(productsState);

  // Fetch all products
  useEffect(() => {
    getAllProducts().then((res) => setProducts(res));
  }, []);

  return <div style={{ backgroundColor: "beige" }}>{products && <Grid />}</div>;
};

export default Home;
