Create Table Department(Did Int Constraint Did_PK Primary Key Identity(10, 10), Dname Varchar(50), Location
Varchar(50));Insert Into Department Values ('Marketing ', 'Mumbai ');
Insert Into Department Values ('Sales ', 'Chennai ');
Insert Into Department Values ('Accounting ', 'Hyderabad ');
Insert Into Department Values ('Finance ', 'Delhi ');Create Table Employee(Eid Int Constraint Eid_PK Primary Key Identity(1001, 1), Ename Varchar(50), Job
Varchar(50), Salary Money, Did Int Constraint Did_FK References Department(Did), Status Bit Not Null default 1);select * from Employeeselect * from Departmentinsert into Employee values('Mike','Manager',5000,10,1)insert into Employee values('David','Analyst',5000,30,1)