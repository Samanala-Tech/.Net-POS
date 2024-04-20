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
price float
);

desc products;

INSERT INTO products (name, description, qty, price) VALUES
('Product 1', 'Description of Product 1', 10, 29.99),
('Product 2', 'Description of Product 2', 15, 39.99),
('Product 3', 'Description of Product 3', 20, 49.99),
('Product 4', 'Description of Product 4', 25, 59.99),
('Product 5', 'Description of Product 5', 30, 69.99);

select * from products;




