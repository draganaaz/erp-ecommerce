/* eslint-disable jsx-a11y/alt-text */
/* eslint-disable @next/next/no-img-element */
import { useRecoilValue } from "recoil";
import { cartState } from "../atoms/atoms";
import { cartTotal } from "../helpers/totalCartPrice";
import addOrder from "../services/addOrder";
import { getUserNameFromJwt } from "../services/tokenService";
import { isLoggedIn } from "../services/userService";
import { ICart } from "../types/types";
import CartItem from "./CartItem";

const CartList = () => {
  const cartItems = useRecoilValue(cartState);
  const totalPrice = useRecoilValue(cartTotal);

  const handleCheckoutClick = () => {
    addOrder({
      name: getUserNameFromJwt(),
      address: "Addressssss",
      city: "Cityyyy",
      country: "Countryyyy",
      // dateCreated: new Date().toISOString().slice(0, 19).replace("T", " "),
      totalPrice: totalPrice,
      isPaymentDone: false,
    });
  };

  return (
    <>
      <div className="row">
        <div className="col-lg-12 p-4 bg-white rounded shadow-sm mb-5">
          <div className="table-responsive">
            <table className="table">
              <thead>
                <tr>
                  <th scope="col" className="border-0 bg-light">
                    <div className="p-2 px-3 text-uppercase">Product</div>
                  </th>
                  <th scope="col" className="border-0 bg-light">
                    <div className="py-2 text-uppercase">Price</div>
                  </th>
                  <th scope="col" className="border-0 bg-light">
                    <div className="py-2 text-uppercase">Quantity</div>
                  </th>
                  <th scope="col" className="border-0 bg-light">
                    <div className="py-2 text-uppercase">Remove</div>
                  </th>
                </tr>
              </thead>
              <tbody>
                {cartItems.map((cartItem: ICart) => (
                  <CartItem key={cartItem.id} cartItem={cartItem} />
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <div className="row p-3 bg-white rounded shadow-sm">
        <div className="bg-light rounded-pill px-4 py-2 text-uppercase fw-bold">
          Order summary
        </div>
        <div className="p-4">
          <strong className="text-muted">Total</strong>
          <h5 className="fw-bold">{totalPrice}</h5>
        </div>
        {isLoggedIn() ? (
          <a
            onClick={handleCheckoutClick}
            className="btn btn-dark rounded-pill py-2 d-md-block"
          >
            Procceed to checkout
          </a>
        ) : (
          <a className="btn btn-dark rounded-pill py-2 d-md-block">
            Please login to proceed to checkout
          </a>
        )}
      </div>
    </>
  );
};

export default CartList;
