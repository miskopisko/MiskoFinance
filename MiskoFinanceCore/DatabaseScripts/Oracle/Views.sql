-- Oracle View Definitions

CREATE OR REPLACE VIEW VwOperator AS
SELECT  O.Id OperatorId,
        O.Username,
        O.Password,
        O.FirstName,
        O.LastName,
        O.Email,
        O.Birthday,
        O.Gender
FROM    Operator O;

CREATE OR REPLACE VIEW VwBankAccount AS
SELECT  A.Id BankAccountId,
        A.Operator OperatorId,
        A.AccountType,
        B.BankNumber,
        B.AccountNumber,
        B.Nickname,
        B.OpeningBalance
FROM    Account A, BankAccount B
WHERE   A.Id = B.Id;

CREATE OR REPLACE VIEW VwTxn AS
SELECT  T.Id TxnId,
        A.Id AccountId,
        O.Id OperatorId,
        T.DatePosted,
        T.Description,
		T.DrCr,
		T.Category,
		T.Amount,
		T.Transfer,
		T.OneTime		
FROM    Txn T, Account A, Operator O
WHERE   T.Account = A.Id
AND     A.Operator = O.Id
ORDER BY T.DatePosted, T.Id;

CREATE OR REPLACE VIEW VwCategory AS
SELECT  C.Id CategoryId,
        C.Operator OperatorId,
        C.Name,
        C.CategoryType
FROM    Category C;