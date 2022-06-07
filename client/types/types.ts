export interface IProduct {
    id: number
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
    brand1: string
    image: string
}

export interface ICategory {
    categoryId: string
    category1: string
    image: string
}

export interface ILogin {
    username: string
    password: string
}