import { axiosInstance } from '../helpers/axiosInstances';

const updateBrand = async () => {
    const brandUrl = `${process.env.NEXT_PUBLIC_API_URL}/brand`;

    await axiosInstance.put(brandUrl)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in updateBrand method.', err);
        });
}

export default updateBrand