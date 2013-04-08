﻿-- Oracle Table Definitions

DROP TABLE OPERATORPROFILE;

CREATE TABLE OPERATORPROFILE
(
    ID          NUMBER(10),
    USERNAME    VARCHAR2(40),
    PASSWORD    VARCHAR2(40),
    NAME        VARCHAR2(40),
    EMAIL       VARCHAR2(40),
    BIRTHDAY    DATE,
    GENDER      NUMBER(3),
    AGE         NUMBER(3),
    TEAMLEAD    NUMBER(10),
    DTCREATED   DATE NOT NULL,
    DTMODIFIED  DATE NOT NULL,
    ROWVER      NUMBER NOT NULL
);

DROP SEQUENCE SQ_OPERATORPROFILE;
CREATE SEQUENCE SQ_OPERATORPROFILE START WITH 1000001 INCREMENT BY 1;
