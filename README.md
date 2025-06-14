
[Lab_01_AutomobileManagement_Using_EntityFramework and WPF.docx](https://github.com/user-attachments/files/20350109/Lab_01_AutomobileManagement_Using_EntityFramework.and.WPF.docx) (lab_0_requirement)
[MyStoreDB.docx](https://github.com/user-attachments/files/20734935/MyStoreDB.docx) (lab_0_db)

[Uploading SQLMcreate database MyStock;

create table Cars (
	CarID int primary key,
	CarName varchar(50),
	Manufacturer varchar(50),
	Price money,
	ReleasedYear int
);

INSERT INTO Cars (CarID, CarName, Manufacturer, Price, ReleasedYear) VALUES
(1, 'Accord', 'Honda Motor Company', 24970.0000, 2021),
(2, 'BMW 8 Series', 'BMW', 85000.0000, 2021),
(3, 'Clarity', 'Honda Motor Company', 33400.0000, 2021),
(4, 'Audi A6', 'Audi', 14000.0000, 2021),
(5, 'Everest Titanium 2.0L AT 4WD', 'Ford', 60000.0000, 2021),
(6, 'Ranger Wildtrak 2.0L AT 4x4', 'Ford', 40000.0000, 2021),
(7, 'Lexus IS', 'Lexus', 100000.0000, 2021),
(8, 'Lexus IS 300h', 'Lexus', 220000.0000, 2021);

use MyStock
select * from CarsyStock.docx…]()

[PRN222Lab_01_ProductManagement_ASP. NET Core Web App MVC.docx](https://github.com/user-attachments/files/20734909/PRN222Lab_01_ProductManagement_ASP.NET.Core.Web.App.MVC.docx) (lab_01_requirement)
[SQLMyStock.docx](https://github.com/user-attachments/files/20734933/SQLMyStock.docx) (lab_01_db)
[Uploadicreate database MyStoreDB;

USE MyStoreDB;
GO

-- Tạo bảng AccountMember
CREATE TABLE AccountMember (
    MemberID NVARCHAR(20) PRIMARY KEY,
    MemberPassword NVARCHAR(80) NOT NULL,
    FullName NVARCHAR(80) NOT NULL,
    EmailAddress NVARCHAR(100) NOT NULL,
    MemberRole INT NOT NULL
);
GO

-- Tạo bảng Categories
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName NVARCHAR(15) NOT NULL
);
GO

-- Tạo bảng Products
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(40) NOT NULL,
    CategoryID INT NOT NULL,
    UnitsInStock SMALLINT NULL,
    UnitPrice MONEY NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
GO

USE MyStoreDB;
GO

-- Chèn 3 tài khoản vào AccountMember
INSERT INTO AccountMember (MemberID, MemberPassword, FullName, EmailAddress, MemberRole) VALUES
('user1', 'pass1', 'Nguyen Thai Thuan', 'thuannt@example.com', 1),
('user2', 'pass2', 'Nguyen Tri Hoang Than', 'thannth@example.com', 2),
('user3', 'pass3', 'Nguyen Khoa Nam', 'Namnk@example.com', 3);
GO

-- Chèn 3 danh mục vào Categories
INSERT INTO Categories (CategoryID, CategoryName) VALUES
(1, 'Electronics'),
(2, 'Books'),
(3, 'Clothing');
GO

-- Chèn 10 sản phẩm vào Products, thuộc 3 danh mục trên
INSERT INTO Products ( ProductName, CategoryID, UnitsInStock, UnitPrice) VALUES
( 'Smartphone', 1, 50, 500.00),
('Laptop', 1, 30, 1200.00),
('Headphones', 1, 100, 80.00),
( 'Novel Book', 2, 200, 15.00),
( 'Science Book', 2, 150, 20.00),
( 'Comic Book', 2, 100, 10.00),
( 'T-Shirt', 3, 250, 12.50),
( 'Jeans', 3, 100, 40.00),
( 'Jacket', 3, 70, 60.00),
( 'Sneakers', 3, 120, 55.00);
GO

SELECT COLUMNPROPERTY(OBJECT_ID('Products'), 'ProductId', 'IsIdentity') AS IsIdentity
INSERT INTO Products (ProductName, CategoryID, UnitsInStock, UnitPrice) VALUES
('Test Product', 1, 10, 100);

SELECT * FROM Categories;


SET IDENTITY_INSERT dbo.Products ON;
ALTER TABLE Products
ALTER COLUMN CategoryID INT NOT NULL;ng MyStoreDB.docx…]()

