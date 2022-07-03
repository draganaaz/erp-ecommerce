import { axiosInstance } from '../helpers/axiosInstances';

const handlePayment = async (data: any) => {
    const paymentUrl = `${process.env.NEXT_PUBLIC_API_URL}/payment`;

    // TODO: replace data
    const response = await axiosInstance.post(paymentUrl, {
        // amount: 1000,
        // id,
    });
}

export default handlePayment