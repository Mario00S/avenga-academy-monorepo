# Restaurant Ordering Console App

Create a C# console app with role-based login.

Roles:
- Admin
- Waiter
- Customer

## Admin
- Add/remove waiters
- Add/remove customers
- Add/remove menu items
- View all users
- View all orders
- View total sales

## Waiter
- View menu items
- Create orders
- Add/remove items from orders
- View active orders
- Complete orders

## Customer
- View menu
- View current order
- View order history
- View total spent

## Rules
- Only available items can be ordered
- Completed orders cannot be edited
- Customers can only view their own orders
- Invalid input should be handled properly


===========================================================================================

# Restaurant Ordering Console App

## Project Brief

Create a **Restaurant Ordering Console Application** in C#.

The application should simulate a simple restaurant system where different users can log in and perform actions based on their role.

The goal of the project is to practice:
- Object-Oriented Programming
- Role-based menus
- Working with lists and dictionaries
- Input validation
- Separation of concerns
- Service-based application structure
- Console menu navigation

---

## Application Roles

The app should support the following roles:

- Admin
- Waiter
- Customer

Each role should log in and see different menu options.

---

## General Requirements

- The application must be a **console app**.
- The app must have a **main menu** for login.
- Users must log in with username and password.
- After login, users should be redirected to the correct menu based on their role.
- Each menu should only display actions allowed for that role.
- Invalid input should be handled properly.
- The app should use an in-memory database structure.

---

## Role Requirements

### Admin

The Admin can manage the system.

Admin options:
- Add a new waiter
- Remove a waiter
- Add a new customer
- Remove a customer
- Add a new menu item
- Remove a menu item
- View all users
- View all menu items
- View all orders
- View total sales
- Logout

Admin rules:
- Admin cannot remove itself
- Admin can see all registered users
- Admin can see all orders placed in the system
- Admin can see total earnings from completed orders

---

### Waiter

The Waiter handles restaurant orders.

Waiter options:
- View all menu items
- Create a new order for a customer
- Add item to an existing order
- Remove item from an existing order
- View all active orders
- Mark order as completed
- Logout

Waiter rules:
- A waiter can create orders only for existing customers
- A waiter can only add available menu items
- A completed order can no longer be edited
- A waiter should be able to calculate the total bill for an order

---

### Customer

The Customer can browse the menu and review personal orders.

Customer options:
- View menu
- View current active order
- View order history
- View total money spent
- Logout

Customer rules:
- A customer can only see their own orders
- A customer can have one active order at a time, or multiple if you choose to support it
- Completed orders should appear in order history
- Total money spent should be calculated from completed orders only

---

## Functional Requirements

### Login System

The app should:
- Ask for username
- Ask for password
- Validate credentials
- Identify the role of the logged-in user
- Redirect the user to the correct menu

---

### Menu Item Management

A menu item should contain at least:
- Name
- Category
- Price
- Availability status

Example categories:
- Food
- Drink
- Dessert

Admin should be able to:
- Add menu items
- Remove menu items
- View all menu items

---

### Order Management

An order should contain:
- Order ID
- Customer
- Waiter
- Ordered items
- Total price
- Status

Example statuses:
- Active
- Completed
- Cancelled

The system should be able to:
- Create orders
- Add items to orders
- Remove items from orders
- Mark orders as completed
- Show a bill for an order

---

### Sales Tracking

The app should support:
- Tracking completed orders
- Calculating total revenue
- Viewing how much each customer has spent
- Viewing all completed orders

---

## Suggested Class Structure

### Models

Create classes such as:
- `User`
- `Admin`
- `Waiter`
- `Customer`
- `MenuItem`
- `Order`

You may also use:
- `Role` enum
- `OrderStatus` enum
- `FoodCategory` enum

---

## Suggested Properties

### User
- FirstName
- LastName
- Username
- Password
- Age
- Role

### MenuItem
- Name
- Category
- Price
- IsAvailable

### Order
- Id
- CustomerUsername or Customer object
- WaiterUsername or Waiter object
- List of ordered items
- TotalPrice
- Status

### Customer
- OrderHistory
- ActiveOrder or ActiveOrders
- TotalSpent

---

## Data Storage

Create a `Database` class that stores in-memory collections.

Example:
- `List<Admin> Admins`
- `List<Waiter> Waiters`
- `List<Customer> Customers`
- `List<MenuItem> MenuItems`
- `List<Order> Orders`

The database should start with some hardcoded sample data.

---

## Service Layer

Create service classes for handling logic.

Suggested services:
- `AdminService`
- `WaiterService`
- `CustomerService`
- `OrderService`
- `MenuItemService`

Responsibilities:
- Return data
- Validate actions
- Create and remove entities
- Update orders
- Calculate totals

---

## UI / Menu Layer

Create a menu or UI/controller class responsible for:
- Showing menus
- Reading user input
- Printing output
- Calling service methods
- Navigating between menus

Suggested methods:
- `InitApp()`
- `AdminUI(Admin loggedAdmin)`
- `WaiterUI(Waiter loggedWaiter)`
- `CustomerUI(Customer loggedCustomer)`
- `ViewMenuItems()`
- `ViewOrders()`
- `Pause()`

---

## Business Rules

- Menu items with `IsAvailable = false` cannot be ordered
- Orders marked as completed cannot be changed
- Customers can only view their own order history
- Total price must be recalculated whenever items are added or removed
- Admin has full access to restaurant data
- Waiters can manage orders but not users
- Customers cannot edit restaurant data

---

## Input Validation

The application should validate:
- Login credentials
- Menu choices
- Item selection
- Numeric inputs for price
- Valid IDs for orders
- Empty input values

The app should not crash on invalid input.

---

## Minimum Features to Complete

To consider the app complete, implement at least:

- Role-based login
- Separate menus for Admin, Waiter, and Customer
- Add/remove users
- Add/remove menu items
- View all menu items
- Create an order
- Add items to an order
- View current order
- View order history
- Mark order as completed
- Show total sales

---

## Optional Bonus Features

If you want to extend the project, add:

- Search menu items by category
- Filter only available items
- Cancel orders
- Show the most ordered item
- Show how many orders each waiter handled
- Save and load data from a file
- Add table numbers
- Add discounts
- Add taxes to the final bill

---

## Example Flow

### Admin
1. Log in
2. Choose to manage users or menu items
3. Add or remove data
4. View reports
5. Logout

### Waiter
1. Log in
2. View menu
3. Create an order for a customer
4. Add items
5. Complete the order
6. Logout

### Customer
1. Log in
2. View menu
3. View current active order
4. View previous completed orders
5. View total spent
6. Logout

---

## Technical Goal

The focus of the exercise is not only to make the app work, but also to structure it well.

Try to keep:
- UI code in menu/controller classes
- Business logic in service classes
- Data in model/database classes

Avoid putting all logic in one file.

---

## Final Goal

Build a working C# console restaurant application that demonstrates:
- OOP
- Clean menu navigation
- Role-based access
- Basic business logic
- Good code organization