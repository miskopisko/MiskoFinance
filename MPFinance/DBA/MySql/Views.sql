-- MySql View Definitions

DROP VIEW User;

CREATE VIEW User AS
SELECT  O1.Name Follower, O2.Name Leader
FROM    Operator O1, Operator O2
WHERE   O1.TeamLead = O2.Id;