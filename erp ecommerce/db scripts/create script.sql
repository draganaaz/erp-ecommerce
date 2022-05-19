-- dropping constraints
alter table shop.ProductSizes drop constraint FK_ProductSizes_Size
alter table shop.ProductColors drop constraint FK_ProductColors_Color
alter table shop.Product drop constraint FK_Product_ProductSizes
alter table shop.Product drop constraint FK_Product_ProductColors
alter table shop.Product drop constraint FK_Product_Category
alter table shop.Product drop constraint FK_Product_Brand
alter table shop.ProductSizes drop constraint FK_ProductSizes_Product
alter table shop.ProductColors drop constraint FK_ProductColors_Product
alter table shop.Orders drop constraint FK_Order_Orders
alter table shop.Orders drop constraint FK_Order_Users
alter table shop.Orders drop constraint FK_Order_OrderDetails

-- deleting tables
if object_id('shop.Brand', 'U') is not null
drop table shop.Brand;
go

if object_id('shop.Category', 'U') is not null
drop table shop.Category;
go

if object_id('shop.Users', 'U') is not null
drop table shop.Users;
go

if object_id('shop.ProductSizes', 'U') is not null
drop table shop.ProductSizes;
go

if object_id('shop.ProductColors', 'U') is not null
drop table shop.ProductColors;
go

if object_id('shop.Size', 'U') is not null
drop table shop.Size;
go

if object_id('shop.Color', 'U') is not null
drop table shop.Color;
go

if object_id('shop.Product', 'U') is not null
drop table shop.Product;
go

if object_id('shop.Orders', 'U') is not null
drop table shop.Orders;
go
	

-- deleting schema
drop schema shop
go

-- creating schema
create schema shop
go

-- creating tables
create table shop.Category (
	CategoryID int identity(1,1),
	Category nvarchar(50) not null,
	constraint PK_Category primary key(CategoryID),
);

create table shop.Brand (
	BrandID int identity(1,1),
	Brand nvarchar(50) not null,
	constraint PK_Brand primary key(BrandID),
);

create table shop.Product (
	ProductID int identity(1,1),
	Name varchar(60) not null,
	Description varchar(300) not null,
	IsAvailable bit,
	ProductSizeID int,
	ProductColorID int,
	Price numeric(10, 2),
	Discount int,
	CategoryID int,
	BrandID int,
	ProductType nvarchar(10), 
	constraint PK_Product primary key(ProductID),
	constraint CHK_Product_ProductType check (ProductType in ('Musko', 'Zensko', 'Decije')),
	constraint FK_Product_Category foreign key (CategoryID)
		references shop.Category (CategoryID) on delete cascade,
	constraint FK_Product_Brand foreign key (BrandID)
		references shop.Brand (BrandID) on delete cascade 
);

-- Sizes
create table shop.Size (
	SizeID int identity(1,1),
	Size nvarchar(5) not null,
	constraint PK_Size primary key(SizeID)
);

create table shop.ProductSizes (
	ProductSizeID int identity(1,1),
	ProductID int not null,
	SizeID int not null,
	constraint PK_ProductSizes primary key(ProductSizeID), 
	constraint FK_ProductSizes_Size foreign key (SizeID)
		references shop.Size (SizeID) on delete cascade,
	constraint FK_ProductSizes_Product foreign key (ProductID)
		references shop.Product (ProductID) on delete cascade 
);

-- Colors
create table shop.Color (
	ColorID int identity(1,1),
	Color nvarchar(20) not null,
	constraint PK_Color primary key(ColorID)
);

create table shop.ProductColors (
	ProductColorID int identity(1,1),
	ProductID int not null,
	ColorID int not null,
	constraint PK_ProductColors primary key(ProductColorID),
	constraint FK_ProductColors_Color foreign key (ColorID)
		references shop.Color (ColorID) on delete cascade,
	constraint FK_ProductColors_Product foreign key (ProductID)
		references shop.Product (ProductID) on delete cascade
);


-- Users
create table shop.Users (
	UserID int identity(1,1),
	Email nvarchar(100) not null,
	Password nvarchar(300) not null,
	Name nvarchar(50) not null,
	PhoneNumber nvarchar(150) not null,
	Role nvarchar(10) not null,
	constraint PK_UserID primary key(UserID),
	constraint CHK_Users_Role check (Role in ('Admin', 'Customer'))
);


create table shop.Orders (
	OrderID int identity(1,1),
	Name nvarchar(50) not null,
	Surname nvarchar(50) not null,
	Address nvarchar(200) not null,
	City nvarchar(200) not null,
	Country nvarchar(200) not null,
	DateCreated datetime not null,
	TotalPrice numeric(10, 2) not null,
	isPaymentDone bit, 
	constraint PK_Order primary key(OrderID)
);
