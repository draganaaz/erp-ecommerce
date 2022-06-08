import React from "react";
import { Card } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { cartState } from "../atoms/atoms";
import { addToCart } from "../helpers/addToCart";
import { IProduct } from "../types/types";
import BasketIcon from "./icons/BasketIcon";
import Price from "./Price";

const CardWrapper = (data: any) => {
  const { product } = data;
  const [cart, setCart] = useRecoilState(cartState);

  const handleAddToCart = (product: IProduct) => {
    const newCart = addToCart(cart, product);
    setCart(newCart);
  };

  return (
    <Card style={{ width: "18rem" }}>
      <Card.Img variant="top" src={product.image} alt={"product image"} />
      <Card.Body>
        <Card.Title>
          {product.name || product.category1 || product.brand1}
        </Card.Title>
        <Card.Text>{product.description}</Card.Text>
      </Card.Body>
      <span
        style={{
          display: "flex",
          justifyContent: "space-around",
          margin: "0 -40px",
        }}
      >
        <Price price={product.price} />
        {/* Display cart icon only for products, not brands and categories */}
        {product.description && (
          <BasketIcon onClick={() => handleAddToCart(product)} />
        )}
      </span>
    </Card>
  );
};

export default CardWrapper;
