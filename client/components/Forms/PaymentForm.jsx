import { CardElement, useElements, useStripe } from "@stripe/react-stripe-js";
import React, { useState } from "react";
import handlePayment from "../../services/handlePayment";

const CARD_OPTIONS = {
  iconStyle: "solid",
  style: {
    base: {
      iconColor: "#c4f0ff",
      color: "#fff",
      fontWeight: 500,
      fontFamily: "Roboto, Open Sans, Segoe UI, sans-serif",
      fontSize: "16px",
      fontSmoothing: "antialiased",
      ":-webkit-autofill": { color: "#fce883" },
      "::placeholder": { color: "#87bbfd" },
    },
    invalid: {
      iconColor: "#ffc7ee",
      color: "#ffc7ee",
    },
  },
};

const PaymentForm = () => {
  const [success, setSuccess] = useState(false);
  const stripe = useStripe();
  const elements = useElements();

  const handleSubmit = async (e) => {
    e.preventDefault();
    const { error, paymentMethod } = await stripe.createPaymentMethod({
      type: "card",
      card: elements.getElement(CardElement),
    });

    const { token } = await stripe.createToken();

    if (!error) {
      // try {
      const { id } = paymentMethod;
      // TODO: pass data
      handlePayment({
        // amount: selectedProduct.price.toString().replace(".", "")
        amount: 100,
        source: token.id,
        receipt_email: "customer@example.com",
      })
        .then((res) => {
          console.log("Successful payment", res);
          setSuccess(true);
          // setReceiptUrl(order.data.charge.receipt_url)
        })
        .catch((err) => console.log(err));

      //   if (response.data.success) {
      //     console.log("Successful payment");
      //     setSuccess(true);
      //   }
      // } catch (error) {
      //   console.log("Error", error);
      // }
    } else {
      console.log(error.message);
    }
  };

  return (
    <>
      {!success ? (
        <form onSubmit={handleSubmit}>
          <fieldset className="FormGroup">
            <div className="FormRow">
              <CardElement options={CARD_OPTIONS} />
            </div>
          </fieldset>
          <button>Pay</button>
        </form>
      ) : (
        <div>
          <h2>Congratss</h2>
        </div>
      )}
    </>
  );
};

export default PaymentForm;
