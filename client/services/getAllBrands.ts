import { axiosInstance } from '../helpers/axiosInstances';

const getAllBrands = async () => {
    const brandUrl = `${process.env.NEXT_PUBLIC_API_URL}/brand`;

    const brands = await axiosInstance.get(brandUrl)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in getAllBrands method.', err);
        });
    return brands
}

export default getAllBrands