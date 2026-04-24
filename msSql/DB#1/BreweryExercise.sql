CREATE DATABASE BrewerySimpleDb;
GO

USE BrewerySimpleDb;
GO

CREATE TABLE Brewery
(
    BreweryId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Country NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE Beer
(
    BeerId INT IDENTITY(1,1) PRIMARY KEY,
    BreweryId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Style NVARCHAR(50) NULL,
    AlcoholPercent DECIMAL(4,2) NULL,

    CONSTRAINT FK_Beer_Brewery
        FOREIGN KEY (BreweryId) REFERENCES Brewery(BreweryId)
);
GO

CREATE TABLE Pub
(
    PubId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    Country NVARCHAR(100) NOT NULL
);
GO

INSERT INTO Brewery (Name, Country)
VALUES
    ('Anheuser-Busch InBev', 'Belgium'),
    ('Heineken', 'Netherlands'),
    ('Carlsberg Group', 'Denmark'),
    ('Molson Coors Beverage Company', 'United States'),
    ('Diageo', 'United Kingdom');
GO

INSERT INTO Beer (BreweryId, Name, Style, AlcoholPercent)
VALUES
    (1, 'Budweiser', 'Lager', 5.00),
    (1, 'Corona Extra', 'Pale Lager', 4.60),
    (1, 'Stella Artois', 'Pilsner', 5.00),
    (2, 'Heineken', 'Pale Lager', 5.00),
    (2, 'Amstel', 'Lager', 5.00),
    (3, 'Carlsberg Pilsner', 'Pilsner', 5.00),
    (3, 'Tuborg Green', 'Lager', 4.60),
    (4, 'Coors Light', 'Light Lager', 4.20),
    (4, 'Miller Lite', 'Light Lager', 4.20),
    (5, 'Guinness Draught', 'Stout', 4.20);
GO

INSERT INTO Pub (Name, City, Country)
VALUES
    ('The Olde Bar', 'Philadelphia', 'United States'),
    ('The American Bar', 'London', 'United Kingdom'),
    ('Harry''s Bar', 'Venice', 'Italy'),
    ('White Horse Tavern', 'New York', 'United States'),
    ('Al Brindisi', 'Ferrara', 'Italy');
GO