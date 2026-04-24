import {
  getCart,
  getCartCount,
  getCartSubtotal,
  updateCartItemQuantity,
  removeFromCart
} from './services/cartService.js';
import { renderCartItems, renderCartSummary } from './utils/render.js';

const cartItemsContainer = document.getElementById('cartItems');
const cartSummaryContainer = document.getElementById('cartSummary');
const cartBadge = document.getElementById('cartBadge');

const updateCartBadge = () => {
  cartBadge.textContent = getCartCount();
};

const renderCartPage = () => {
  const cart = getCart();
  const subtotal = getCartSubtotal();

  renderCartItems(cart, cartItemsContainer);
  renderCartSummary(subtotal, cartSummaryContainer);
  updateCartBadge();
};

cartItemsContainer.addEventListener('click', event => {
  const quantityButton = event.target.closest('.qty-btn');
  const removeButton = event.target.closest('.remove-btn');

  if (quantityButton) {
    const productId = Number(quantityButton.dataset.id);
    const action = quantityButton.dataset.action;
    updateCartItemQuantity(productId, action);
    renderCartPage();
  }

  if (removeButton) {
    const productId = Number(removeButton.dataset.id);
    removeFromCart(productId);
    renderCartPage();
  }
});

renderCartPage();
