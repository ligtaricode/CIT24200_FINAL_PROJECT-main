CREATE DATABASE ASP

CREATE TABLE CATEGORIES (
  ID INT(11) NOT NULL 
  NAME VARCHAR(255) NOT NULL,
  DESCRIPTION (255),
  PRIMARY KEY (ID)
);

CREATE TABLE PRODUCTS (
  ID INT(11) NOT NULL,
  PROD_NAME VARCHAR(255) NOT NULL,
  PROD_DESCRIP VARCHAR (255),
  PROD_PRICE DECIMAL(10,2) NOT NULL,
  CATEGORY_ID INT(11) NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (category_id) REFERENCES categories(id)
  );
  
CREATE TABLE CARTS (
  ID INT(11) NOT NULL,
  USER_ID INT(11) NOT NULL,
  PRODUCT_ID INT(11) NOT NULL,
  CART_AMOUNT INT(11) NOT NULL,
  PRIMARY KEY (ID),
  FOREIGN KEY (user_id) REFERENCES users(id),
  FOREIGN KEY (product_id) REFERENCES products(id)
);

CREATE TABLE ORDERS (
  ID INT(11) NOT NULL,
  USER_ID INT(11) NOT NULL,
  TOTAL_COST DECIMAL(10,2) NOT NULL,
  status ENUM('pending', 'confirmed', 'shipped', 'delivered') NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (user_id) REFERENCES users(id)
);

CREATE TABLE ORDER_ITEMS (
  ID INT(11) NOT NULL,
  ORDER_ID INT(11) NOT NULL,
  PRODUCT_ID INT(11) NOT NULL,
  QUANTITY INT(11) NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (order_id) REFERENCES orders(id) ON DELETE CASCADE,
  FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE CASCADE
);



-- Insert values into CATEGORIES table
INSERT INTO CATEGORIES (ID, NAME, DESCRIPTION) VALUES 
  (1, 'Electronics', 'Devices that use electricity to perform functions'),
  (2, 'Clothing', 'Apparel worn on the body'),
  (3, 'Home Goods', 'Products used to decorate or improve a living space');

-- Insert values into PRODUCTS table
INSERT INTO PRODUCTS (ID, PROD_NAME, PROD_DESCRIP, PROD_PRICE, CATEGORY_ID) VALUES
  (1, 'iPhone 13', 'Newest smartphone from Apple', 1099.99, 1),
  (2, 'Samsung Galaxy S21', 'High-end Android smartphone', 899.99, 1),
  (3, 'Levi Jeans', 'Classic straight leg jeans', 79.99, 2),
  (4, 'North Face Jacket', 'Warm and waterproof coat', 199.99, 2),
  (5, 'Throw Pillow', 'Soft and decorative pillow', 24.99, 3),
  (6, 'Area Rug', 'Large, patterned rug', 349.99, 3);

-- Insert values into CARTS table
INSERT INTO CARTS (ID, USER_ID, PRODUCT_ID, CART_AMOUNT) VALUES
  (1, 1, 1, 1),
  (2, 2, 3, 2),
  (3, 1, 5, 3);

-- Insert values into ORDERS table
INSERT INTO ORDERS (ID, USER_ID, TOTAL_COST, status) VALUES
  (1, 1, 178.97, 'confirmed'),
  (2, 2, 238.97, 'pending');

-- Insert values into ORDER_ITEMS table
INSERT INTO ORDER_ITEMS (ID, ORDER_ID, PRODUCT_ID, QUANTITY) VALUES
  (1, 1, 1, 1),
  (2, 1, 5, 2),
  (3, 2, 3, 1),
  (4, 2, 6, 2);



