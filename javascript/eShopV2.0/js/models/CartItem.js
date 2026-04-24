export class CartItem {
  constructor(product, quantity = 1) {
    this.id = product.id;
    this.name = product.name;
    this.price = product.price;
    this.image = product.image;
    this.stock = product.stock;
    this.quantity = quantity;
  }

  get lineTotal() {
    return this.price * this.quantity;
  }

  get formattedTotal() {
    return `$${this.lineTotal.toFixed(2)}`;
  }
}
