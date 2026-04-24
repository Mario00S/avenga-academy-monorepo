export const formatPrice = value => `$${value.toFixed(2)}`;

export const getQueryParam = key => {
  const params = new URLSearchParams(window.location.search);
  return params.get(key);
};
