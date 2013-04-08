-- Oracle View Definitions

DROP VIEW Operator;

CREATE VIEW Operator 
AS
SELECT  O1.Name Follower, O2.Name Leader
FROM    OperatorProfile O1, OperatorProfile O2
WHERE   O1.TeamLead = O2.Id;