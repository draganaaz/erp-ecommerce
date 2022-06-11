import { axiosInstance } from '../helpers/axiosInstances';

const deleteProduct = async (id: number) => {
    const productUrl = `${process.env.NEXT_PUBLIC_API_URL}/product`;

    id && await axiosInstance.delete(`${productUrl}/${id}`)
        .then(res => console.log('Product successfully deleted', res))
        .catch((err) => {
            throw new Error('An error occured in deleteProduct method.', err);
        });
}

export default deleteProduct