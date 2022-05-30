import React from "react";
import { Card } from "react-bootstrap";
import BasketIcon from "./BasketIcon";
import Price from "./Price";

const CardWrapper = (data: any) => {
  const { product } = data;

  const addToCart = () => {
    // TODO: implement logic
  };

  return (
    <Card style={{ width: "18rem" }}>
      <Card.Img variant="top" src={product.image} alt={'product image'} />
      <Card.Body>
        <Card.Title>
          {product.name || product.category1 || product.brand1}
        </Card.Title>
        <Card.Text>{product.description}</Card.Text>
      </Card.Body>
      <span style={{ display: "flex", justifyContent: "space-around", margin: '0 -40px' }}>
        <Price price={product.price} />
        <BasketIcon onClick={addToCart} />
      </span>
    </Card>
  );
};

export default CardWrapper;
