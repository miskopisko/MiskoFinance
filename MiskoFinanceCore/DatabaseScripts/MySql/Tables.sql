-- MySql Table Definitions

-- Person - A person extends Operator and is an entity that owns accounts
DROP TABLE IF EXISTS Person;
CREATE TABLE Person 
(
    Id 			int(10) NOT NULL AUTO_INCREMENT,
    Email 		varchar(128) DEFAULT NULL,
    Birthday 	datetime DEFAULT NULL,
    Gender 		int(3) DEFAULT NULL,
    DtCreated 	datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DtModified 	datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    RowVer 		int(10) NOT NULL DEFAULT '0',
    PRIMARY KEY (Id),
    CONSTRAINT FK_Operator FOREIGN KEY (Id) REFERENCES Operator (Id)
) ENGINE=InnoDB AUTO_INCREMENT=1000001 DEFAULT CHARSET=utf8;

-- Account - An account belongs to a client and contains transactions
DROP TABLE IF EXISTS Account;
CREATE TABLE Account 
(
    Id 			int(10) NOT NULL AUTO_INCREMENT,
    Operator 	int(10) DEFAULT NULL,
    AccountType int(3) DEFAULT NULL,
    DtCreated 	datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    DtModified 	datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
    RowVer 		int(10) NOT NULL DEFAULT '0',
    PRIMARY KEY (Id),
    KEY Operator (Operator),
    CONSTRAINT FK_AccountOperator FOREIGN KEY (Operator) REFERENCES Operator (Id)
) ENGINE=InnoDB AUTO_INCREMENT=1000001 DEFAULT CHARSET=utf8;

-- BankAccount - A child of account, a specific account at a bank
DROP TABLE IF EXISTS BankAccount;
CREATE TABLE BankAccount 
(
	Id 				int(10) NOT NULL AUTO_INCREMENT,
	BankNumber 		varchar(128) DEFAULT NULL,
	AccountNumber 	varchar(128) DEFAULT NULL,
	Nickname 		varchar(128) DEFAULT NULL,
	OpeningBalance 	decimal(19,4) DEFAULT NULL,
	DtCreated 		datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
	DtModified 		datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
	RowVer 			int(10) NOT NULL DEFAULT '0',
	PRIMARY KEY (Id),
	CONSTRAINT FK_AccountId FOREIGN KEY (Id) REFERENCES Account (Id)
) ENGINE=InnoDB AUTO_INCREMENT=1000001 DEFAULT CHARSET=utf8;

-- Category - The transaction category user defined
DROP TABLE IF EXISTS Category;
CREATE TABLE Category 
(
	Id 				int(10) NOT NULL AUTO_INCREMENT,
	Operator 		int(10) NOT NULL,
	Name 			varchar(128) NOT NULL,
	CategoryType 	int(3) NOT NULL,
	DtCreated 		datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
	DtModified 		datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
	RowVer 			int(10) NOT NULL DEFAULT '0',
	PRIMARY KEY (Id),
	KEY Operator (Operator),
	CONSTRAINT FK_CategoryOperator FOREIGN KEY (Operator) REFERENCES Operator (Id)
) ENGINE=InnoDB AUTO_INCREMENT=1000001 DEFAULT CHARSET=utf8;

-- Transaction - Used to store transactions
DROP TABLE IF EXISTS Txn;
CREATE TABLE Txn 
(
	Id 			int(10) NOT NULL AUTO_INCREMENT,
	Account 	int(10) NOT NULL,
	DrCr 		int(3) NOT NULL,
	DatePosted 	datetime NOT NULL,
	Amount 		decimal(19,4) NOT NULL,
	Description varchar(128) DEFAULT NULL,
	Category 	int(10) DEFAULT NULL,
	HashCode 	varchar(512) NOT NULL,
	OneTime 	tinyint(1) NOT NULL DEFAULT '0',
	Transfer 	tinyint(1) NOT NULL DEFAULT '0',
	DtCreated 	datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
	DtModified 	datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
	RowVer 		int(10) NOT NULL DEFAULT '0',
	PRIMARY KEY (Id),
 	UNIQUE KEY HashCode (HashCode(255)),
	KEY Account (Account),
	KEY DatePosted (DatePosted),
	KEY Category (Category),
	KEY Description (Description),
	CONSTRAINT FK_TxnAccount FOREIGN KEY (Account) REFERENCES Account (Id),
	CONSTRAINT FK_TxnCategory FOREIGN KEY (Category) REFERENCES Category (Id)
) ENGINE=InnoDB AUTO_INCREMENT=1000001 DEFAULT CHARSET=utf8;

/*
-- XXX - Default table template
DROP TABLE IF EXISTS XXX;
CREATE TABLE XXX
( 
    Id 				int(10) NOT NULL AUTO_INCREMENT,
 	DtCreated 		datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  	DtModified 		datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  	RowVer 			int(10) NOT NULL DEFAULT '0',
  	PRIMARY KEY (Id)
) ENGINE=InnoDB AUTO_INCREMENT=1000001 DEFAULT CHARSET=utf8;
*/