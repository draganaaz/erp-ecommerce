import React from "react";
import { Toast } from "react-bootstrap";
import { useRecoilValue } from "recoil";

interface ToastMessageProps {
  toastMessage: string;
}

const ToastMessage = ({ toastMessage }: ToastMessageProps) => {
  return (
    <Toast>
      <Toast.Body>{toastMessage}</Toast.Body>
    </Toast>
  );
};

export default ToastMessage;
