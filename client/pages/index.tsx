/* eslint-disable react-hooks/exhaustive-deps */
import type { NextPage } from "next";
import { useRecoilState } from "recoil";
import { brandsState, categoriesState, productsState } from "../atoms/atoms";
import NavbarComponent from "../components/Navbar.jsx";
import Grid from "../components/Grid";
import { CarouselWrapper } from "../components/Carousel";
import { useEffect } from "react";
import getAllBrands from "../services/getAllBrands";
import getAllCategories from "../services/getAllCategories";
import getAllProducts from "../services/getAllProducts";

const Home: NextPage = () => {
  const [products, setProducts] = useRecoilState(productsState);
  const [, setBrands] = useRecoilState(brandsState);
  const [, setCategories] = useRecoilState(categoriesState);

  // Fetch all brands, collections and products
  useEffect(() => {
    getAllBrands().then((res) => setBrands(res));
    getAllCategories().then((res) => setCategories(res));
    getAllProducts().then((res) => setProducts(res));
  }, []);

  return (
    <div style={{ backgroundColor: "beige" }}>
      <NavbarComponent />
      {products && <Grid />}
      {/* <CarouselWrapper categories={categories} /> */}
    </div>
  );
};

export default Home;
