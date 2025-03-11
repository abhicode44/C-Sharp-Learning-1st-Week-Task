CREATE TABLE Suppliers(
	SupplierID INT PRIMARY KEY,
	Name VARCHAR(20),
	ContactInfo VARCHAR(20) ,
	Address VARCHAR(20)
);


CREATE TABLE Products (
	ProductID INT PRIMARY KEY,
	Name VARCHAR(20),
	Description VARCHAR(20) ,
	SupplierID INT , 
	FOREIGN KEY(SupplierID) REFERENCES Suppliers(SupplierID) 
);

CREATE TABLE Orders (
	OrderID INT PRIMARY KEY ,
	OrderDate Date ,
	SuppierID INT , 
	FOREIGN KEY(SupplierID) REFERENCES Suppliers(SupplierID) 
);

CREATE TABLE OrderDetails (
	OrderDetailID INT PRIMARY KEY ,
	OrderID INT
	FOREIGN KEY(OrderID) REFERENCES Orders(OrderID),
	ProductID INT 
	FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
	Quantity INT ,
	Price INT
);

CREATE TABLE Inventory (
	InventoryID INT PRIMARY KEY ,
	ProductID INT 
	FOREIGN KEY(ProductID) REFERENCES Products(ProductID),
	QuantityOnHand Int ,
);


INSERT INTO Suppliers(SupplierID,Name,ContactInfo,Address) VALUES 
( 1 ,'Supplier A' , 'contactA@example.com' , 'Address A' ),
( 2 ,'Supplier B' , 'contactB@example.com' , 'Address B'),
( 3 ,'Supplier C' , 'contactC@example.com' , 'Address C' ),
( 4 ,'Supplier D' , 'contactD@example.com' , 'Address D' );

INSERT INTO Products(ProductID,Name,Description,SuppierID) VALUES 
( 1 , 'Product 1'  , 'Description 1' , 1 ),
( 2 , 'Product 2'  , 'Description 2' , 1),
( 3 , 'Product 3'  , 'Description 3' , 2),
( 4 , 'Product 4'  , 'Description 4' , 3),
( 5 , 'Product 5'  , 'Description 5' , 3),
( 6 , 'Product 1'  , 'Description 6' , 3);

INSERT INTO Orders (OrderID, OrderDate, SuppierID) VALUES 
(1 , '2024-07-01' , 1), 
(2 , '2024-07-05' , 2), 
(3 , '2024-07-10' , 3), 
(4 , '2024-07-15' , 1), 
(5 , '2024-07-20' , 2),
(6 , '2024-08-05' , 1),
(7 , '2024-08-30' , 3),
(8 , '2024-08-15', 3),
(9 , '2024-09-12', 2);



INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity, Price) VALUES 
( 1 , 1 , 1 , 10 , 100 ), 
(2, 1, 2, 5, 200), 
(3, 2, 3, 15, 150), 
(4, 3, 4, 20, 250), 
(5, 3, 5, 25, 300), 
(6, 4, 1, 10, 100), 
(7, 4, 3, 5, 150), 
(8, 5, 2, 10, 200), 
(9, 5, 4, 15, 250),
(10,6,5,30,500),
(11,7,4,28, 400),
(12,8,6,9, 450),
(13, 9 , 3 , 35 , 100 );


INSERT INTO Inventory (InventoryID, ProductID, QuantityOnHand) VALUES 
(1, 1, 50), 
(2, 2, 30), 
(3, 3, 20), 
(4, 4, 15), 
(5, 5, 10),
(6, 6, 40);



SELECT  * FROM  Products ;
SELECT  * FROM  Orders ;
SELECT  * FROM  Suppliers ;
SELECT  * FROM  OrderDetails ;
SELECT  * FROM  Inventory;



-- 1. List All Products along with their supplier name 
SELECT P.ProductID , P.Name , P.Description ,  S.Name
FROM Products P
RIGHT JOIN Suppliers S ON P.SuppierID = S.SupplierID ;

-- 2. Gets all orders with their details ( including products names and quantities )
SELECT Od.OrderDetailID , Od.OrderID , Od.Price , Od.ProductID ,Od.Quantity , P.Name , o.orderDate , o.SuppierID
FROM OrderDetails Od
JOIN Orders o ON o.OrderID = od.OrderDetailID
JOIN Products P ON P.ProductID = Od.ProductID

-- 3. Find all suppliers who have supplied a specific product 
SELECT P.Name ,   S.Name  
FROM Products P
JOIN Suppliers S ON P.SuppierID = S.SupplierID WHERE P.ProductID = '2' ; 

-- 4. List all products and their current inventory levels
SELECT P.Name , I.QuantityOnHand
FROM Products P 
Join Inventory I ON P.ProductID = I.InventoryID 

 

--Find all orders with Date 
SELECT Od.OrderDetailID , Od.Price , od.Quantity , o.OrderDate  , o.OrderID
FROM Orders O 
JOIN OrderDetails Od ON O.OrderID = Od.OrderID

--Dates in Desc form 
SELECT DISTINCT OrderDate FROM Orders ORDER BY OrderDate DESC;

-- 5. Find all orders placed within last month
SELECT O.OrderID, Od.Price, Od.Quantity, O.OrderDate , P.Name
FROM Orders O
JOIN OrderDetails Od ON O.OrderID = Od.OrderID
JOIN Products P ON P.ProductID = od.ProductID
WHERE MONTH(OrderDate) > ( SELECT MONTH(Max(OrderDate))-1 FROM Orders );


-- 6. Get Total Quantity ordered for each product
SELECT P.Name, SUM(Od.Quantity) AS TotalQuantityOrdered
FROM OrderDetails Od
JOIN Products P ON P.ProductID = Od.ProductID
GROUP BY P.Name;

-- 7. Retirve All Orders Along with the total amount spent for each order
SELECT O.OrderID, SUM(Od.Price * Od.Quantity) AS TotalAmountSpent
FROM Orders O
JOIN OrderDetails Od ON O.OrderID = Od.OrderID
GROUP BY O.OrderID;

-- 8. find products supplied by more than one supplier 
SELECT p.Name AS ProductName, COUNT(DISTINCT S.SupplierID) AS SupplierCount 
FROM Products p
JOIN Suppliers S ON P.SuppierID = S.SupplierID
GROUP BY p.Name
HAVING COUNT(DISTINCT S.SupplierID) > 1;

-- 9. Get the average inventory level for each product 
SELECT P.Name AS ProductName, AVG(I.QuantityOnHand) AS AverageInventoryLevel
FROM Products P
JOIN Inventory I ON P.ProductID = I.ProductID
GROUP BY P.Name;

-- 10. List the supplier who has not supplied any products
SELECT S.Name AS SupplierName
FROM Suppliers S
LEFT JOIN Products P ON S.SupplierID = P.SuppierID
WHERE P.ProductID IS NULL;

