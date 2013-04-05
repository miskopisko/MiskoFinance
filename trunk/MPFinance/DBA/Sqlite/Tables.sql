-- Sqlite Table Definitions

DROP TABLE Operator;

CREATE TABLE Operator
( 
	Id			INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
    Username	VARCHAR(40),
    Password	VARCHAR(40),
    Name		VARCHAR(40),
    Email		VARCHAR(40),
    Birthday	DATE,
    Gender		INTEGER,
    Age			INTEGER,
    TeamLead	INTEGER,
    DtCreated	DATETIME NOT NULL,
    DtModified	DATETIME NOT NULL,
    RowVer		INTEGER NOT NULL 
);
