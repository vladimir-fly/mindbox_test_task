CREATE TABLE Categories (id INT PRIMARY KEY, name NVARCHAR(255) NOT NULL);
INSERT INTO Categories 
VALUES (1, 'Category_1'), (2, 'Category_2'), (3, 'Category_3'), (4, 'Category_4');

CREATE TABLE Products (id int PRIMARY KEY, name varchar(255) NOT NULL);
INSERT INTO Products VALUES 
	(1, 'Product_1'), (2, 'Product_2'), (3, 'Product_3'), (4, 'Product_4'), (5, 'Product_5');

CREATE TABLE ProductCategory (productId  INT not null, categoryId INT not null);
INSERT INTO ProductCategory VALUES (3, 1), (2, 1), (3, 2), (5, 1), (5, 2), (5, 4);

select product.name, category.name
from ProductCategory productCategory 
right join Products product on product.id = productCategory.productId
left join Categories category on category.id = productCategory.categoryId  
order by product.name
