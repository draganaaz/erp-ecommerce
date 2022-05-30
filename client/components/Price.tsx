import React from "react";

interface PriceProps {
  price: number;
  discount?: number;
}

const Price = ({ price, discount }: PriceProps) => {
  return (
    <div className="product-price-wrapper">
      <p className="product--price">{price}</p>
      {discount && <p className="price--discount">{discount}</p>}
    </div>
  );
};

export default Price;
