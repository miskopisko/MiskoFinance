-- MySql View Definitions

DROP VIEW IF EXISTS VwTxn;
CREATE VIEW VwTxn AS
SELECT  T.Id TxnId,
        A.Id AccountId,
        O.Id OperatorId,
        T.DatePosted DatePosted,
		T.Description,
		T.TxnType,
		T.Category,
        CASE WHEN T.TxnType IN (0,2) THEN T.Amount ELSE NULL END Credit,
        CASE WHEN T.TxnType IN (1,3) THEN T.Amount ELSE NULL END Debit,
        CASE WHEN T.TxnType IN (2,3) THEN 1 ELSE 0 END Transfer        
FROM    Txn T, Account A, Operator O
WHERE   T.Account = A.Id
AND     A.Operator = O.Id
ORDER BY T.DatePosted;