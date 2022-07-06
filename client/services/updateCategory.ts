import { axiosInstance } from '../helpers/axiosInstances';
import { ICategory } from '../types/types';

const updateCategory = async (item: ICategory) => {
    const categoryUrl = `${process.env.NEXT_PUBLIC_API_URL}/category`;

    await axiosInstance.put(categoryUrl, item)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in updateCategory method.', err);
        });
}

export default updateCategory