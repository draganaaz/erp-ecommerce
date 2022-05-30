
import { atom } from "recoil";
import { IBrand, ICategory, IProduct } from "../types/types";

// Key = unique ID (with respect to other atoms/selectors)
// Default = default value (aka initial value)

export const productsState = atom({
    key: 'productsState',
    default: [] as IProduct[]
})

export const brandsState = atom({
    key: 'brandsState',
    default: [] as IBrand[]
})

export const categoriesState = atom({
    key: 'categoriesState',
    default: [] as ICategory[]
})

export const cartState = atom({
    key: 'cartState',
    default: [] as any
})