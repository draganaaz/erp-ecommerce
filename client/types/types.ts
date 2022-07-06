export interface IProduct {
    productId: number
    name: string
    description: string
    isAvailable: boolean
    price: number
    discount: number
    productType: number
    image: string
    brandId?: number
    categoryId?: number
}

export interface IBrand {
    brandId: string
    brandName: string
}

export interface ICategory {
    categoryId: string
    categoryName: string
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
    man: 'man',
    woman: 'woman',
    kids: 'kids'
}

export const tableTypes = {
    products: "Products",
    brands: "Brands",
    categories: "Categories",
}

export const sortOrder = [
    { availability: 'In stock first' },
    { price: 'Lowest price first' },
    { price_desc: 'Highest price first' },
    { discount: 'Lowest discount first' },
    { discount_desc: 'Highest discount first' }
]

export interface IPaginatedResponse {
    data: IProduct[],
    pageNumber: number,
    pageSize: number,
    totalPages: number,
    totalRecords: number
}

export const Roles = {
    Admin: 'Admin',
    User: 'User '
}