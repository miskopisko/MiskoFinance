﻿-- Oracle View Definitions

CREATE OR REPLACE VIEW VWTXN AS
SELECT  T.ID TXNID,
        A.ID ACCOUNTID,
        O.ID OPERATORID,        
        T.DATEPOSTED,
        T.DESCRIPTION,
		T.TXNTYPE,
		T.CATEGORY,
        CASE WHEN T.TXNTYPE IN (0,2) THEN T.AMOUNT ELSE NULL END CREDIT,
        CASE WHEN T.TXNTYPE IN (1,3) THEN T.AMOUNT ELSE NULL END DEBIT,
        CASE WHEN T.TXNTYPE IN (2,3) THEN 1 ELSE 0 END TRANSFER        
FROM    TXN T, ACCOUNT A, OPERATOR O
WHERE   T.ACCOUNT = A.ID
AND     A.OPERATOR = O.ID
ORDER BY T.DATEPOSTED, T.ID;