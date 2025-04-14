CREATE DATABASE[hotel_manager]

CREATE TABLE guests (
    id INT PRIMARY KEY ,
    first_name VARCHAR(20) NOT NULL,
    last_name VARCHAR(30) NOT NULL,
    UCN VARCHAR(10) NOT NULL UNIQUE,
    phone_number VARCHAR(15) NOT NULL
)
CREATE TABLE room_types (
    id INT PRIMARY KEY,
    description VARCHAR(80) NOT NULL,
    max_capacity INT NOT NULL 
)
CREATE TABLE rooms (
    id INT PRIMARY KEY,
    number INT NOT NULL,
    status VARCHAR(15) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    room_type_id INT,
    FOREIGN KEY (room_type_id) REFERENCES room_types(id)
)
CREATE TABLE reservations (
    id INT PRIMARY KEY ,
    accommodation_date DATE NOT NULL,
    release_date DATE NOT NULL,
    days INT NOT NULL,
    room_id INT,
    guest_id INT,
    FOREIGN KEY (room_id) REFERENCES rooms(id),
    FOREIGN KEY (guest_id) REFERENCES guests(id)
)

INSERT INTO guests (id, first_name, last_name, UCN, phone_number)
VALUES
(1, 'David', 'Hunter', '9612047655', '0049456234354'),
(2, 'Barry', 'Johnson', '8809146088', '003305654733'),
(3, 'Peter', ' McGuel', '9510264905', '0044200485439'),
(4, 'Barbara', 'Feng', '8905174490', '003304500238'),
(5, 'Susan', 'Keil', '9102227445', '0039755623365'),
(6, 'Fred', 'Rapier', '9503118723', '00301205773'),
(7, 'Mary', 'Johnson', '9507205587', '003328130168'),
(8, 'Patricia', 'Gray', '9211256577', '0049457583490')
INSERT INTO room_types (id, description, max_capacity) 
VALUES
(1, 'Double' , 2),
(2, 'DoubleLux' , 2),
(3, 'Triple' , 3),
(4, 'Studio' , 3),
(5, 'Apartment' , 4)
INSERT INTO rooms (id, number, status, price, room_type_id) 
VALUES
(1, 101 , 'free', 65, 1),
(2, 102 , 'busy', 80, 2),
(3, 103 , 'cleaning up', 65, 1),
(4, 104 , 'busy', 90, 3),
(5, 105 , 'busy', 120, 5),
(6, 201 , 'busy', 100, 4),
(7, 202 , 'free', 90, 3),
(8, 203 , 'cleaning up', 65, 1),
(9, 204 , 'free', 80, 2),
(10, 205 , 'busy', 65, 1),
(11, 206 , 'free', 120, 5),
(12, 207 , 'busy', 100, 4),
(13, 208 , 'busy', 80, 2),
(14, 209 , 'cleaning up', 65, 1)
INSERT INTO reservations (id, accommodation_date, release_date, days, room_id, guest_id)
VALUES
(1, '2024-09-12', '2024-09-17', 5, 3, 5),
(2, '2024-09-20', '2024-09-23', 3, 7, 2),
(3, '2024-10-09', '2024-10-15', 6, 9, 1),
(4, '2024-10-10', '2024-10-12', 2, 4, 8),
(5, '2024-10-15', '2024-10-17', 2, 10, 3),
(6, '2024-10-15', '2024-10-17', 2, 3, 3),
(7, '2025-10-21', '2025-10-24', 3, 1, 6),
(8, '2025-10-21', '2025-10-24', 3, 2, 6),
(9, '2025-10-21', '2025-10-24', 3, 9, 6),
(10, '2025-10-25', '2025-10-30', 5, 5, 4)
