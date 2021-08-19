import { ReactNode } from 'react';

import { Container, ChildrenContainer, Fade } from './styles';

interface IFadedImageProps {
  src: string;
  alt?: string;
  className?: string;
  children?: ReactNode;
}

const FadedImage = ({ src, alt, className, children }: IFadedImageProps) => (
  <Container className={className}>
    {children ? <ChildrenContainer>{children}</ChildrenContainer> : null}
    <Fade />
    <img src={src} alt={alt} />
  </Container>
);

export default FadedImage;
