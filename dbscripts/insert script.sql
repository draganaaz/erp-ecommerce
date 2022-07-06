insert into shop.Category (CategoryName)
values
	('Clothes'),
	('Shoes'),
	('Sneakers'),
	('Accessories'),
	('Training equipment');

insert into shop.Brand (BrandName)
values 
	('Adidas'),
	('Nike'),
	('Puma'),
	('Lacoste'),
	('Guess'),
	('Ellesse'),
	('Reebok'),
	('New Balance');

	
insert into shop.Product (Name, Description, IsAvailable, ProductSizeID, ProductColorID,
Price, Discount, CategoryID, BrandID, ProductType, Image)
values 
	('Woman Sneakers Puma Skye', 'Puma white-puma white-gray violet', 1, 2, 2, 400.00, 10, 3, 3, 'Woman', 'https://www.n-sport.net/UserFiles/products/big/08/18/zenske-patike-puma-skye-demi-380749-02.jpg'),
	('Woman Sneakers Puma Carina', 'Woman Sneakers Puma Carina Lift', 1, 2, 2, 580.00, 5, 3, 3, 'Woman', 'https://www.n-sport.net/UserFiles/products/big/07/02/zenske-patike-puma-carina-lift-373031-16.jpg'),
	('Woman Sneakers Puma', 'Woman Sneakers Puma Cali Sport', 1, 2, 2, 3970.00, 15, 3, 3, 'Woman', 'https://www.n-sport.net/UserFiles/products/big/07/29/zenske-patike-puma-cali-sport-top-warm-up-wns-373436-02.jpg'),
	('Woman Sneakers Puma Skye', 'Puma white-puma white-gray violet', 1, 3, 2, 400.00, 10, 3, 3, 'Woman', 'https://www.n-sport.net/UserFiles/products/big/08/18/zenske-patike-puma-skye-demi-380749-01.jpg'),
	('Man Sneakers Adidas Advantage', 'White', 0, 3, 2, 250.00, 10, 3, 1, 'Man', 'https://www.n-sport.net/UserFiles/products/big/01/30/muske-patike-adidas-advantage-base-EE7690.jpg'),
	('Man Sneakers Adidas BreakNet', 'Black', 1, 3, 2, 400.00, 10, 3, 1, 'Man', 'https://www.n-sport.net/UserFiles/products/big/06/30/muske-patike-adidas-breaknet-H01967.jpg'),
	('Man Sneakers Adidas BreakNet', 'White', 1, 3, 2, 400.00, 10, 3, 1, 'Man', 'https://www.n-sport.net/UserFiles/products/big/06/23/muske-patike-adidas-breaknet-H01958.jpg'),
	('Man Sneakers Nike Air max command', 'White', 1, 3, 2, 400.00, 10, 3, 2, 'Man', 'https://www.n-sport.net/UserFiles/products/big/07/10/muske-patike-nike-air-max-command-leather-749760-012.jpg'),
	('Man shirt puma running', '', 1, 2, 2, 400.00, 10, 1, 3, 'Man', 'https://www.n-sport.net/UserFiles/products/big/10/09/muska-majica-puma-run-wool-ss-tee-m-520861-01.jpg'),
	('Woman Shoes Black', '', 1, 2, 2, 150.00, 10, 2, 5, 'Woman', 'https://www.n-sport.net/UserFiles/products/big/06/17/zenske-sandale-ipanema-fashion-sand-viii-fem-82842-21918.jpg'),
	('Woman Shoes Gold', '',0 , 2, 2, 140.00, 15, 2, 5, 'Woman', 'https://www.n-sport.net/UserFiles/products/big/06/27/zenske-sandale-ipanema-fashion-sand-viii-fem-82842-20352.jpg'),
	('Kids socks', 'Lifestyle sock 2p pink', 1, 2, 2, 6.00, 0, 1, 4, 'Kids', 'https://www.n-sport.net/UserFiles/products/big/06/28/decije-carape-puma-baby-mini-cats-lifestyle-sock-2p-701219268-002.jpg'),
	('Kids socks', 'Lifestyle sock 2p blue', 1, 2, 2, 6.00, 0, 1, 4, 'Kids', 'https://www.n-sport.net/UserFiles/products/big/06/28/decije-carape-puma-baby-mini-cats-lifestyle-sock-2p-701219268-001.jpg'),
	('Roller skates', 'action pink', 1, 2, 2, 39.00, 0, 5, 6, 'Kids', 'https://www.n-sport.net/UserFiles/products/big/04/20/deciji-roleri-action-PW-122F-PINK.jpg'),
	('Water bottle ', '', 1, 2, 2, 39.00, 0, 4, 3, 'Woman', 'https://www.n-sport.net/UserFiles/products/big/08/06/boca-za-vodu-puma-tr-bottle-sportstyle-053518-01.jpg'),
	('Water bottle gray', '', 1, 2, 2, 39.00, 0, 4, 3, 'Man', 'https://www.n-sport.net/UserFiles/products/big/08/17/boca-za-vodu-puma-tr-stainless-steel-bottle-053868-03.jpg');


insert into shop.Size (SizeName)
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

insert into shop.Color (ColorName)
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
