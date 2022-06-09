import { ICart } from "../types/types";
import { removeItemFromCart } from "./removeItemFromCart";

export const updateItemInCart = (cart: ICart[], productId: number, quantity: number) => {
    const newCart = [...cart];
    const foundIndex = cart.findIndex(item => item.id === productId);

    newCart[foundIndex] = {
        ...cart[foundIndex],
        quantity: cart[foundIndex].quantity + quantity,
    };
    return newCart;
}