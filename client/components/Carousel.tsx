/* eslint-disable @next/next/no-img-element */
import { ICategory } from "../types/types";
import Carousel from "react-bootstrap/Carousel";

interface CarouselProps {
  categories: ICategory[];
}

export const CarouselWrapper = ({ categories }: CarouselProps) => {
  return (
    <Carousel>
      {categories.map((category: ICategory) => (
        <>
          <Carousel.Item interval={1000}>
            <img
              className="d-block w-100"
              src={category.image}
              alt={category.category}
            />
            <Carousel.Caption>
              <h3>{category.category}</h3>
              <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
            </Carousel.Caption>
          </Carousel.Item>
        </>
      ))}
    </Carousel>
  );
};
