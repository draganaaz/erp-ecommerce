import { selector } from "recoil";
import { cartState } from "../atoms/atoms";
import { ICart } from "../types/types";

export const cartTotal = selector({
    key: 'cartTotal',
    get: ({ get }) => {
        const cart = get(cartState);

        return cart.reduce((total: number, item: ICart) => {
            return total + (item.product.price * item.quantity);
        }, 0);
    }
})