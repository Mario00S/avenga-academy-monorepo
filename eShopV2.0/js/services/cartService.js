import { CartItem } from '../models/CartItem.js';

const CART_KEY = 'techstore-cart';

let cart = loadCart();

function saveCart() {
  localStorage.setItem(CART_KEY, JSON.stringify(cart));
}

function loadCart() {
  return JSON.parse(localStorage.getItem(CART_KEY)) || [];
}

export function getCart() {
  return cart;
}

export function getCartCount() {
  return cart.reduce((total, item) => total + item.quantity, 0);
}

export function getCartSubtotal() {
  return cart.reduce((total, item) => total + item.price * item.quantity, 0);
}

export function addToCart(product) {
  if (!product.isInStock || product.stock <= 0) {
    return { success: false, message: 'This item is out of stock.' };
  }

  const existingItem = cart.find(item => item.id === product.id);

  if (existingItem) {
    if (existingItem.quantity >= product.stock) {
      return { success: false, message: 'You reached the available stock limit.' };
    }

    existingItem.quantity += 1;
  } else {
    cart.push(new CartItem(product, 1));
  }

  saveCart();
  return { success: true, message: 'Item added to cart.' };
}

export function updateCartItemQuantity(productId, action) {
  const item = cart.find(item => item.id === productId);

  if (!item) {
    return { success: false, message: 'Cart item not found.' };
  }

  if (action === 'increase') {
    if (item.quantity >= item.stock) {
      return { success: false, message: 'No more stock available.' };
    }

    item.quantity += 1;
  }

  if (action === 'decrease') {
    if (item.quantity > 1) {
      item.quantity -= 1;
    }
  }

  saveCart();
  return { success: true };
}

export function removeFromCart(productId) {
  cart = cart.filter(item => item.id !== productId);
  saveCart();
}

export function clearCart() {
  cart = [];
  saveCart();
}
