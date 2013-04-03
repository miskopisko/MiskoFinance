CREATE TABLE OperatorProfile ( 
    Id         INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
    Name       VARCHAR( 40 ),
    Email      VARCHAR( 40 ),
    Birthday   DATE,
    Age        INTEGER,
    DtCreated  DATETIME,
    DtModified DATETIME,
    RowVer     INTEGER 
);
