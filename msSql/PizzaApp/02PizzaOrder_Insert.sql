-- =========================
-- INSERT DATA
-- =========================

-- USERS
INSERT INTO Users (FirstName, LastName, Address, Phone)
VALUES
('John', 'Miller', 'Brooklyn, NY', '2125550101'),
('Emily', 'Johnson', 'Austin, TX', '5125550102'),
('Michael', 'Davis', 'Chicago, IL', '3125550103'),
('Sarah', 'Wilson', 'Seattle, WA', '2065550104'),
('Daniel', 'Moore', 'Denver, CO', '3035550105'),
('Olivia', 'Taylor', 'Phoenix, AZ', '6025550106'),
('Ethan', 'Anderson', 'Miami, FL', '3055550107'),
('Ava', 'Thomas', 'Boston, MA', '6175550108'),
('Jacob', 'Martinez', 'Nashville, TN', '6155550109'),
('Sophia', 'Harris', 'Portland, OR', '5035550110'),
('Noah', 'Clark', 'Dallas, TX', '2145550111'),
('Mia', 'Lewis', 'San Diego, CA', '6195550112'),
('Liam', 'Walker', 'Atlanta, GA', '4045550113'),
('Charlotte', 'Hall', 'Raleigh, NC', '9195550114'),
('James', 'Allen', 'Minneapolis, MN', '6125550115'),
('Amelia', 'Young', 'Sacramento, CA', '9165550116'),
('Benjamin', 'King', 'Columbus, OH', '6145550117'),
('Harper', 'Scott', 'Tampa, FL', '8135550118'),
('Lucas', 'Green', 'Kansas City, MO', '8165550119'),
('Evelyn', 'Baker', 'Charlotte, NC', '7045550120');


-- PIZZA SIZES
INSERT INTO PizzaSizes (Name)
VALUES
('Small'),
('Medium'),
('Large'),
('Family'),
('Extra Large'),
('Kids'),
('Party'),
('Thin Crust Medium'),
('Deep Dish Large'),
('Gluten Free Medium');


-- PIZZAS
INSERT INTO Pizzas (Name, Price, Description, SizeId)
VALUES
('Margherita', 300, 'Tomato sauce, mozzarella, basil', 2),
('Pepperoni', 420, 'Tomato sauce, mozzarella, pepperoni', 3),
('Capricciosa', 450, 'Ham, mushrooms, cheese', 3),
('Vegetarian', 390, 'Vegetables and cheese', 2),
('Quattro Formaggi', 500, 'Four cheese pizza', 3),
('BBQ Chicken', 520, 'Chicken, BBQ sauce, onion', 3),
('Tuna Pizza', 430, 'Tuna, onion, cheese', 2),
('Hawaiian', 460, 'Ham, pineapple, cheese', 3),
('Mexican', 480, 'Spicy beef, peppers, onion', 3),
('Prosciutto', 550, 'Prosciutto, mozzarella, rocket', 3);


-- TOPPINGS
INSERT INTO Toppings (Name, Price)
VALUES
('Extra Cheese', 60),
('Mushrooms', 40),
('Olives', 35),
('Pepperoni', 70),
('Ham', 60),
('Bacon', 80),
('Onion', 25),
('Peppers', 30),
('Chicken', 90),
('Corn', 30);


-- PIZZA DEFAULT TOPPINGS
INSERT INTO PizzaToppings (PizzaId, ToppingId)
VALUES
(1, 1), -- Margherita + Extra Cheese
(2, 4), -- Pepperoni + Pepperoni
(3, 5), -- Capricciosa + Ham
(3, 2), -- Capricciosa + Mushrooms
(4, 2), -- Vegetarian + Mushrooms
(4, 8), -- Vegetarian + Peppers
(5, 1), -- Quattro Formaggi + Extra Cheese
(6, 9), -- BBQ Chicken + Chicken
(7, 7), -- Tuna + Onion
(8, 5); -- Hawaiian + Ham


-- ORDERS
INSERT INTO Orders (UserId, IsDelivered, TotalPrice)
VALUES
(1, 1, 850),
(2, 0, 610),
(3, 1, 980),
(4, 0, 420),
(5, 1, 1120),
(6, 0, 520),
(7, 1, 585),
(8, 0, 505),
(9, 1, 1000),
(10, 0, 435),
(11, 1, 520),
(12, 0, 570),
(13, 1, 930),
(14, 0, 580),
(15, 1, 660),
(16, 0, 550),
(17, 1, 1070),
(18, 0, 575),
(19, 1, 560),
(20, 0, 1110);


-- ORDER DETAILS
-- Price = Pizza Base Price + Selected Toppings Price
INSERT INTO OrderDetails (PizzaId, OrderId, Quantity, Price)
VALUES
(1, 1, 1, 360), -- Margherita 300 + Extra Cheese 60
(2, 1, 1, 490), -- Pepperoni 420 + Pepperoni 70

(6, 2, 1, 610), -- BBQ Chicken 520 + Chicken 90

(3, 3, 2, 490), -- Capricciosa 450 + Mushrooms 40

(4, 4, 1, 420), -- Vegetarian 390 + Peppers 30

(5, 5, 2, 560), -- Quattro Formaggi 500 + Extra Cheese 60

(8, 6, 1, 520), -- Hawaiian 460 + Ham 60

(10, 7, 1, 585), -- Prosciutto 550 + Olives 35

(9, 8, 1, 505), -- Mexican 480 + Onion 25

(2, 9, 2, 500), -- Pepperoni 420 + Bacon 80

(1, 10, 1, 435), -- Margherita 300 + Extra Cheese 60 + Mushrooms 40 + Olives 35

(7, 11, 1, 520), -- Tuna Pizza 430 + Chicken 90

(8, 12, 1, 570), -- Hawaiian 460 + Bacon 80 + Corn 30

(4, 13, 2, 465), -- Vegetarian 390 + Mushrooms 40 + Olives 35

(6, 14, 1, 580), -- BBQ Chicken 520 + Extra Cheese 60

(10, 15, 1, 660), -- Prosciutto 550 + Bacon 80 + Peppers 30

(3, 16, 1, 550), -- Capricciosa 450 + Ham 60 + Mushrooms 40

(5, 17, 2, 535), -- Quattro Formaggi 500 + Olives 35

(9, 18, 1, 575), -- Mexican 480 + Pepperoni 70 + Onion 25

(2, 19, 1, 560), -- Pepperoni 420 + Extra Cheese 60 + Bacon 80

(1, 20, 3, 370); -- Margherita 300 + Mushrooms 40 + Corn 30


-- ORDER DETAIL TOPPINGS
INSERT INTO OrderDetailToppings (OrderDetailId, ToppingId)
VALUES
(1, 1), -- Extra Cheese

(2, 4), -- Pepperoni

(3, 9), -- Chicken

(4, 2), -- Mushrooms

(5, 8), -- Peppers

(6, 1), -- Extra Cheese

(7, 5), -- Ham

(8, 3), -- Olives

(9, 7), -- Onion

(10, 6), -- Bacon

(11, 1), -- Extra Cheese
(11, 2), -- Mushrooms
(11, 3), -- Olives

(12, 9), -- Chicken

(13, 6), -- Bacon
(13, 10), -- Corn

(14, 2), -- Mushrooms
(14, 3), -- Olives

(15, 1), -- Extra Cheese

(16, 6), -- Bacon
(16, 8), -- Peppers

(17, 5), -- Ham
(17, 2), -- Mushrooms

(18, 3), -- Olives

(19, 4), -- Pepperoni
(19, 7), -- Onion

(20, 1), -- Extra Cheese
(20, 6), -- Bacon

(21, 2), -- Mushrooms
(21, 10); -- Corn