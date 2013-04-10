-- Sqlite Table Definitions

-- Operator - Used to store opertor setting and options
DROP TABLE IF EXISTS Operator;
CREATE TABLE Operator
( 
    Id				INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
    Username		VARCHAR(40),
    Password		VARCHAR(40),
    Client			INTEGER,
    DtCreated		DATETIME NOT NULL,
    DtModified		DATETIME NOT NULL,
    RowVer			INTEGER NOT NULL 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Operator', 1000000);

-- Client - A client is an entity that owns accounts
DROP TABLE IF EXISTS 'Client';
CREATE TABLE 'Client'
( 
    Id				INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	FirstName		VARCHAR(128),
	LastName		VARCHAR(128),
	Email			VARCHAR(128),
	Birthday		DATE,
	Gender			INTEGER,
    DtCreated		DATETIME NOT NULL,
    DtModified		DATETIME NOT NULL,
    RowVer			INTEGER NOT NULL 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Client', 1000000);

-- Account - An account belongs to a client and contains transactions
DROP TABLE IF EXISTS 'Account';
CREATE TABLE 'Account'
( 
    Id				INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	Client			INTEGER,
	AccountType		INTEGER,
	BankNumber		VARCHAR(128),
	AccountNumber	VARCHAR(128),	
    DtCreated		DATETIME NOT NULL,
    DtModified		DATETIME NOT NULL,
    RowVer			INTEGER NOT NULL 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Account', 1000000);

-- Transaction - Used to store transactions
DROP TABLE IF EXISTS 'Transaction';
CREATE TABLE 'Transaction'
( 
    Id				INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
	Account			INTEGER NOT NULL,
    Type			INTEGER NOT NULL,
	DatePosted		DATE NOT NULL,
	Amount			DOUBLE NOT NULL,
	FITID			VARCHAR(128) NOT NULL,
	Name			VARCHAR(128) NULL,
	Memo			VARCHAR(128) NULL,
	CheckNum		VARCHAR(128) NULL,
    DtCreated		DATETIME NOT NULL,
    DtModified		DATETIME NOT NULL,
    RowVer			INTEGER NOT NULL 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Transaction', 1000000);

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