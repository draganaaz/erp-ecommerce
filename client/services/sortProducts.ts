import { axiosInstance } from '../helpers/axiosInstances';

const sortProducts = async (sortOrder: string) => {
    const productsUrl = `${process.env.NEXT_PUBLIC_API_URL}/product?sortOrder=${sortOrder}`;

    const products = await axiosInstance.get(productsUrl)
        .then(res => res.data)
        .catch((err: Error) => {
            throw new Error('An error occured in sortProducts method.', err);
        });
    return products
}

export default sortProducts