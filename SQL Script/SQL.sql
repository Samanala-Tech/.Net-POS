create database test;
use test;
show tables;

drop table categories;

create table categories( 
id int auto_increment primary key,
name varchar(2555),
description varchar(2555)
);

desc categories;

INSERT INTO categories (name, description) VALUES ("Rajith","My Name");

select * from categories;

create table products( 
id int auto_increment primary key,
name varchar(255),
description varchar(255),
qty double,
discount double,
price float
);

drop table products;
desc products;

INSERT INTO products (name, description, qty, discount, price) VALUES
('Product 1', 'Description of Product 1', 100, 0.05, 10.99),
('Product 2', 'Description of Product 2', 150, 0.1, 20.49),
('Product 3', 'Description of Product 3', 80, 0.0, 15.99),
('Product 4', 'Description of Product 4', 200, 0.2, 8.75),
('Product 5', 'Description of Product 5', 120, 0.15, 25.99);


select * from products;

create table customers( 
nic varchar(255) primary key,
name varchar(255),
age double,
address varchar(255),
contact varchar(255)
);

INSERT INTO customers (nic, name, age, address, contact) VALUES
('123456789V', 'John Doe', 30, '123 Main Street, City', '123-456-7890'),
('987654321V', 'Jane Smith', 25, '456 Elm Street, Town', '456-789-0123'),
('654321987V', 'Alice Johnson', 35, '789 Oak Street, Village', '789-012-3456'),
('456789123V', 'Bob Brown', 40, '321 Pine Street, Suburb', '012-345-6789'),
('321987654V', 'Emily Davis', 28, '654 Maple Street, Hamlet', '345-678-9012');

select * from customers;

desc customers;

create table checkout( 
id int auto_increment primary key,
customer varchar(255),
total double,
discount double
);

select * from checkout;

create table productsLine( 
id int,
name varchar(255),
description varchar(255),
qty double,
discount double,
price float
);

drop table productsLine;




