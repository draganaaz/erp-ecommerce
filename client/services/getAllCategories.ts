import { axiosInstance } from '../helpers/axiosInstances';

const getAllCategories = async () => {
    const categoryUrl = `${process.env.NEXT_PUBLIC_API_URL}/category`;

    const categories = await axiosInstance.get(categoryUrl)
        .then(res => res.data)
        .catch((err: Error) => {
            throw new Error('An error occured in getAllCategories method.', err);
        });
    return categories
}

export default getAllCategories