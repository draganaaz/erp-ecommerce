import { useRecoilValue } from "recoil";
import { cartState } from "../atoms/atoms";
import CartItem from "./CartItem";
import CartPreview from "./CartPreview";

const CartList = () => {
  const cartItems = useRecoilValue(cartState);

  return (
    <div className="cart-container__inner">
      <div className="cart-container__inner__left remove-scrollbar">
        <div className="cart cart__header">
          <h4>Shopping cart</h4>
          <div className="cart__header__inner">
            <div>
              <p>Products</p>
            </div>
            <div>
              <p>Quantity</p>
            </div>
            <div>
              <p>Price</p>
            </div>
          </div>
        </div>
        {cartItems.map((product: any) => (
          <CartItem key={product.id} product={product} />
        ))}
      </div>
      <CartPreview totalPrice={cartItems?.totalPrice} />
    </div>
  );
};

export default CartList;
