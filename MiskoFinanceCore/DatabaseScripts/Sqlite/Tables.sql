-- Sqlite Table Definitions

-- Person - A person extends Operator and is an entity that owns accounts
DROP TABLE IF EXISTS Person;
CREATE TABLE Person
(
    Id         INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL REFERENCES Operator (Id),
    Email      VARCHAR (128),
    Birthday   DATE,
    Gender     INTEGER,
    DtCreated  DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    DtModified DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    RowVer     INTEGER NOT NULL DEFAULT (0)
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Person', 1000000);

-- Account - An account belongs to an person
DROP TABLE IF EXISTS Account;
CREATE TABLE Account 
(
    Id          INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
    Operator    INTEGER REFERENCES Operator (Id),
    AccountType INTEGER,
    DtCreated   DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    DtModified  DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    RowVer      INTEGER NOT NULL DEFAULT (0) 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Account', 1000000);

-- BankAccount - A specific account type
DROP TABLE IF EXISTS BankAccount;
CREATE TABLE BankAccount 
(
    Id             INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL REFERENCES Account (Id),
    BankNumber     VARCHAR (128),
    AccountNumber  VARCHAR (128),
    Nickname       VARCHAR (128),
    OpeningBalance DOUBLE,
    DtCreated      DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    DtModified     DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    RowVer         INTEGER NOT NULL DEFAULT (0) 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('BankAccount', 1000000);

-- Transaction - Used to store transactions
DROP TABLE IF EXISTS Txn;
CREATE TABLE Txn 
(
    Id          INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
    Account     INTEGER NOT NULL REFERENCES Account (Id),
    DrCr        INT NOT NULL,
    DatePosted  DATE NOT NULL,
    Amount      DOUBLE NOT NULL,
    Description VARCHAR (128),
    Category    INTEGER REFERENCES Category (Id),
    HashCode    VARCHAR (512) NOT NULL UNIQUE,
    OneTime     INT NOT NULL DEFAULT (0),
    Transfer    INT NOT NULL DEFAULT (0),
    DtCreated   DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    DtModified  DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    RowVer      INTEGER NOT NULL DEFAULT (0) 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Txn', 1000000);
CREATE INDEX IX_Category ON Txn (Category);
CREATE INDEX IX_DatePosted ON Txn (DatePosted);
CREATE INDEX IX_Description ON Txn (Description);
CREATE INDEX IX_Account ON Txn (Account);

-- XXX - Default table template
DROP TABLE IF EXISTS Category;
CREATE TABLE Category 
(
    Id           INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
    Operator     INTEGER NOT NULL REFERENCES Operator (Id),
    Name         VARCHAR (128) NOT NULL,
    CategoryType INTEGER NOT NULL,
    DtCreated    DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    DtModified   DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    RowVer       INTEGER NOT NULL DEFAULT (0) 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('Category', 1000000);

/*
-- XXX - Default table template
DROP TABLE IF EXISTS 'XXX';
CREATE TABLE 'XXX'
( 
    Id		   INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL,
    DtCreated  DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    DtModified DATETIME NOT NULL DEFAULT (DATETIME('NOW')),
    RowVer     INTEGER  NOT NULL DEFAULT (0) 
);
INSERT INTO SQLITE_SEQUENCE (NAME, SEQ) VALUES ('XXX', 1000000);
*/