-- Switch to the master database
USE master;
GO

-- Create the PostsRepository database if it doesn't exist
IF DB_ID('PostsRepository') IS NULL
BEGIN
    CREATE DATABASE PostsRepository;
END;
GO

-- Create the tables in PostsRepository
USE PostsRepository;
GO

-- Create the Posts table
IF OBJECT_ID('Posts', 'U') IS NULL
BEGIN
    CREATE TABLE Posts (
        ID INT PRIMARY KEY IDENTITY(1,1),
        username NVARCHAR(50),
        postName NVARCHAR(100),
        postData NVARCHAR(MAX)
    );
END;
GO

-- Create the OnlinePosts table
IF OBJECT_ID('OnlinePosts', 'U') IS NULL
BEGIN
    CREATE TABLE OnlinePosts (
        ID INT PRIMARY KEY IDENTITY(1,1),
        username NVARCHAR(50),
        postName NVARCHAR(100),
        postData NVARCHAR(MAX)
    );
END;
GO

-- Create the Users table
IF OBJECT_ID('Users', 'U') IS NULL
BEGIN
    CREATE TABLE Users (
        ID INT PRIMARY KEY IDENTITY(1,1),
        username NVARCHAR(50),
        password NVARCHAR(50)
    );
END;
GO

-- Create the UserDatabase database if it doesn't exist
IF DB_ID('UserDatabase') IS NULL
BEGIN
    CREATE DATABASE UserDatabase;
END;
GO

-- Create the Users table in UserDatabase
USE UserDatabase;
GO

IF OBJECT_ID('Users', 'U') IS NULL
BEGIN
    CREATE TABLE Users (
        ID INT PRIMARY KEY IDENTITY(1,1),
        username NVARCHAR(50),
        password NVARCHAR(50)
    );
END;
GO
