using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithLinq3.Models
{
    public class EmployeeDAL
    {
        MVCDBDataContext dc = new MVCDBDataContext(ConfigurationManager.ConnectionStrings["MVCDBConnectionString"].ConnectionString);

        public List<EmpDept> GetEmployees()
        {
            var Records = from E in dc.Employees
                          join D in dc.Departments on E.Did equals D.Did
                          where E.Status == true
                          select new { E.Eid, E.Ename, E.Job, E.Salary, E.Did, D.Dname, D.Location };
            List<EmpDept> Emps = new List<EmpDept>();
            foreach (var Record in Records)
            {
                EmpDept Emp = new EmpDept
                {
                    Eid = Record.Eid,
                    Ename = Record.Ename,
                    Job = Record.Job,
                    Salary = Record.Salary,
                    Did = Record.Did,
                    Dname = Record.Dname,
                    Location = Record.Location
                };
                Emps.Add(Emp);
            }
            return Emps;
        }
        public EmpDept GetEmployee(int Eid)
        {
            var Record = (from E in dc.Employees
                          join D in dc.Departments on E.Did equals D.Did
                          where E.Eid == Eid
                          select
                          new { E.Eid, E.Ename, E.Job, E.Salary, E.Did, D.Dname, D.Location }).Single();
            EmpDept Emp = new EmpDept
            {
                Eid = Record.Eid,
                Ename = Record.Ename,
                Job = Record.Job,
                Salary = Record.Salary,
                Did = Record.Did,
                Dname = Record.Dname,
                Location = Record.Location
            };
            return Emp;
        }
    }
}