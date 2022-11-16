import data from '../../auth_config.json';

export const environment = {
  production: false,
  auth: {
    domain: data.domain,
    clientId: data.clientId,
    redirectUri: window.location.origin,
    audience: data.audience,
  },
  dev: {
    serverUrl: data.serverUrl
  },
};