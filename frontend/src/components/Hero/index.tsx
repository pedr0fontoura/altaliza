import vectre from '../../assets/vectre.png';

import { Container, Content, Title, Subtitle, Text, Image, Button } from './styles';

const Hero = () => {
  return (
    <Container>
      <Content>
        <Title>O novo Emperor Vectre</Title>
        <Subtitle>Luxuoso demais para ser um clássico</Subtitle>
        <Text>
          “Seu gosto é inusitado demais para os clássicos? Mais exagerado do que razoável? Pare de procurar uma
          lata-velha qualquer e cause aquela primeira impressão marcante com o Emperor Vectre. Como uma supermodelo
          campeã dos 100 metros, o Vectre é um espetáculo em todos os sentidos.”
          <b>- Legendary Motorsport</b>
        </Text>
        <div>
          <Button type="button">Alugar</Button>
          <Button type="button" transparent>
            Ver detalhes
          </Button>
        </div>
      </Content>
      <Image src={vectre} alt="Emperor Vectre" />
    </Container>
  );
};

export default Hero;
