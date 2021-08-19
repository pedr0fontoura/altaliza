import { createGlobalStyle } from 'styled-components';

export default createGlobalStyle`
  * {
    margin: 0;
    padding: 0;
    outline: 0;
    box-sizing: border-box;
  }

  html {
    font-size: 16px;
    color: #FFF;
  }

  html, body {
    height: 100vh;
    width: 100vw;
  }

  body {
    background: #00974A;
  }
`;
