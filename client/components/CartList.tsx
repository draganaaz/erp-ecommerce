import { useRecoilValue } from "recoil";
import { cartState } from "../atoms/atoms";
import { cartTotal } from "../helpers/totalCartPrice";
import { ICart, IProduct } from "../types/types";
import CartItem from "./CartItem";
import CartPreview from "./CartPreview";

const CartList = () => {
  const cartItems = useRecoilValue(cartState);
  const totalPrice = useRecoilValue(cartTotal);

  return (
    <div className="cart-container__inner">
      <div className="cart-container__inner__left remove-scrollbar">
        <div className="cart cart__header">
          <h4>Shopping cart</h4>
        </div>
        {cartItems.map((cartItem: ICart) => (
          <CartItem key={cartItem.id} cartItem={cartItem} />
        ))}
      </div>
      <CartPreview totalPrice={totalPrice} />
    </div>
  );
};

export default CartList;
