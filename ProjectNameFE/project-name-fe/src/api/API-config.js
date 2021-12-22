let backendHost = process.env.REACT_APP_ENVIRONMENT_BACKEND_URL;
const apiVersion = 'v1';
//const hostname = window && window.location && window.location.hostname;

export const API_ROOT = `${backendHost}/api/${apiVersion}`;
