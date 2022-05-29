import axios from 'axios';

const getAllProducts = async () => {
    const productsUrl = `${process.env.NEXT_PUBLIC_API_URL}/product`;

    const products = await axios.get(productsUrl)
        .then(res => res.data)
        .catch((err: Error) => {
            throw new Error('An error occured in getAllProducts method.', err);
        });
    return products
}

export default getAllProducts