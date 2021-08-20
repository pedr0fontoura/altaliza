import { FaDiscord, FaInstagram, FaTwitter, FaGithub } from 'react-icons/fa';

import cidadeAlta from '../../assets/cidadealta.png';

import { Container, Left, Center, Right } from './styles';

const Footer = () => (
  <Container>
    <Left>© 2021 Altaliza</Left>
    <Center>
      <a href="https://cidadealta.gg/">
        <img src={cidadeAlta} alt="Cidade Alta" />
      </a>
    </Center>
    <Right>
      <a href="https://discord.gg/cidadealtarp">
        <FaDiscord size={25} />
      </a>
      <a href="https://www.instagram.com/cidadealtarp/">
        <FaInstagram size={25} />
      </a>
      <a href="https://twitter.com/cidadealtarp">
        <FaTwitter size={25} />
      </a>
      <a href="https://github.com/pedr0fontoura">
        <FaGithub size={25} />
      </a>
    </Right>
  </Container>
);

export default Footer;
