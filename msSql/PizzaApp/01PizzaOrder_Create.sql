use master 
go

alter database [PizzaOrdering] 
set single_user
with rollback immediate;
go

drop database if exists PizzaOrdering

create database [PizzaOrdering]
go


use [PizzaOrdering]
go


-- ==================
-- DROP TABLES
-- ==================

drop table if exists Users
drop table if exists Pizzas
drop table if exists PizzaSizes
drop table if exists Toppings
drop table if exists Orders
drop table if exists OrderDetails
drop table if exists PizzaToppings
drop table if exists OrderDetailToppings


-- ==================
-- CREATE TABLES
-- ==================

create table Users(
	Id int identity(1,1) primary key,
	FirstName nvarchar(100) not null,
	LastName nvarchar(100) not null,
	Address nvarchar(150) not null,
	Phone nvarchar(30) not null
)

create table Pizzas(
	Id int identity(1,1) primary key,
	Name nvarchar(100) not null,
	Price decimal(10,2) not null,
	Description nvarchar(max),
	SizeId int not null
)

create table PizzaSizes(
	Id int identity(1,1) primary key,
	Name nvarchar(50) not null
)

create table Toppings(
	Id int identity(1,1) primary key,
	Name nvarchar(100) not null,
	Price decimal(4,2) not null
)


create table Orders(
	Id int identity(1,1) primary key,
	UserId int not null,
	IsDelivered bit not null DEFAULT 0,
	TotalPrice decimal(10,2) not null
)

create table OrderDetails(
	Id int identity(1,1) primary key,
	PizzaId int not null,
	OrderId int not null,
	Quantity int not null,
	Price decimal(10,2) not null
)

create table PizzaToppings(
	Id int identity(1,1) primary key,
	PizzaId int not null,
	ToppingId int not null
)

create table OrderDetailToppings(
	Id int identity(1,1) primary key,
	OrderDetailId int not null,
	ToppingId int not null
)

-- ==================
-- ADD FOREIGN KEY CONSTRAINTS
-- ==================

alter table Pizzas
add constraint FK_Pizzas_PizzaSizes
foreign key (SizeId) references PizzaSizes(Id)

alter table PizzaToppings
add constraint FK_PizzaToppings_Pizzas
foreign key (PizzaId) references Pizzas(Id)

alter table PizzaToppings
add constraint FK_PizzaToppings_Toppings
foreign key (ToppingId) references Toppings(Id)

alter table Orders
add constraint FK_Orders_Users
foreign key (UserId) references Users(Id)

alter table OrderDetails
add constraint FK_OrderDetails_Pizzas
foreign key (PizzaId) references Pizzas(Id)

alter table OrderDetails
add constraint FK_OrderDetails_Orders
foreign key (OrderId) references Orders(Id)

alter table OrderDetailToppings
add constraint FK_OrderDetailToppings_OrderDetails
foreign key (OrderDetailId) references OrderDetails(Id)

alter table OrderDetailToppings
add constraint FK_OrderDetailToppings_Toppings
foreign key (ToppingId) references Toppings(Id)
