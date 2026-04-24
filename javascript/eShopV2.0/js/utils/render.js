import { formatPrice } from './helpers.js';

export const renderProducts = (products, container) => {
  container.innerHTML = products
    .map(product => {
      return `
        <div class="col-12 col-sm-6 col-lg-4 col-xl-3">
          <article class="card h-100 shadow-sm product-card">
            <img
              src="${product.image}"
              alt="${product.name}"
              class="card-img-top product-image"
            />

            <div class="card-body d-flex flex-column">
              <span class="badge bg-secondary text-capitalize align-self-start mb-2">
                ${product.category}
              </span>

              <h3 class="product-title h6">${product.name}</h3>

              <p class="text-muted small product-description">
                ${product.shortDescription}
              </p>

              <p class="mb-1 small">Rating: ${product.rating}</p>

              <p class="mb-3 small ${product.isInStock ? 'text-success' : 'text-danger'}">
                ${product.isInStock ? `In stock (${product.stock})` : 'Out of stock'}
              </p>

              <div class="mt-auto">
                <p class="product-price mb-3">${product.formattedPrice}</p>

                <div class="d-flex gap-2">
                  <a href="./product.html?id=${product.id}" class="btn btn-outline-primary btn-sm w-50">
                    Details
                  </a>
                  <button
                    class="btn btn-primary btn-sm w-50 add-to-cart-btn"
                    data-id="${product.id}"
                    ${!product.isInStock ? 'disabled' : ''}
                  >
                    ${product.isInStock ? 'Add to Cart' : 'Unavailable'}
                  </button>
                </div>
              </div>
            </div>
          </article>
        </div>
      `;
    })
    .join('');
};


export const renderCategories = (categories, selectElement) => {
  const options = categories
    .map(category => `<option value="${category.slug}">${category.name}</option>`)
    .join('');

  selectElement.innerHTML += options;
};

export const renderProductDetails = (product, container) => {
  container.innerHTML = `
    <div class="row g-4 align-items-start">
      <div class="col-md-6">
        <img src="${product.image}" alt="${product.name}" class="img-fluid rounded shadow-sm w-100 details-image">
      </div>

      <div class="col-md-6">
        <span class="badge bg-secondary text-capitalize mb-3">${product.category}</span>
        <h1 class="mb-3">${product.name}</h1>
        <p class="text-muted">Rating: ${product.rating}</p>
        <p>${product.description}</p>
        <p class="product-price mb-2">${product.formattedPrice}</p>
        <p class="${product.isInStock ? 'text-success' : 'text-danger'}">
          ${product.isInStock ? `In stock (${product.stock})` : 'Out of stock'}
        </p>

        <button
          class="btn btn-primary mt-3 add-to-cart-btn"
          data-id="${product.id}"
          ${!product.isInStock ? 'disabled' : ''}
        >
          ${product.isInStock ? 'Add to Cart' : 'Unavailable'}
        </button>
      </div>
    </div>
  `;
};


export const renderCartItems = (cart, container) => {
  if (!cart.length) {
    container.innerHTML = `
      <div class="text-center py-5">
        <h2>Your cart is empty</h2>
        <p class="text-muted">Looks like you haven't added anything yet.</p>
        <a href="./index.html" class="btn btn-primary">Continue Shopping</a>
      </div>
    `;
    return;
  }

  container.innerHTML = cart
    .map(item => {
      return `
        <article class="card mb-3 shadow-sm">
          <div class="card-body">
            <div class="row align-items-center g-3">
              <div class="col-md-2">
                <img src="${item.image}" alt="${item.name}" class="img-fluid rounded cart-image">
              </div>

              <div class="col-md-4">
  <h3 class="h6 mb-1">${item.name}</h3>
  <p class="text-muted mb-1">${formatPrice(item.price)}</p>
  <p class="text-muted mb-0 small">Available stock: ${item.stock}</p>
</div>


              <div class="col-md-3">
                <div class="d-flex align-items-center gap-2">
                  <button
  class="btn btn-outline-secondary btn-sm qty-btn"
  data-action="decrease"
  data-id="${item.id}"
  ${item.quantity <= 1 ? 'disabled' : ''}
>
  -
</button>

<span>${item.quantity}</span>

<button
  class="btn btn-outline-secondary btn-sm qty-btn"
  data-action="increase"
  data-id="${item.id}"
  ${item.quantity >= item.stock ? 'disabled' : ''}
>
  +
</button>

                </div>
              </div>

              <div class="col-md-2">
                <strong>${formatPrice(item.price * item.quantity)}</strong>
              </div>

              <div class="col-md-1 text-md-end">
                <button class="btn btn-danger btn-sm remove-btn" data-id="${item.id}">x</button>
              </div>
            </div>
          </div>
        </article>
      `;
    })
    .join('');
};

export const renderCartSummary = (subtotal, container) => {
  const shipping = subtotal > 0 ? 10 : 0;
  const tax = subtotal * 0.1;
  const total = subtotal + shipping + tax;

  container.innerHTML = `
    <div class="card shadow-sm">
      <div class="card-body">
        <h2 class="h4 mb-4">Order Summary</h2>
        <div class="d-flex justify-content-between mb-2">
          <span>Subtotal</span>
          <span>${formatPrice(subtotal)}</span>
        </div>
        <div class="d-flex justify-content-between mb-2">
          <span>Shipping</span>
          <span>${formatPrice(shipping)}</span>
        </div>
        <div class="d-flex justify-content-between mb-3">
          <span>Tax</span>
          <span>${formatPrice(tax)}</span>
        </div>
        <hr>
        <div class="d-flex justify-content-between fw-bold mb-3">
          <span>Total</span>
          <span>${formatPrice(total)}</span>
        </div>
        <a href="./checkout.html" class="btn btn-primary w-100 ${subtotal === 0 ? 'disabled' : ''}">
          Proceed to Checkout
        </a>
      </div>
    </div>
  `;
};

export const showLoading = element => {
  element.classList.remove('d-none');
};

export const hideLoading = element => {
  element.classList.add('d-none');
};

export const showError = element => {
  element.classList.remove('d-none');
};

export const hideError = element => {
  element.classList.add('d-none');
};
