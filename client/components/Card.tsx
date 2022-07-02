import React from "react";
import { Badge, Card } from "react-bootstrap";
import { useRecoilState } from "recoil";
import { cartState } from "../atoms/atoms";
import { addToCart } from "../helpers/addToCart";
import { IProduct } from "../types/types";
import BasketIcon from "./icons/BasketIcon";
import Price from "./Price";

const CardWrapper = (data: any) => {
  const { product } = data;
  const [cart, setCart] = useRecoilState(cartState);

  // Logic for adding product to cart state
  const handleAddToCart = (product: IProduct) => {
    const newCart = addToCart(cart, product);
    setCart(newCart);
  };

  return (
    <Card style={{ width: "18rem" }}>
      {/* don't show images for brands and categories */}
      {!!product.description && (
        <Card.Img variant="top" src={product.image} alt={"product image"} />
      )}
      <Card.Body>
        <Card.Title>
          {product.name || product.categoryName || product.brandName}
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
        <Price price={product.price} discount={product.discount} />
        {/* Display cart icon only for products, not brands and categories, same goes for OOS button */}
        {product.description ? (
          product.isAvailable ? (
            <BasketIcon onClick={() => handleAddToCart(product)} />
          ) : (
            <Badge
              pill
              bg="secondary"
              style={{
                paddingTop: "6px",
                width: "90px",
                height: "25px",
                marginTop: "8px",
              }}
            >
              out of stock
            </Badge>
          )
        ) : (
          ""
        )}
      </span>
    </Card>
  );
};

export default CardWrapper;
