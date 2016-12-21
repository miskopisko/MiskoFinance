-- MySql View Definitions

DROP VIEW IF EXISTS VwOperator;
CREATE VIEW VwOperator AS
SELECT 	O.Id OperatorId,
       	O.Username,
       	O.Password,
       	O.FirstName,
       	O.LastName,
       	P.Email,
       	P.Birthday,
       	P.Gender
FROM 	Operator O, Person P
WHERE 	O.Id = P.Id;

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
		T.DrCr,
		T.Category,
		T.Transfer,
		T.OneTime,
        T.Amount,
		B.NickName Account             
FROM    Txn T, Account A, BankAccount B, Operator O
WHERE   T.Account = A.Id
AND		A.Id = B.Id
AND     A.Operator = O.Id
ORDER BY T.DatePosted, T.Id;

DROP VIEW IF EXISTS VwCategory;
CREATE VIEW VwCategory AS
SELECT  C.Id CategoryId,
        C.Operator OperatorId,
        C.Name,
        C.CategoryType
FROM    Category C;