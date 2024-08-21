CREATE DATABASE ASM2;
GO

USE ASM2;
GO
CREATE TABLE Categories (
    category_id INT PRIMARY KEY IDENTITY NOT NULL,
    category_name VARCHAR(100) NOT NULL,
    note VARCHAR(100) NULL
);

INSERT INTO Categories (category_name, note) VALUES ('Novel', 'Catel');
INSERT INTO Categories (category_name, note) VALUES ('Textbook', 'Cate2');
INSERT INTO Categories (category_name, note) VALUES ('Picture Book', 'Cate3');
INSERT INTO Categories (category_name, note) VALUES ('Autobiography', 'Cate4');
GO
CREATE TABLE Authors (
    author_id INT PRIMARY KEY IDENTITY NOT NULL,
    author_name VARCHAR(50) NOT NULL
);

INSERT INTO Authors (author_name) VALUES ('Mark Twain');
INSERT INTO Authors (author_name) VALUES ('Waldo Emerson');
INSERT INTO Authors (author_name) VALUES ('May Alcott');
INSERT INTO Authors (author_name) VALUES ('Robert Creeley');
GO
CREATE TABLE Publishers (
    publisher_id INT PRIMARY KEY IDENTITY NOT NULL,
    publisher_name VARCHAR(50) NOT NULL,
    publisher_address VARCHAR(200) NULL
);

INSERT INTO Publishers (publisher_name, publisher_address) VALUES ('Kim Dong', 'HN');
INSERT INTO Publishers (publisher_name, publisher_address) VALUES ('Tuoi Tre', 'HCM');
INSERT INTO Publishers (publisher_name, publisher_address) VALUES ('Giao Duc', 'DN');
INSERT INTO Publishers (publisher_name, publisher_address) VALUES ('Hong Duc', 'CT');
GO
CREATE TABLE Books (
    book_id INT PRIMARY KEY IDENTITY NOT NULL,
    book_name VARCHAR(50) NOT NULL,
    author_id INT NOT NULL FOREIGN KEY REFERENCES Authors(author_id),
    category_id INT NOT NULL FOREIGN KEY REFERENCES Categories(category_id),
    publisher_id INT NOT NULL FOREIGN KEY REFERENCES Publishers(publisher_id),
    publishing_date DATE NOT NULL
);

INSERT INTO Books (book_name, author_id, category_id, publisher_id, publishing_date) VALUES ('Nha Gia Kim', 1, 1, 1, '2023-10-10');
INSERT INTO Books (book_name, author_id, category_id, publisher_id, publishing_date) VALUES ('Dac Nhan Tam', 2, 3, 4, '2021-12-30');
INSERT INTO Books (book_name, author_id, category_id, publisher_id, publishing_date) VALUES ('Khong Gia Dinh', 3, 4, 2, '2020-09-13');
INSERT INTO Books (book_name, author_id, category_id, publisher_id, publishing_date) VALUES ('Cay Cam Ngot Cua Toi', 2, 1, 3, '2019-04-07');
INSERT INTO Books (book_name, author_id, category_id, publisher_id, publishing_date) VALUES ('Cuoc Song Khong Gioi Han', 4, 2, 1, '2017-10-30');
GO
CREATE TABLE Borrowers (
    borrower_id INT PRIMARY KEY IDENTITY NOT NULL,
    borrower_name VARCHAR(100),
    borrower_DOB DATE,
    borrower_address VARCHAR(100),
    borrower_phone VARCHAR(50),
    borrower_email VARCHAR(50)
);

INSERT INTO Borrowers (borrower_name, borrower_DOB, borrower_address, borrower_phone, borrower_email) VALUES ('Nguyen Van A', '2000-10-30', 'HN', '0987654321', 'nva@gmail.com');
INSERT INTO Borrowers (borrower_name, borrower_DOB, borrower_address, borrower_phone, borrower_email) VALUES ('Nguyen Thi B', '2003-12-30', 'HCM', '0987688821', 'ntb@gmail.com');
INSERT INTO Borrowers (borrower_name, borrower_DOB, borrower_address, borrower_phone, borrower_email) VALUES ('Nguyen Van C', '1999-11-20', 'DN', '0678953218', 'nvc@gmail.com');
INSERT INTO Borrowers (borrower_name, borrower_DOB, borrower_address, borrower_phone, borrower_email) VALUES ('Nguyen Thi D', '1983-05-23', 'HN', '0934874137', 'ntd@gmail.com');
INSERT INTO Borrowers (borrower_name, borrower_DOB, borrower_address, borrower_phone, borrower_email) VALUES ('Nguyen Van E', '1978-04-25', 'CT', '0958145218', 'nve@gmail.com');
GO
CREATE TABLE Tickets (
    ticket_id INT PRIMARY KEY IDENTITY NOT NULL,
    book_id INT FOREIGN KEY REFERENCES Books(book_id),
    borrower_id INT FOREIGN KEY REFERENCES Borrowers(borrower_id),
    borrow_date DATE,
    return_date DATE
);

INSERT INTO Tickets (book_id, borrower_id, borrow_date, return_date) VALUES (1, 1, '2024-06-19', '2024-06-26');
INSERT INTO Tickets (book_id, borrower_id, borrow_date, return_date) VALUES (2, 2, '2024-06-18', '2024-06-25');
INSERT INTO Tickets (book_id, borrower_id, borrow_date, return_date) VALUES (3, 3, '2024-06-14', '2024-06-21');
INSERT INTO Tickets (book_id, borrower_id, borrow_date, return_date) VALUES (4, 4, '2024-06-15', '2024-06-22');
INSERT INTO Tickets (book_id, borrower_id, borrow_date, return_date) VALUES (5, 5, '2024-06-17', '2024-06-24');
GO
CREATE TABLE Accounts (
    username VARCHAR(100) PRIMARY KEY NOT NULL,
    user_password VARCHAR(100) NOT NULL,
    user_role VARCHAR(10) NULL
);

INSERT INTO Accounts (username, user_password, user_role) VALUES ('admin', 'admin', 'admin');
INSERT INTO Accounts (username, user_password, user_role) VALUES ('Nguyen Van A', 'nva', 'borrower');
INSERT INTO Accounts (username, user_password, user_role) VALUES ('Nguyen Thi B', 'ntb', 'borrower');
INSERT INTO Accounts (username, user_password, user_role) VALUES ('Nguyen Van C', 'nvc', 'borrower');
INSERT INTO Accounts (username, user_password, user_role) VALUES ('Nguyen Thi D', 'ntd', 'borrower');
INSERT INTO Accounts (username, user_password, user_role) VALUES ('Nguyen Van E', 'nve', 'borrower');
GO

