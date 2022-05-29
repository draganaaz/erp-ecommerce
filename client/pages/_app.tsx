import "../styles/globals.scss";
import type { AppProps } from "next/app";
import "bootstrap/dist/css/bootstrap.min.css";
import { RecoilRoot } from "recoil";
import { SSRProvider } from "react-bootstrap";

function MyApp({ Component, pageProps }: AppProps) {
  return (
    <SSRProvider>
      <RecoilRoot>
        <Component {...pageProps} />
      </RecoilRoot>
    </SSRProvider>
  );
}

export default MyApp;
