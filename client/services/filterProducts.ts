import { axiosInstance } from '../helpers/axiosInstances';

interface filterProductsProps {
    query: string
}

const filterProducts = async ({ query }: filterProductsProps) => {
    const productsUrl = `${process.env.NEXT_PUBLIC_API_URL}/product`;

    const products = await axiosInstance.get(`${productsUrl}?query=${query}`)
        .then(res => res.data)
        .catch((err: Error) => {
            throw new Error('An error occured in filterProducts method.', err);
        });
    return products
}

export default filterProducts