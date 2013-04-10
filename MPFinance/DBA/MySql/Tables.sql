-- MySql Table Definitions

-- Operator - Used to store opertor setting and options
DROP TABLE IF EXISTS Operator;
CREATE TABLE Operator
(
    Id          int(10) NOT NULL AUTO_INCREMENT,
	Username    varchar(128),
	Password    varchar(128),
	Client		int(10),
	DtCreated   datetime NOT NULL,
	DtModified  datetime NOT NULL,
	RowVer      int(10) NOT NULL,
	PRIMARY KEY (Id)
);
ALTER TABLE Operator AUTO_INCREMENT = 1000001;

-- Client - A client is an entity that owns accounts
DROP TABLE IF EXISTS Client;
CREATE TABLE Client
( 
    Id			  int(10) NOT NULL AUTO_INCREMENT,
	FirstName	  varchar(128),
	LastName	  varchar(128),
	Email		  varchar(128),
	Birthday	  datetime,
	Gender		  int(3),
    DtCreated     datetime NOT NULL,
    DtModified    datetime NOT NULL,
    RowVer		  int(10) NOT NULL,
	PRIMARY KEY (Id)
);
ALTER TABLE Client AUTO_INCREMENT = 1000001;

-- Account - An account belongs to a client and contains transactions
DROP TABLE IF EXISTS Account;
CREATE TABLE Account
( 
    Id				int(10) NOT NULL AUTO_INCREMENT,
	Client			int(10),
	AccountType		int(3),
	BankNumber		varchar(128),
	AccountNumber	varchar(128),
    DtCreated		datetime NOT NULL,
    DtModified		datetime NOT NULL,
    RowVer			int(10) NOT NULL,
	PRIMARY KEY (Id)
);
ALTER TABLE Account AUTO_INCREMENT = 1000001;

-- Transaction - Used to store transactions
DROP TABLE IF EXISTS Transaction;
CREATE TABLE Transaction
( 
    Id			  int(10) NOT NULL AUTO_INCREMENT,
	Account		  int(10) NOT NULL,
    Type		  int(3) NOT NULL,
	DatePosted	  datetime NOT NULL,
	Amount		  double NOT NULL,
	FITID		  varchar(128) NOT NULL,
	Name		  varchar(128) NULL,
	Memo		  varchar(128) NULL,
	CheckNum	  varchar(128) NULL,
    DtCreated     datetime NOT NULL,
    DtModified    datetime NOT NULL,
    RowVer		  int(10) NOT NULL,
	PRIMARY KEY (Id)
);
ALTER TABLE Transaction AUTO_INCREMENT = 1000001;

/*
-- XXX - Default table template
DROP TABLE IF EXISTS XXX;
CREATE TABLE XXX
( 
    Id			  int(10) NOT NULL AUTO_INCREMENT,
    DtCreated     datetime NOT NULL,
    DtModified    datetime NOT NULL,
    RowVer		  int(10) NOT NULL,
	PRIMARY KEY (Id)
);
ALTER TABLE XXX AUTO_INCREMENT = 1000001;
*/