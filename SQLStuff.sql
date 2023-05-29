
USE farmStallDB

INSERT INTO Login_Credentials (user_username, user_password) 
VALUES ('atraverso13', '$2a$12$RkgvugJnKcoAQdA9XBtmtepMEnQVMwbgJkMF1iT8RwBNS4XWM1HPa');
INSERT INTO Login_Credentials (user_username, user_password) 
VALUES ('gabriel01', '$2a$12$nwMpoD5ctdBTZGv7xIxG1ugr4T0g0Iu0hPUFsxEx5drWx3Pzo6iuu');
INSERT INTO Login_Credentials (user_username, user_password) 
VALUES ('TomJoe1', '$2a$12$xcyMipqWN5888U4qF8BwW./M8xlrIsLeuS0MfHmPDRza1MvgkE3Mq');
INSERT INTO Login_Credentials (user_username, user_password) 
VALUES ('JJones', '$2a$12$xcyMipqWN5888U4qF8BwW./M8xlrIsLeuS0MfHmPDRza1MvgkE3Mq');

SELECT * FROM Login_Credentials;

DROP TABLE FarmerProduct;
DROP TABLE Product;
DROP TABLE Farmer;
DROP TABLE Employee;
DROP TABLE Login_Credentials;

INSERT INTO Employee(emp_name, emp_surname, emp_DOB, emp_cell, emp_email, user_username)
VALUES ('Angelo', 'Traverso', '2021/01/25', '0742221223', 'atraverso13@gmail.com', 'atraverso13');

INSERT INTO Employee(emp_name, emp_surname, emp_DOB, emp_cell, emp_email, user_username)
VALUES ('Gabriel', 'Grobbelaar', '2021/01/29', '0825646595', 'GG@gmail.com', 'gabriel01');

INSERT INTO Farmer(farmer_name, farmer_surname, farmer_DOB, farmer_cell, farmer_email, user_username)
VALUES ('Tom', 'Joe', '2001/01/29', '0111111252', 'TJ@gmail.com', 'TomJoe1');

INSERT INTO Farmer(farmer_name, farmer_surname, farmer_DOB, farmer_cell, farmer_email, user_username)
VALUES ('Jerry', 'Jones', '2002/01/13', '0215566545', 'JJ@gmail.com', 'JJones');

INSERT INTO Product(product_code, product_name, product_type , product_quantity,product_price, product_dateAdded)
VALUES('P101', 'Toilet Paper', 90,200,  '2023/05/14'),
('P102', 'Potato', 7, 15 , '2023/05/13')

INSERT INTO Product(product_code, product_name, product_type , product_quantity,product_price, product_dateAdded)
VALUES('P103', 'Granny Smith', 'Apples' , 40,14,  '2023/05/14'),
('P104', 'Green', 'Grapes' , 10, 25 , '2023/05/13')


SELECT F.farmer_name, F.farmer_surname, P.product_code, P.product_name, P.product_price, P.product_quantity, P.product_dateAdded
FROM FarmerProduct FP, Product P, Farmer F
WHERE FP.farmer_cell = F.farmer_cell AND FP.product_code = P.product_code

SELECT * FROM FarmerProduct
SELECT * FROM Product


INSERT INTO FarmerProduct(farmer_cell, product_code)
VALUES ('0111111252','P101')
INSERT INTO FarmerProduct(farmer_cell, product_code)
VALUES
('0215566545','P102')

INSERT INTO FarmerProduct(farmer_cell, product_code)
VALUES
('0215566545','P103')

INSERT INTO FarmerProduct(farmer_cell, product_code)
VALUES
('0215566545','P104')
SELECT * FROM FarmerProduct
SELECT * FROM PRODUCT


CREATE TABLE Login_Credentials
(
	user_username VARCHAR(50) NOT NULL,
	user_password VARCHAR(MAX) NOT NULL

	CONSTRAINT PK_username PRIMARY KEY (user_username)

);

CREATE TABLE Employee(
	emp_id	INT IDENTITY(1,1) NOT NULL,
	emp_name VARCHAR(50) NOT NULL,
	emp_surname VARCHAR(50) NOT NULL,
	emp_DOB DATE,
	emp_cell VARCHAR(10),
	emp_email VARCHAR(60),
	user_username VARCHAR(50) NOT NULL,


	CONSTRAINT PK_empid PRIMARY KEY(emp_id),
	CONSTRAINT FK_username FOREIGN KEY (user_username) REFERENCES Login_Credentials(user_username)
);
 

CREATE TABLE Farmer(
	farmer_name VARCHAR(50) NOT NULL,
	farmer_surname VARCHAR(50) NOT NULL,
	farmer_DOB DATE,
	farmer_cell VARCHAR(10),
	farmer_email VARCHAR(60),
	user_username VARCHAR(50) NOT NULL,

	CONSTRAINT PK_farmercell PRIMARY KEY (farmer_cell),
	CONSTRAINT FK_username2 FOREIGN KEY (user_username) REFERENCES Login_Credentials(user_username)
);

SELECT * FROM Farmer
DELETE FROM Farmer WHERE farmer_name = '';
SELECT * FROM Login_Credentials;
DELETE FROM Login_Credentials WHERE user_username = '';

CREATE TABLE Product
(
	product_code VARCHAR(10) NOT NULL,
	product_name VARCHAR (50) NOT NULL,
	product_type VARCHAR(MAX) NOT NULL,
	product_quantity INT NOT NULL,
	product_price FLOAT NOT NULL,
	product_dateAdded DATE,

	CONSTRAINT PK_productcode PRIMARY KEY(product_code)

);

CREATE TABLE FarmerProduct
(
	farmer_cell VARCHAR(10) NOT NULL,
	product_code VARCHAR(10) NOT NULL,

	CONSTRAINT FK_farmer_cell FOREIGN KEY (farmer_cell) REFERENCES Farmer(farmer_cell),
	CONSTRAINT FK_productcode FOREIGN KEY (product_code) REFERENCES Product(product_code)

);