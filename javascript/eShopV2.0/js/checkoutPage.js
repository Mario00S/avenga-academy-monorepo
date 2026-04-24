import { getCart, getCartCount, getCartSubtotal, clearCart } from './services/cartService.js';
import { renderCartItems, renderCartSummary } from './utils/render.js';

const checkoutItems = document.getElementById('checkoutItems');
const checkoutSummary = document.getElementById('checkoutSummary');
const cartBadge = document.getElementById('cartBadge');

const updateCartBadge = () => {
  cartBadge.textContent = getCartCount();
};

const renderCheckoutPage = () => {
  const cart = getCart();
  const subtotal = getCartSubtotal();

  renderCartItems(cart, checkoutItems);
  renderCartSummary(subtotal, checkoutSummary);
  updateCartBadge();

  if (subtotal > 0) {
    checkoutSummary.innerHTML += `
      <button id="placeOrderBtn" class="btn btn-success w-100 mt-3">
        Place Order
      </button>
    `;
  }
};

checkoutSummary.addEventListener('click', event => {
  if (event.target.id === 'placeOrderBtn') {
    clearCart();
    updateCartBadge();
    checkoutItems.innerHTML = `
      <div class="alert alert-success">
        Thank you! Your order has been placed successfully.
      </div>
    `;
    checkoutSummary.innerHTML = '';
  }
});

renderCheckoutPage();
