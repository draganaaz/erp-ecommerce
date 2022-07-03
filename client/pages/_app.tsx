import "../styles/globals.scss";
import type { AppProps } from "next/app";
import "bootstrap/dist/css/bootstrap.min.css";
import { RecoilRoot } from "recoil";
import { SSRProvider } from "react-bootstrap";
import NavbarComponent from "../components/Navbar";
import "../auth/interceptor";
import "@stripe/stripe-js";

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <SSRProvider>
      <RecoilRoot>
        <NavbarComponent />
        <Component {...pageProps} />
      </RecoilRoot>
    </SSRProvider>
  );
}

export default MyApp;
