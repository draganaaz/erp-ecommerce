import { axiosInstance } from '../helpers/axiosInstances';

const deleteCategory = async (id: number) => {
    const categoryUrl = `${process.env.NEXT_PUBLIC_API_URL}/category`;

    id && await axiosInstance.delete(`${categoryUrl}/${id}`)
        .then(res => console.log('Category successfully deleted', res))
        .catch((err) => {
            throw new Error('An error occured in deleteCategory method.', err);
        });
}

export default deleteCategory