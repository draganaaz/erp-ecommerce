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
    <tr>
      <th scope="row" className="border-0">
        <div className="p-2">
          <img
            src={cartItem.product?.image}
            alt={cartItem.product?.name}
            width="70"
            className="img-fluid rounded shadow-sm"
          />
          <div className="ms-3 d-inline-block align-middle">
            <h5 className="mb-0">
              <a href="#" className="text-dark d-inline-block align-middle">
                {cartItem.product?.name}
              </a>
            </h5>
          </div>
        </div>
      </th>
      <td className="border-0 align-middle">
        <strong>{cartItem.product.price}</strong>
      </td>
      <td className="d-flex border-0 align-items-center py-3">
        {/* On '-' click, decrease quantity */}
        <div id="minus-quantity" onClick={() => updateQuantity(-1)}>
          <button className="btn">-</button>
        </div>
        <strong>{quantity}</strong>
        {/* On '+' click, increase quantity */}
        <div id="plus-quantity" onClick={() => updateQuantity(1)}>
          <button className="btn">+</button>
        </div>
      </td>

      <td
        className="border-0 align-middle"
        id="remove-quantity"
        onClick={handleRemoveClick}
      >
        <strong>X</strong>
      </td>
    </tr>
  );
};

export default CartItem;
