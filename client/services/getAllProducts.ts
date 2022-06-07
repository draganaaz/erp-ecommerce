import { axiosInstance } from '../helpers/axiosInstances';

const getAllProducts = async () => {
    const productsUrl = `${process.env.NEXT_PUBLIC_API_URL}/product`;

    const products = await axiosInstance.get(productsUrl)
        .then(res => res.data)
        .catch((err: Error) => {
            throw new Error('An error occured in getAllProducts method.', err);
        });
    return products
}

export default getAllProducts