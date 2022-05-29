import React from "react";
import { Card } from "react-bootstrap";

const CardWrapper = (data: any) => {
  const { product } = data;

  return (
    <Card style={{ width: "18rem" }}>
      <Card.Img variant="top" src={product.image} />
      <Card.Body>
        <Card.Title>{product.name}</Card.Title>
        <Card.Text>{product.description}</Card.Text>
      </Card.Body>
    </Card>
  );
};

export default CardWrapper;
