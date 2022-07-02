import React from "react";

interface PriceProps {
  price: number;
  discount?: number;
}

const Price = ({ price, discount }: PriceProps) => {
  return (
    <div className="d-flex align-items-center">
      <p className="product--price px-3">{price}</p>
      {!!discount && discount !== 0 && <p>{discount}%</p>}
    </div>
  );
};

export default Price;
