export interface IProduct {
    name: string
    description: string
    isAvailable: boolean
    price: number
    discount: number
    productType: number
    image: string
}

export interface IBrand {
    brand: string
    image: string
}

export interface ICategory {
    category: string
    image: string
}