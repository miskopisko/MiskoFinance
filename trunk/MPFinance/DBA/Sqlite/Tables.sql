-- Sqlite Table Definitions

-- User - A user is an entity that owns accounts
DROP TABLE IF EXISTS 'Operator';
CREATE TABLE 'Operator'
( 
    Id				INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
    Username		VARCHAR(40),
    Password		VARCHAR(32),
	FirstName		VARCHAR(128),
	LastName		VARCHAR(128),
	Email			VARCHAR(128),
	Birthday		DATE,
	Gender			INTEGER,
    DtCreated		DATETIME NOT NULL,
    DtModified		DATETIME NOT NULL,
    RowVer			INTEGER NOT NULL 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Operator', 1000000);

-- Account - An account belongs to a client and contains transactions
DROP TABLE IF EXISTS 'Account';
CREATE TABLE 'Account'
( 
    Id				INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	Operator		INTEGER,
	AccountType		INTEGER,
	BankNumber		VARCHAR(128),
	AccountNumber	VARCHAR(128),
	Nickname		VARCHAR(128),
	OpeningBalance	DOUBLE,
    DtCreated		DATETIME NOT NULL,
    DtModified		DATETIME NOT NULL,
    RowVer			INTEGER NOT NULL 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Account', 1000000);

-- Transaction - Used to store transactions
DROP TABLE IF EXISTS 'Txn';
CREATE TABLE 'Txn'
( 
    Id				INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	Account			INTEGER NOT NULL,
    TxnType			INTEGER NOT NULL,
	DatePosted		DATE NOT NULL,
	Amount			DOUBLE NOT NULL,
	Description		VARCHAR(128) NULL,
	Category		INTEGER NULL,
	HashCode		VARCHAR(32) NOT NULL,
    DtCreated		DATETIME NOT NULL,
    DtModified		DATETIME NOT NULL,
    RowVer			INTEGER NOT NULL 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Txn', 1000000);

-- XXX - Default table template
DROP TABLE IF EXISTS 'Category';
CREATE TABLE 'Category'
( 
    Id				INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	Operator		INTEGER NOT NULL,
	Name			VARCHAR(128) NOT NULL,
	CategoryType	INTEGER NOT NULL,
	Status			INTEGER NOT NULL,
    DtCreated		DATETIME NOT NULL,
    DtModified		DATETIME NOT NULL,
    RowVer			INTEGER NOT NULL 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Category', 1000000);

/*
-- XXX - Default table template
DROP TABLE IF EXISTS 'XXX';
CREATE TABLE 'XXX'
( 
    Id				INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
    DtCreated		DATETIME NOT NULL,
    DtModified		DATETIME NOT NULL,
    RowVer			INTEGER NOT NULL 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('XXX', 1000000);
*/