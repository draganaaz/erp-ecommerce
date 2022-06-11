import { axiosInstance } from '../helpers/axiosInstances';

const updateCategory = async () => {
    const categoryUrl = `${process.env.NEXT_PUBLIC_API_URL}/category`;

    await axiosInstance.put(categoryUrl)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in updateCategory method.', err);
        });
}

export default updateCategory