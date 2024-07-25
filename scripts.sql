Create Table Department(Did Int Constraint Did_PK Primary Key Identity(10, 10), Dname Varchar(50), Location
Varchar(50));Insert Into Department Values ('Marketing ', 'Mumbai ');
Insert Into Department Values ('Sales ', 'Chennai ');
Insert Into Department Values ('Accounting ', 'Hyderabad ');
Insert Into Department Values ('Finance ', 'Delhi ');Create Table Employee(Eid Int Constraint Eid_PK Primary Key Identity(1001, 1), Ename Varchar(50), Job
Varchar(50), Salary Money, Did Int Constraint Did_FK References Department(Did), Status Bit Not Null default 1);