﻿CREATE TABLE OPERATORPROFILE
(
  ID          NUMBER(10),
  NAME        VARCHAR2(40 BYTE),
  EMAIL       VARCHAR2(40 BYTE),
  BIRTHDAY    DATE,
  GENDER      NUMBER(3),
  AGE         NUMBER(3),
  DTCREATED   DATE,
  DTMODIFIED  DATE,
  ROWVER      NUMBER
);