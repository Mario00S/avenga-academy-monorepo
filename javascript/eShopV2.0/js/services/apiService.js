import { BASE_URL, PRODUCTS_LIMIT } from '../config.js';
import { Product } from '../models/Product.js';

export const fetchProducts = async ({ limit = PRODUCTS_LIMIT, category = '', sortBy = '', order = '' } = {}) => {
  let url = `${BASE_URL}/products?limit=${limit}`;

  if (category) {
    url = `${BASE_URL}/products/category/${category}?limit=${limit}`;
  }

  if (sortBy && order) {
    url += `&sortBy=${sortBy}&order=${order}`;
  }

  const response = await fetch(url);

  if (!response.ok) {
    throw new Error(`Failed to fetch products: ${response.status}`);
  }

  const data = await response.json();
  return data.products.map(product => new Product(product));
};

export const fetchProductById = async id => {
  const response = await fetch(`${BASE_URL}/products/${id}`);

  if (!response.ok) {
    throw new Error(`Product not found: ${id}`);
  }

  const data = await response.json();
  return new Product(data);
};

export const searchProducts = async query => {
  const response = await fetch(`${BASE_URL}/products/search?q=${encodeURIComponent(query)}`);

  if (!response.ok) {
    throw new Error(`Failed to search products: ${response.status}`);
  }

  const data = await response.json();
  return data.products.map(product => new Product(product));
};

export const fetchCategories = async () => {
  const response = await fetch(`${BASE_URL}/products/categories`);

  if (!response.ok) {
    throw new Error(`Failed to fetch categories: ${response.status}`);
  }

  return await response.json();
};
