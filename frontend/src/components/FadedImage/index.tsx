import { Container, Fade } from './styles';

interface IFadedImageProps {
  src: string;
  alt?: string;
  className?: string;
}

const FadedImage = ({ src, alt, className }: IFadedImageProps) => (
  <Container className={className}>
    <Fade />
    <img src={src} alt={alt} />
  </Container>
);

export default FadedImage;
