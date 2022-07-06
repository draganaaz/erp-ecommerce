import { axiosInstance } from '../helpers/axiosInstances';
import { IBrand } from '../types/types';

const updateBrand = async (item: IBrand) => {
    const brandUrl = `${process.env.NEXT_PUBLIC_API_URL}/brand`;

    await axiosInstance.put(brandUrl, item)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in updateBrand method.', err);
        });
}

export default updateBrand