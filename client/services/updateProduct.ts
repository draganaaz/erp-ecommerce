import { axiosInstance } from '../helpers/axiosInstances';

const updateProduct = async () => {
    const productUrl = `${process.env.NEXT_PUBLIC_API_URL}/product`;

    await axiosInstance.put(productUrl)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in updateProduct method.', err);
        });
}

export default updateProduct