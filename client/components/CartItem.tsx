/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable @next/next/no-img-element */
import { ChangeEvent, useState } from "react";
import { useRecoilState, useRecoilValue } from "recoil";
import { cartState } from "../atoms/atoms";
import { removeItemFromCart } from "../helpers/removeItemFromCart";
import { updateItemInCart } from "../helpers/updateItemInCart";
import { ICart, IProduct } from "../types/types";
import Price from "./Price";

interface CartItemProps {
  cartItem: ICart;
}

const CartItem = ({ cartItem }: CartItemProps) => {
  const [quantity, setQuantity] = useState<number>(cartItem.quantity);
  const [cartItems, setCartItems] = useRecoilState(cartState);

  // Method that triggers on buttons '+' and '-' click and calls the service to update it
  const updateQuantity = (n = 1) => {
    const val = Number(quantity) + n;

    if (Number.isInteger(val) && val >= 0) {
      setQuantity(val);
      const newCart = updateItemInCart(cartItems, cartItem.id, n);
      setCartItems(newCart);
    }
  };

  const handleQuantityInput = () => {
    setQuantity(Number(" "));
  };

  const handleRemoveClick = () => {
    const newCart = removeItemFromCart(cartItems, cartItem.id);
    setCartItems(newCart);
  };

  return (
    <>
      <div id="cart-product-item-list" className={"cart list-item"}>
        <div className="cart-item-img">
          <img
            id="cart-product-image"
            src={cartItem.product?.image}
            alt={cartItem.product?.name}
          />
        </div>
        <div className="cart__text">
          <p id="cart-product-title" className="title">
            {cartItem.product?.name}
          </p>
          <p
            id="remove-quantity"
            className="btn--remove-btn"
            onClick={handleRemoveClick}
          >
            remove
          </p>
        </div>

        <div id="modifyQuantity" className="btn-wrapper">
          <div className="btn-wrapper__inner">
            {/* On '-' click, decrease quantity */}
            <div
              id="minus-quantity"
              className="button-action"
              onClick={() => updateQuantity(-1)}
            >
              <button className="btn"></button>
            </div>
          </div>
          <label id="quantity-number">
            <input
              type="number"
              max={99}
              min={0}
              className="cart__quantity"
              value={quantity}
              disabled
              onFocus={handleQuantityInput}
            />
          </label>
          <div className="btn-wrapper__inner">
            {/* On '+' click, increase quantity */}
            <div
              id="plus-quantity"
              className="button-action"
              onClick={() => updateQuantity(1)}
            >
              <button className="btn"></button>
            </div>
          </div>
        </div>
        <Price
          price={cartItem.product.price}
          discount={cartItem.product.discount}
        />
      </div>
    </>
  );
};

export default CartItem;
