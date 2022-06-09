import { useRecoilValue } from "recoil";
import { cartState } from "../atoms/atoms";
import CartEmpty from "../components/CartEmpty";
import CartList from "../components/CartList";

const Cart = () => {
  const cartItems = useRecoilValue(cartState);

  return (
    <div key="cart" className="cart-container">
      {cartItems.length > 0 ? <CartList /> : <CartEmpty />}
    </div>
  );
};

export default Cart;
