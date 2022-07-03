import React from "react";
import { useRecoilValue } from "recoil";
import { cartState } from "../../atoms/atoms";
import { ICart } from "../../types/types";

interface BasketIconProps {
  onClick?: () => void;
  isInNavbar?: boolean;
}

const BasketIcon = ({ onClick, isInNavbar = false }: BasketIconProps) => {
  const cart = useRecoilValue(cartState);
  // const totalCount = cart
  //   ?.map((item: ICart) => item.quantity)
  //   .reduce((prev, curr) => prev + curr, 0);

  return (
    <a onClick={onClick}>
      <span className="basket-icon"></span>
      {/* {isInNavbar && <span className="cart-count">{totalCount}</span>} */}
    </a>
  );
};

export default BasketIcon;
