-- MySql Table Definitions

DROP TABLE Operator;

CREATE TABLE Operator
(
	Id			int(11) NOT NULL AUTO_INCREMENT,
	Username	varchar(40),
	Password	varchar(40),
	Name		varchar(40),
	Email		varchar(60),
	Birthday	datetime,
	Gender		int(3),
	Age			int(3),
	TeamLead	int(3),
	DtCreated	datetime NOT NULL,
	DtModified	datetime NOT NULL,
	RowVer		int(11) NOT NULL,
	PRIMARY KEY (Id)
);
