import { BrowserRouter } from 'react-router-dom';

import GlobalStyles from './styles/global';

import Navbar from './components/Navbar';

import Routes from './routes';

function App() {
  return (
    <>
      <GlobalStyles />
      <BrowserRouter>
        <Navbar />
        <Routes />
      </BrowserRouter>
    </>
  );
}

export default App;
