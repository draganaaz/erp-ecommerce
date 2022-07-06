import { axiosInstance } from '../helpers/axiosInstances';
import { IProduct } from '../types/types';

const updateProduct = async (item: Partial<IProduct>) => {
    const productUrl = `${process.env.NEXT_PUBLIC_API_URL}/product`;

    await axiosInstance.put(productUrl, item)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in updateProduct method.', err);
        });
}

export default updateProduct