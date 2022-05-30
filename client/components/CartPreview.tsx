interface CartPreviewProps {
  totalPrice: number;
}

const CartPreview = ({ totalPrice }: CartPreviewProps) => {
  return (
    <div className={"cart-container__inner__preview"}>
      <div className={"cart cart__right"}>
        <div className={"cart__intro"}>
          <h4 className={"header"}>Summary</h4>
          <div className="cart__inner">
            <p className={"price"}>Total</p>
            <p>{totalPrice?.toFixed(2)}</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CartPreview;
