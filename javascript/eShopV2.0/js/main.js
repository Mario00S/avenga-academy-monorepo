import { fetchProducts, fetchCategories, searchProducts } from './services/apiService.js';
import {
  renderProducts,
  renderCategories,
  showLoading,
  hideLoading,
  showError,
  hideError
} from './utils/render.js';
import { addToCart, getCartCount } from './services/cartService.js';

const productsGrid = document.getElementById('productsGrid');
const categorySelect = document.getElementById('categorySelect');
const sortSelect = document.getElementById('sortSelect');
const searchInput = document.getElementById('searchInput');
const loadingState = document.getElementById('loadingState');
const errorState = document.getElementById('errorState');
const cartBadge = document.getElementById('cartBadge');

let currentProducts = [];

const updateCartBadge = () => {
  if (cartBadge) {
    cartBadge.textContent = getCartCount();
  }
};

const getSortValues = value => {
  switch (value) {
    case 'price-asc':
      return { sortBy: 'price', order: 'asc' };
    case 'price-desc':
      return { sortBy: 'price', order: 'desc' };
    case 'title-asc':
      return { sortBy: 'title', order: 'asc' };
    case 'title-desc':
      return { sortBy: 'title', order: 'desc' };
    default:
      return { sortBy: '', order: '' };
  }
};

const loadInitialData = async () => {
  try {
    showLoading(loadingState);
    hideError(errorState);

    const [products, categories] = await Promise.all([
      fetchProducts(),
      fetchCategories()
    ]);

    currentProducts = products;
    renderProducts(products, productsGrid);
    renderCategories(categories, categorySelect);
    updateCartBadge();
  } catch (error) {
    console.error(error);
    showError(errorState);
  } finally {
    hideLoading(loadingState);
  }
};

const handleFiltersChange = async () => {
  try {
    showLoading(loadingState);
    hideError(errorState);
    productsGrid.innerHTML = '';

    const category = categorySelect.value;
    const { sortBy, order } = getSortValues(sortSelect.value);

    const products = await fetchProducts({ category, sortBy, order });
    currentProducts = products;
    renderProducts(products, productsGrid);
  } catch (error) {
    console.error(error);
    showError(errorState);
  } finally {
    hideLoading(loadingState);
  }
};

const handleSearch = async event => {
  const query = event.target.value.trim();

  if (!query) {
    handleFiltersChange();
    return;
  }

  try {
    showLoading(loadingState);
    hideError(errorState);

    const products = await searchProducts(query);
    currentProducts = products;
    renderProducts(products, productsGrid);
  } catch (error) {
    console.error(error);
    showError(errorState);
  } finally {
    hideLoading(loadingState);
  }
};

productsGrid.addEventListener('click', event => {
  const addButton = event.target.closest('.add-to-cart-btn');

  if (!addButton) return;

  const productId = Number(addButton.dataset.id);
  const selectedProduct = currentProducts.find(product => product.id === productId);

  if (!selectedProduct) return;

  const result = addToCart(selectedProduct);
  updateCartBadge();
  alert(result.message);
});


categorySelect.addEventListener('change', handleFiltersChange);
sortSelect.addEventListener('change', handleFiltersChange);
searchInput.addEventListener('input', handleSearch);

loadInitialData();
