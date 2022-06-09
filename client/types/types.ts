export interface IProduct {
    productId: number
    name: string
    description: string
    isAvailable: boolean
    price: number
    discount: number
    productType: number
    image: string
}

export interface IBrand {
    brandId: string
    brandName: string
    image: string
}

export interface ICategory {
    categoryId: string
    categoryName: string
    image: string
}

export interface ILogin {
    username: string
    password: string
}

export interface IRegister {
    email: string
    username: string
    password: string
}

export interface ICart {
    id: number
    product: IProduct
    quantity: number
}

export const productTypes = {
    man: 'musko',
    woman: 'zensko',
    kids: 'decije'
}