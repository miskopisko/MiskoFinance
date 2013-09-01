-- MySql View Definitions

DROP VIEW IF EXISTS VwOperator;
CREATE VIEW VwOperator AS
SELECT  O.Id OperatorId,
        O.Username,
        O.Password,
        O.FirstName,
        O.LastName,
        O.Email,
        O.Birthday,
        O.Gender
FROM    Operator O;

DROP VIEW IF EXISTS VwBankAccount;
CREATE VIEW VwBankAccount AS
SELECT  A.Id BankAccountId,
        A.Operator OperatorId,
        A.AccountType,
        B.BankNumber,
        B.AccountNumber,
        B.Nickname,
        B.OpeningBalance
FROM    Account A, BankAccount B
WHERE   A.Id = B.Id;

DROP VIEW IF EXISTS VwTxn;
CREATE VIEW VwTxn AS
SELECT  T.Id TxnId,
        A.Id AccountId,
        O.Id OperatorId,
        T.DatePosted,
        T.Description,
		T.TxnType,
		T.Category,
        CASE WHEN T.TxnType IN (0,2) THEN T.Amount ELSE NULL END Credit,
        CASE WHEN T.TxnType IN (1,3) THEN T.Amount ELSE NULL END Debit,
        CASE WHEN T.TxnType IN (2,3) THEN 1 ELSE 0 END Transfer        
FROM    Txn T, Account A, Operator O
WHERE   T.Account = A.Id
AND     A.Operator = O.Id
ORDER BY T.DatePosted, T.Id;

DROP VIEW IF EXISTS VwCategory;
CREATE VIEW VwCategory AS
SELECT  C.Id CategoryId,
        C.Operator OperatorId,
        C.Name,
        C.CategoryType,
        C.Status
FROM    Category C;