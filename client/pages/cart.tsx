import { useRouter } from "next/router";
import { useRecoilValue } from "recoil";
import { cartState } from "../atoms/atoms";
import CartEmpty from "../components/CartEmpty";
import CartList from "../components/CartList";

const Cart = () => {
  const router = useRouter();
  const cartItems = useRecoilValue(cartState);

  const closeCart = () => {
    router.push("/");
  };

  return (
    <div key="cart" className="cart-container">
      <div className="cart-container__nav">
        <span
          className="icon-close icon-close--dark"
          onClick={() => closeCart()}
        ></span>
      </div>

      {cartItems.length > 0 ? <CartList /> : <CartEmpty />}
    </div>
  );
};

export default Cart;
