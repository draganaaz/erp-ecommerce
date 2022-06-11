import { axiosInstance } from '../helpers/axiosInstances';

const deleteBrand = async (id: number) => {
    const brandUrl = `${process.env.NEXT_PUBLIC_API_URL}/brand`;

    id && await axiosInstance.delete(`${brandUrl}/${id}`)
        .then(res => console.log('Brand successfully deleted', res))
        .catch((err) => {
            throw new Error('An error occured in deleteBrand method.', err);
        });
}

export default deleteBrand