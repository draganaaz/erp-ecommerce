import { ICart } from "../types/types";

export const removeItemFromCart = (cart: ICart[], productId: number) => {
    // Leave all items but the one that should be removed
    const newCart = cart.filter(item => item.id !== productId)
    return newCart;
}