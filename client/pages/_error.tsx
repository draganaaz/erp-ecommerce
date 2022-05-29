import { NextPage } from "next";
import router from "next/router";

interface Props {
  statusCode?: number;
}

const Error: NextPage<Props> = ({ statusCode }) => {
  const errorMessage =
    "Unknown error occured, please go back to home.";

  // Reload and redirect to home
  const reload = () => {
    router.push("/").then(() => router.reload());
  };

  return (
    <div className="error-component">
      <h3 className="heading-4">
        {statusCode ? `${statusCode} – ${errorMessage}` : errorMessage}
      </h3>
      <div id="cart-reset-cta" className="cart__reset" onClick={() => reload()}>
        <p>
          <span id="reset-icon" className="reset-icon"></span>
          Go to home
        </p>
      </div>
    </div>
  );
};

Error.getInitialProps = async ({ res, err }) => {
  const statusCode = res ? res.statusCode : err ? err.statusCode : 404;

  return { statusCode };
};

export default Error;
