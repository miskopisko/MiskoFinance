CREATE TABLE OperatorProfile 
( 
    Id         INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
    Name       VARCHAR( 40 ),
    Email      VARCHAR( 40 ),
    Birthday   DATE,
    Gender	   INTEGER,
    Age        INTEGER,
    TeamLead   INTEGER,
    DtCreated  DATETIME,
    DtModified DATETIME,
    RowVer     INTEGER 
);
