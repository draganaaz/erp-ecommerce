import { ICart, IProduct } from "../types/types";

export const addToCart = (cart: ICart[], product: IProduct) => {
    const newCart = [...cart];
    const foundIndex = cart.findIndex(x => x.id === product.productId);

    // Increase quantity if product is already in cart
    if (foundIndex >= 0) {
        newCart[foundIndex] = {
            ...cart[foundIndex],
            quantity: cart[foundIndex].quantity + 1,
        };
        return newCart;
    }

    // Add new item
    newCart.push({
        id: product.productId,
        name: product.name,
        price: product.price,
        quantity: 1,
    });
    return newCart;
}