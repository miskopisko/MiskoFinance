-- Oracle Table Definitions

-- USER - Used to store opertor setting and options
DROP TABLE OPERATOR;
CREATE TABLE OPERATOR
(
  ID				NUMBER(10) NOT NULL,
  USERNAME			VARCHAR2(40) NOT NULL,
  PASSWORD			VARCHAR2(32) NOT NULL,
  FIRSTNAME			VARCHAR2(128),
  LASTNAME			VARCHAR2(128),
  EMAIL				VARCHAR2(128),
  BIRTHDAY			DATE,
  GENDER			NUMBER(3),
  DTCREATED			DATE NOT NULL,
  DTMODIFIED		DATE NOT NULL,
  ROWVER			NUMBER NOT NULL,
  CONSTRAINT USER_PK PRIMARY KEY (ID)
);
DROP SEQUENCE SQ_OPERATOR;
CREATE SEQUENCE SQ_OPERATOR START WITH 1000001 INCREMENT BY 1;

-- ACCOUNT - An account belongs to a user and contains transactions
DROP TABLE ACCOUNT;
CREATE TABLE ACCOUNT
(
  ID				NUMBER(10) NOT NULL, 
  OPERATOR			NUMBER(10),
  ACCOUNTTYPE		NUMBER(3),
  BANKNUMBER    	VARCHAR2(128),
  ACCOUNTNUMBER		VARCHAR2(128),
  NICKNAME		    VARCHAR2(128),
  OPENINGBALANCE	NUMBER(19,4),
  DTCREATED		    DATE NOT NULL,
  DTMODIFIED		DATE NOT NULL,
  ROWVER			NUMBER NOT NULL,
  CONSTRAINT ACCOUNT_PK PRIMARY KEY (ID)
);
DROP SEQUENCE SQ_ACCOUNT;
CREATE SEQUENCE SQ_ACCOUNT START WITH 1000001 INCREMENT BY 1;

-- Transaction - Belongs to an account
DROP TABLE TXN;
CREATE TABLE TXN
( 
  ID				NUMBER(10) NOT NULL,
  ACCOUNT			NUMBER(10) NOT NULL,
  TXNTYPE			NUMBER(3) NOT NULL,
  DATEPOSTED		DATE NOT NULL,
  AMOUNT			NUMBER(19,4) NOT NULL,
  DESCRIPTION		VARCHAR2(128) NULL,
  CATEGORY			NUMBER(10) NULL,
  HASHCODE			VARCHAR2(32) NOT NULL,
  DTCREATED			DATE NOT NULL,
  DTMODIFIED		DATE NOT NULL,
  ROWVER			NUMBER NOT NULL,
  CONSTRAINT TXN_PK PRIMARY KEY (ID)
);
DROP SEQUENCE SQ_TXN;
CREATE SEQUENCE SQ_TXN START WITH 1000001 INCREMENT BY 1;

-- CATEGORY - Default table template
DROP TABLE CATEGORY;
CREATE TABLE CATEGORY
(
    ID				NUMBER(10) NOT NULL, 
	OPERATOR		NUMBER(10),
	NAME			VARCHAR2(128) NOT NULL,   
	CATEGORYTYPE	NUMBER(3) NOT NULL,	
    DTCREATED		DATE NOT NULL,
    DTMODIFIED		DATE NOT NULL,
    ROWVER			NUMBER NOT NULL,
	CONSTRAINT CATEGORY_PK PRIMARY KEY (ID)
);
DROP SEQUENCE SQ_CATEGORY;
CREATE SEQUENCE SQ_CATEGORY START WITH 1000001 INCREMENT BY 1;

/*
-- XXX - Default table template
DROP TABLE XXX;
CREATE TABLE XXX
(
    ID          NUMBER(10),    
    DTCREATED   DATE NOT NULL,
    DTMODIFIED  DATE NOT NULL,
    ROWVER      NUMBER NOT NULL,
	CONSTRAINT XXX_PK PRIMARY KEY (ID)
);
DROP SEQUENCE SQ_XXX;
CREATE SEQUENCE SQ_XXX START WITH 1000001 INCREMENT BY 1;
*/