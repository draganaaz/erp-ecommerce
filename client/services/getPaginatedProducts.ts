import { axiosInstance } from '../helpers/axiosInstances';

interface getPaginatedProductsProps {
    pageSize?: number
    pageNumber?: number
    sortOrder?: string
    query?: string
    productType?: string
}

const getPaginatedProducts = async ({ pageSize = 10, pageNumber = 1, sortOrder, query, productType }: getPaginatedProductsProps) => {
    let sortParam = ''
    let productTypeParam = ''
    let queryParam = ''

    if (sortOrder) {
        sortParam = `&sortOrder=${sortOrder}`
    }
    if (query) {
        queryParam = `&query=${query}`
    }
    if (productType) {
        productTypeParam = `&productType=${productType}`
    }

    const productsUrl = `${process.env.NEXT_PUBLIC_API_URL}/product?pageSize=${pageSize}&pageNumber=${pageNumber}${sortParam}${queryParam}${productTypeParam}`;

    const products = await axiosInstance.get(productsUrl)
        .then(res => res.data)
        .catch((err: Error) => {
            throw new Error('An error occured in getPaginatedProducts method.', err);
        });
    return products
}

export default getPaginatedProducts