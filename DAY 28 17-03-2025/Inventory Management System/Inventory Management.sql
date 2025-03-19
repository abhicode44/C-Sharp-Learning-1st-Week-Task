CREATE TABLE Inventory (
	InventoryId INT PRIMARY KEY,
	Location VARCHAR(20)
);


INSERT INTO Inventory	(InventoryId , Location) VALUES 
(101 , 'Mumbai'),
(102 , 'Pune'),
(103 , 'Chennai'),
(104 , 'Hydrabad'),
(105 , 'Banglore' );

Select * From Inventory ;
Select * From Product;

CREATE TABLE Product (
	ProductId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20),
	Description VARCHAR(20),
	Quantity INT,
	Price INT,
	InventoryId INT,
	FOREIGN KEY (InventoryId) REFERENCES Inventory(InventoryId)
);


CREATE TABLE Supplier (
	SupplierId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20),
	Contact VARCHAR(20),
	Information VARCHAR(20),
	InventoryId INT,
	FOREIGN KEY (InventoryId) REFERENCES Inventory(InventoryId)
);

CREATE TABLE [Transaction] (
	TransactionId INT PRIMARY KEY IDENTITY,
	ProductId INT,
	FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
	Type VARCHAR(20),
	Quantity INT,
	TransactionDate DATE, 
	InventoryId INT,
	FOREIGN KEY (InventoryId) REFERENCES Inventory(InventoryId)
);

ALTER TABLE [Transaction]
ADD CONSTRAINT DF_TransactionDate DEFAULT GETDATE() FOR TransactionDate;



DELETE FROM [Transaction];

ALTER TABLE Product
DROP CONSTRAINT FK__Product__Invento__4222D4EF;