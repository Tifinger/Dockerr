CREATE DATABASE mydatabase;

CREATE TABLE Person (
    ID SERIAL PRIMARY KEY,
    name VARCHAR(100),
    DoB DATE,
    comment TEXT
);