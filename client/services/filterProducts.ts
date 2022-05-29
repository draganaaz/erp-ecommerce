import axios from 'axios';

interface filterProductsProps {
    query: string
}

const filterProducts = async ({ query }: filterProductsProps) => {
    const productsUrl = `${process.env.NEXT_PUBLIC_API_URL}/product`;

    const products = await axios.get(`${productsUrl}?query=${query}`)
        .then(res => res.data)
        .catch((err: Error) => {
            throw new Error('An error occured in filterProducts method.', err);
        });
    return products
}

export default filterProducts