-- MySql Table Definitions

DROP TABLE IF EXISTS OperatorProfile;

CREATE TABLE OperatorProfile
(
    Id          int(10) NOT NULL AUTO_INCREMENT,
	Username    varchar(40),
	Password    varchar(40),
	Name        varchar(40),
	Email       varchar(60),
	Birthday    datetime,
	Gender      int(3),
	Age         int(3),
	TeamLead    int(10),
	DtCreated   datetime NOT NULL,
	DtModified  datetime NOT NULL,
	RowVer      int(11) NOT NULL,
	PRIMARY KEY (Id)
);

ALTER TABLE OperatorProfile AUTO_INCREMENT = 1000001;