import { axiosInstance } from '../helpers/axiosInstances';
import { ICategory } from '../types/types';

const addCategory = async (item: Partial<ICategory>) => {
    const categoryUrl = `${process.env.NEXT_PUBLIC_API_URL}/category`;

    await axiosInstance.post(categoryUrl, item)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in addCategory method.', err);
        });
}

export default addCategory