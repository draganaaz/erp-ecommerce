import React from "react";

interface BasketIconProps {
  onClick?: () => void;
}

const BasketIcon = ({ onClick }: BasketIconProps) => {
  return (
    <a onClick={onClick}>
      <span className="basket-icon"></span>
    </a>
  );
};

export default BasketIcon;
