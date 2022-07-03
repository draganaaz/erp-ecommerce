import React from "react";
import { Elements } from "@stripe/react-stripe-js";
import { loadStripe } from "@stripe/stripe-js";
import PaymentForm from "../components/Forms/PaymentForm";

const stripe = loadStripe(process.env.NEXT_PUBLIC_STRIPE_API_KEY as string);

const Payment = () => {
  return (
    <Elements stripe={stripe}>
      <PaymentForm />
    </Elements>
  );
};

export default Payment;
