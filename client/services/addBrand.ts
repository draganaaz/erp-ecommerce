import { axiosInstance } from '../helpers/axiosInstances';
import { IBrand } from '../types/types';

const addBrand = async (item: Partial<IBrand>) => {
    const brandUrl = `${process.env.NEXT_PUBLIC_API_URL}/brand`;
    console.log(item);


    // TODO: check do you need to return it or smt and also is data passed correctly
    await axiosInstance.post(brandUrl, item)
        .then(res => res.data)
        .catch((err) => {
            throw new Error('An error occured in addBrand method.', err);
        });
}

export default addBrand