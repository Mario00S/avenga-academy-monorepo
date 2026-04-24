import { fetchProductById } from './services/apiService.js';
import { addToCart, getCartCount } from './services/cartService.js';
import { renderProductDetails, showLoading, hideLoading, showError, hideError } from './utils/render.js';
import { getQueryParam } from './utils/helpers.js';

const productDetails = document.getElementById('productDetails');
const loadingState = document.getElementById('loadingState');
const errorState = document.getElementById('errorState');
const cartBadge = document.getElementById('cartBadge');

let currentProduct = null;

const updateCartBadge = () => {
  cartBadge.textContent = getCartCount();
};

const loadProduct = async () => {
  const productId = getQueryParam('id');

  if (!productId) {
    showError(errorState);
    return;
  }

  try {
    showLoading(loadingState);
    hideError(errorState);

    currentProduct = await fetchProductById(productId);
    renderProductDetails(currentProduct, productDetails);
    updateCartBadge();
  } catch (error) {
    console.error(error);
    showError(errorState);
  } finally {
    hideLoading(loadingState);
  }
};

productDetails.addEventListener('click', event => {
  const addButton = event.target.closest('.add-to-cart-btn');

  if (!addButton || !currentProduct) return;

  const result = addToCart(currentProduct);
  updateCartBadge();
  alert(result.message);
});


loadProduct();
