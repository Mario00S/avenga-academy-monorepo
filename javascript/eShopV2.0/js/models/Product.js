export class Product {
  constructor({ id, title, price, description, category, thumbnail, rating, stock }) {
    this.id = id;
    this.name = title;
    this.price = price;
    this.description = description;
    this.category = category;
    this.image = thumbnail;
    this.rating = rating ?? 0;
    this.stock = stock ?? 0;
  }

  get formattedPrice() {
    return `$${this.price.toFixed(2)}`;
  }

  get shortDescription() {
    return this.description.length > 80
      ? `${this.description.slice(0, 80)}...`
      : this.description;
  }

  get isInStock() {
    return this.stock > 0;
  }
}
