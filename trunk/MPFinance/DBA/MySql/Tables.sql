-- MySql Table Definitions

-- Operator - Used to store opertor setting and options
DROP TABLE IF EXISTS Operator;
CREATE TABLE Operator
(
    Id          int(10) NOT NULL AUTO_INCREMENT,
	Username    varchar(128) NOT NULL,
	Password	varchar(32) NOT NULL,
	FirstName	varchar(128),
	LastName	varchar(128),
	Email		varchar(128),
	Birthday	datetime,
	Gender		int(3),
	DtCreated   datetime NOT NULL,
	DtModified  datetime NOT NULL,
	RowVer      int(10) NOT NULL,
	PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT = 1000001;

-- Account - An account belongs to a client and contains transactions
DROP TABLE IF EXISTS Account;
CREATE TABLE Account
( 
    Id				int(10) NOT NULL AUTO_INCREMENT,
	Operator		int(10),
	AccountType		int(3),	
    DtCreated		datetime NOT NULL,
    DtModified		datetime NOT NULL,
    RowVer			int(10) NOT NULL,
	PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT = 1000001;

-- BankAccount - Default table template
DROP TABLE IF EXISTS BankAccount;
CREATE TABLE BankAccount
( 
    Id			    int(10) NOT NULL AUTO_INCREMENT,
    BankNumber		varchar(128),
	AccountNumber	varchar(128),
	Nickname		varchar(128),
	OpeningBalance  numeric(19,4),
    DtCreated       datetime NOT NULL,
    DtModified      datetime NOT NULL,
    RowVer		    int(10) NOT NULL,
	PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT = 1000001;

-- Transaction - Used to store transactions
DROP TABLE IF EXISTS Txn;
CREATE TABLE Txn
( 
    Id			  int(10) NOT NULL AUTO_INCREMENT,
	Account		  int(10) NOT NULL,
    TxnType		  int(3) NOT NULL,
	DatePosted	  datetime NOT NULL,
	Amount		  numeric(19,4) NOT NULL,
	Description	  varchar(128) NULL,
	Category	  int(10) NULL,
	HashCode	  varchar(512) NOT NULL,
    DtCreated     datetime NOT NULL,
    DtModified    datetime NOT NULL,
    RowVer		  int(10) NOT NULL,
	PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT = 1000001;

-- Category - The transaction category user defined
DROP TABLE IF EXISTS Category;
CREATE TABLE Category
( 
    Id			  int(10) NOT NULL AUTO_INCREMENT,
	Operator	  int(10) NOT NULL,
	Name		  varchar(128) NOT NULL,
	CategoryType  int(3) NOT NULL,
	Status		  int(3) NOT NULL,
    DtCreated     datetime NOT NULL,
    DtModified    datetime NOT NULL,
    RowVer		  int(10) NOT NULL,
	PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT = 1000001;

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
) ENGINE=InnoDB AUTO_INCREMENT = 1000001;
*/