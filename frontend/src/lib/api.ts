import axios from 'axios';

const api = axios.create({
  baseURL: process.env.REACT_APP_ALTALIZA_API,
});

export default api;
