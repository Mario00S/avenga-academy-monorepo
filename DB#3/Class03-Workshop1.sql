--🧪 WORKSHOP 01
--Calculate the total amount on all orders in the system
--Calculate the total amount per BusinessEntity on all orders
--Calculate the total amount per BusinessEntity from Customers with ID < 20
--Find Max Order amount and Avg Order amount per BusinessEntity
--Suggest your own analytical question from Orders


--Calculate the total amount on all orders in the system
select sum (TotalPrice) as TotalRevenue from Orders;


--Calculate the total amount per BusinessEntity on all orders
select sum (TotalPrice) as TotalRevenue, be.[Name] as BusinessEntityName
from Orders o
inner join BusinessEntities be
on o.BusinessEntityId = be.Id
group by be.[Name];


--Calculate the total amount per BusinessEntity from Customers with ID < 20
select sum (TotalPrice) as TotalRevenue, be.[Name] as BusinessEntityName
from Orders o
join Customers c on o.CustomerId = c.Id
join BusinessEntities be on o.BusinessEntityId = be.Id
where c.Id < 20
group by be.[Name];

--Find Max Order amount and Avg Order amount per BusinessEntity
select max (TotalPrice) as MaxRevenue, avg (TotalPrice) as AvgRevenue, be.[Name] as BusinessEntityName
from Orders o
inner join BusinessEntities be
on o.BusinessEntityId = be.Id
group by be.[Name];


--which employee has the highest total order count?
select max (TotalOrders) as MaxTotalOrders
from (
	select count (EmployeeId) as TotalOrders, e.FirstName, e.LastName
	from Orders o
	join Employees e
	on o.EmployeeId = e.Id
	group by e.FirstName, e.LastName
) as EmployeeOrders;

--list the total number of orders per employee
select count (EmployeeId) as TotalOrders, e.FirstName, e.LastName
from Orders o
join Employees e
on o.EmployeeId = e.Id
group by e.FirstName, e.LastName
order by TotalOrders desc;


--which date has the highest total revenue amount?
select max (TotalRevenue) as MaxTotalRevenue
from (
	select sum (TotalPrice) as TotalRevenue, OrderDate
	from Orders o
	group by OrderDate
) as RevenuePerDate;

--list the total revenue per date
select sum (TotalPrice) as TotalRevenue, OrderDate
from Orders o
group by OrderDate
order by TotalRevenue desc;


--Suggest your own analytical question from Orders
--Extra exercises

-- Which employee generated the highest total revenue?
select top 1
    e.FirstName,
    e.LastName,
    sum(o.TotalPrice) as TotalRevenue
from Orders o
join Employees e on o.EmployeeId = e.Id
group by e.FirstName, e.LastName
order by TotalRevenue desc;

-- How many orders has each customer made?
select 
    c.Id,
    c.[Name],
    count(o.Id) as TotalOrders
from Customers c
join Orders o on c.Id = o.CustomerId
group by c.Id, c.[Name]
order by TotalOrders desc;


-- Which customer spent the most money in total?
select top 1
    c.Id,
    c.[Name],
    sum(o.TotalPrice) as TotalSpent
from Customers c
join Orders o on c.Id = o.CustomerId
group by c.Id, c.[Name]
order by TotalSpent desc;


-- What is the average order amount per customer?
select
    c.Id,
    c.[Name],
    avg(o.TotalPrice) as AvgOrderAmount
from Customers c
join Orders o on c.Id = o.CustomerId
group by c.Id, c.[Name]
order by AvgOrderAmount desc;


-- Which employee generated the highest total revenue?
select top 1
    e.Id,
    e.FirstName,
    e.LastName,
    sum(o.TotalPrice) as TotalRevenue
from Employees e
join Orders o on e.Id = o.EmployeeId
group by e.Id, e.FirstName, e.LastName
order by TotalRevenue desc;


-- What is the average order value per employee?
select
    e.Id,
    e.FirstName,
    e.LastName,
    avg(o.TotalPrice) as AvgOrderValue
from Employees e
join Orders o on e.Id = o.EmployeeId
group by e.Id, e.FirstName, e.LastName
order by AvgOrderValue desc;


-- What is the total revenue per month?
select
    year(OrderDate) as OrderYear,
    month(OrderDate) as OrderMonth,
    sum(TotalPrice) as TotalRevenue
from Orders
group by year(OrderDate), month(OrderDate)
order by OrderYear, OrderMonth;


-- On which date was the highest number of orders made?
select top 1
    OrderDate,
    count(Id) as TotalOrders
from Orders
group by OrderDate
order by TotalOrders desc;


-- What is the running total of revenue by date?
select
    OrderDate,
    sum(TotalPrice) as DailyRevenue,
    sum(sum(TotalPrice)) over (order by OrderDate) as RunningRevenue
from Orders
group by OrderDate
order by OrderDate;


-- Which orders are above the average order amount?
select
    Id,
    CustomerId,
    EmployeeId,
    BusinessEntityId,
    TotalPrice
from Orders
where TotalPrice > (
    select avg(TotalPrice)
    from Orders
)
order by TotalPrice desc;


-- What is the largest order for each customer?
select
    c.Id,
    c.[Name],
    max(o.TotalPrice) as MaxOrderAmount
from Customers c
join Orders o on c.Id = o.CustomerId
group by c.Id, c.[Name]
order by MaxOrderAmount desc;