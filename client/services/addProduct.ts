import { axiosInstance } from '../helpers/axiosInstances';
import { IProduct } from '../types/types';

const addProduct = async (item: Partial<IProduct>) => {
    const productUrl = `${process.env.NEXT_PUBLIC_API_URL}/product`;

    await axiosInstance.post(productUrl, item)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in addProduct method.', err);
        });
}

export default addProduct