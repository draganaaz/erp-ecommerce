import React, { SyntheticEvent, useState } from "react";
import { Button } from "react-bootstrap";
import { loadStripe } from "@stripe/stripe-js";
import { useRouter } from "next/router";

const Checkout = () => {
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [address, setAddress] = useState("");
  const [country, setCountry] = useState("");
  const [cardFullName, setCardFullName] = useState("");
  const [cardNumber, setCardNumber] = useState("");
  const [cardExpiration, setCardExpiration] = useState("");
  const [cardCvv, setCardCvv] = useState("");
  const router = useRouter();

  const isFormValid =
    fullName !== "" && email !== "" && address !== "" && country !== "";
  // cardFullName !== "" &&
  // cardNumber !== "" &&
  // cardExpiration !== "" &&
  // cardCvv !== "";

  const handlePayment = () => {
    router.push("/payment");
  };

  return (
    <div className="container px-5">
      <div className="row py-4 container px-5">
        <form className="needs-validation ">
          <div className="mb-3">
            <label>Full name</label>
            <input
              type="text"
              className="form-control"
              id="fullName"
              placeholder=""
              value={fullName}
              onChange={(e) => setFullName(e.target.value)}
              required
            />
            <div className="invalid-feedback">Full name is required.</div>
          </div>
          <div className="mb-3">
            <label>
              Email <span className="text-muted">(Optional)</span>
            </label>
            <input
              type="email"
              className="form-control"
              id="email"
              placeholder="you@example.com"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <div className="invalid-feedback">
              Please enter a valid email address for shipping updates.
            </div>
          </div>
          <div className="mb-3">
            <label>Address</label>
            <input
              type="text"
              className="form-control"
              id="address"
              placeholder=""
              required
              value={address}
              onChange={(e) => setAddress(e.target.value)}
            />
            <div className="invalid-feedback">
              Please enter your shipping address.
            </div>
          </div>
          <div className="mb-3">
            <label>Country</label>
            <input
              type="text"
              className="form-control"
              id="country"
              placeholder=""
              required
              value={country}
              onChange={(e) => setCountry(e.target.value)}
            />
            <div className="invalid-feedback">Please enter country.</div>
          </div>
          <hr className="mb-6" />
          {/* <h4 className="mb-3">Payment</h4>
          <div className="row">
            <div className="col-md-6 mb-3">
              <label>Name on card</label>
              <input
                type="text"
                className="form-control"
                id="cc-name"
                placeholder=""
                required
                value={cardFullName}
                onChange={(e) => setCardFullName(e.target.value)}
              />
              <small className="text-muted">
                Full name as displayed on card
              </small>
              <div className="invalid-feedback">Name on card is required</div>
            </div>
            <div className="col-md-6 mb-3">
              <label>Credit card number</label>
              <input
                type="text"
                className="form-control"
                id="cc-number"
                placeholder=""
                required
                value={cardNumber}
                onChange={(e) => setCardNumber(e.target.value)}
              />
              <div className="invalid-feedback">
                Credit card number is required
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-md-3 mb-3">
              <label>Expiration</label>
              <input
                type="text"
                className="form-control"
                id="cc-expiration"
                placeholder=""
                required
                value={cardExpiration}
                onChange={(e) => setCardExpiration(e.target.value)}
              />
              <div className="invalid-feedback">Expiration date required</div>
            </div>
            <div className="col-md-3 mb-3">
              <label>CVV</label>
              <input
                type="text"
                className="form-control"
                id="cc-cvv"
                placeholder=""
                required
                value={cardCvv}
                onChange={(e) => setCardCvv(e.target.value)}
              />
              <div className="invalid-feedback">Security code required</div>
            </div>
          </div> */}
          <Button
            variant="dark"
            onClick={handlePayment}
            disabled={!isFormValid}
          >
            Proceed to payment
          </Button>
        </form>
      </div>
    </div>
  );
};

export default Checkout;
