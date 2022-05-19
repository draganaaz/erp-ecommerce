insert into shop.Category (Category)
values
	('Category 1'),
	('Category 2'),
	('Category 3'),
	('Category 4'),
	('Category 5');

insert into shop.Brand (Brand)
values 
	('Brand 1'),
	('Brand 2'),
	('Brand 3'),
	('Brand 4'),
	('Brand 5');

	
insert into shop.Product (Name, Description, IsAvailable, ProductSizeID, ProductColorID,
Price, Discount, CategoryID, BrandID, ProductType)
values 
	('Name 1', 'Description 1', 1, 2, 2, 4000.00, 10, 3, 2, 'Zensko'),
	('Name 2', 'Description 2', 0, 3, 5, 1200.99, 20, 4, 5, 'Musko'),
	('Name 3', 'Description 3', 1, 5, 3, 200.99, 5, 1, 4, 'Decije'),
	('Name 4', 'Description 4', 0, 4, 1, 5020.6, 3, 5, 3, 'Zensko'),
	('Name 5', 'Description 5', 1, 1, 4, 3300.5, 5, 2, 3, 'Zensko');


insert into shop.Size (Size)
values
	('XS'),
	('S'),
	('M'),
	('L'),
	('XL');	

insert into shop.ProductSizes (ProductID, SizeID)
values
	(1,3),
	(2,2),
	(4,1),
	(3,5),
	(5,4);	

insert into shop.Color (Color)
values 
	('Black'),
	('White'),
	('Yellow'),
	('Red'),
	('Blue');

insert into shop.ProductColors (ProductID, ColorID)
values 
	(1,3),
	(2,2),
	(4,1),
	(3,5),
	(5,4);

insert into shop.Users (Email, Password, Name, PhoneNumber, Role)
values 
	('a@mejl.com', 'password1', 'Name1', '415452134', 'Admin'),
	('a@mejl.com', 'password2', 'Name2', '415452134', 'Customer'),
	('a@mejl.com', 'password3', 'Name3', '415452134', 'Admin'),
	('a@mejl.com', 'password4', 'Name4', '415452134', 'Customer'),
	('a@mejl.com', 'password5', 'Name5', '415452134', 'Admin');

insert into shop.Orders (Name, Surname, Address, City, Country, DateCreated, TotalPrice, isPaymentDone)
values 
	('Name1', 'Surname1', 'Address1', 'City1', 'Country1', GETDATE(), 25000, 1),
	('Name2', 'Surname2', 'Address2', 'City2', 'Country2', GETDATE(), 6000, 0),
	('Name3', 'Surname3', 'Address3', 'City3', 'Country3', GETDATE(), 1000, 1),
	('Name4', 'Surname4', 'Address4', 'City4', 'Country4', GETDATE(), 4230, 0),
	('Name5', 'Surname5', 'Address5', 'City5', 'Country5', GETDATE(), 850, 0);