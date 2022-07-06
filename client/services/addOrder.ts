import { axiosInstance } from '../helpers/axiosInstances';

const addOrder = async (item: any) => {
    const orderUrl = `${process.env.NEXT_PUBLIC_API_URL}/order`;

    await axiosInstance.post(orderUrl, item)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in addOrder method.', err);
        });
}

export default addOrder