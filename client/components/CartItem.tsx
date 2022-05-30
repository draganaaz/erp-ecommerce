/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable @next/next/no-img-element */
import { ChangeEvent, useState } from "react";
import { IProduct } from "../types/types";
import Price from "./Price";

interface CartItemProps {
  product: IProduct;
}

const CartItem = ({ product }: CartItemProps) => {
  const [quantity, setQuantity] = useState<number>(0);

  // Logic for removing item from cart
  const removeFromCart = async (id: number) => {
    // TODO: implement logic
  };

  // Logic for updating item from cart
  const updateItemInCart = async (quantity: number) => {
    // TODO: implement logic
  };

  // Method that triggers on buttons '+' and '-' click and calls the service to update it
  const updateQuantity = async (n = 1) => {
    const val = Number(quantity) + n;

    if (Number.isInteger(val) && val >= 0) {
      setQuantity(val);
      await updateItemInCart(val);
    }
  };

  const handleQuantityInput = () => {
    setQuantity(Number(" "));
  };

  const handleQuantity = async (e: ChangeEvent<HTMLInputElement>) => {
    const val = Number(e.target.value);
    if (Number.isInteger(val) && val >= 0) {
      setQuantity(Number(e.target.value));
      // await updateItemInCart(val);
    }
  };

  return (
    <>
      <div id="cart-product-item-list" className={"cart list-item"}>
        <div className="cart-item-img">
          <img
            id="cart-product-image"
            src={product?.image}
            alt={product?.name}
          />
        </div>
        <div className="cart__text">
          <p id="cart-product-title" className="title">
            {product?.name}
          </p>
          <p
            id="remove-quantity"
            className="btn--remove-btn"
            onClick={() => removeFromCart(product.id)}
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
              onChange={handleQuantity}
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
        <Price price={product.price} discount={product.discount} />
      </div>
    </>
  );
};

export default CartItem;
