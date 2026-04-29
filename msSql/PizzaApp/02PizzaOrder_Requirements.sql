--⚙️ Extra Requirements
--Create a function that concatenates First and Last Name of a user
--Create a view for all undelivered pizzas with user full names
--Create a view:
--Pizzas ordered by popularity (most ordered first)
--Create a view:
--Toppings ordered by popularity
--Create a view:
--Users and total pizzas they ordered

--Create a function that concatenates First and Last Name of a user
create or alter function dbo.GetUserFullName(
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
)
returns nvarchar(101)
as
begin
	return concat(@Firstname, ' ', @LastName);
	end
	GO

select dbo.GetUserFullName(FirstName,LastName) as UserFullName
from Users
go

--Create a view for all undelivered pizzas with user full names
create or alter view dbo.vw_UndeliveredPizzas
as
select 
o.Id,
dbo.GetUserFullName(u.FirstName, u.LastName) as UserFullName,
p.Name as PizzaName,
od.Price as SingleItemPrice,
od.Quantity * od.Price as TotalOrderPrice
from
Orders o
inner join Users u on u.Id = o.UserId
inner join OrderDetails od on od.OrderId = o.Id
inner join Pizzas p on p.Id = od.PizzaId
where o.IsDelivered = 0

select * from dbo.vw_UndeliveredPizzas

--Pizzas ordered by popularity (most ordered first)
create or alter view vw_PizzasByPopularity
as
select 
p.Id,
p.Name as PizzaName,
sum(od.Quantity) as TotalQuantity
from
Pizzas p
inner join OrderDetails od on od.PizzaId = p.Id
group by p.Id, p.Name
go

select * from dbo.vw_PizzasByPopularity

Create a view:
Toppings ordered by popularity
create or alter view vw_ToppingsByPopularity
as
select
t.Id as ToppingId,
t.Name as ToppingName,
count(odt.Id) as TimesAdded,
sum(od.Quantity) as TotalQuantityOrdered
from Toppings t
inner join OrderDetailToppings odt on t.Id = odt.ToppingId
inner join OrderDetails od on odt.ToppingId = od.Id
group by t.Id, t.Name


select * from vw_ToppingsByPopularity order by TotalQuantityOrdered desc
select * from OrderDetailToppings
select * from OrderDetails
select * from PizzaToppings

--Users and total pizzas they ordered
select * from Users
select * from Orders
select * from OrderDetails
select * from Pizzas

create or alter view vw_TotalPizzasByUser
as
select 
--u.Id as UserId,
dbo.GetUserFullName(FirstName,LastName) as FullName,
sum(od.Quantity) as TotalPizzasOrdered
from Users u
inner join Orders o on u.Id = o.UserId
inner join OrderDetails od on o.Id = od.OrderId
Group by dbo.GetUserFullName(u.FirstName,u.LastName)

select * from vw_TotalPizzasByUser order by TotalPizzasOrdered desc