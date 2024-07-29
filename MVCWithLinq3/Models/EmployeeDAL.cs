﻿using System;
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
        public List<SelectListItem> GetDepartments()
        {
            List<SelectListItem> Depts = new List<SelectListItem>();
            foreach (var Item in dc.Departments)
            {
                SelectListItem li = new SelectListItem { Text = Item.Dname, Value = Item.Did.ToString() };
                Depts.Add(li);
            }
            return Depts;
        }
        public void Employee_Insert(EmpDept obj)
        {
            Employee Emp = new Employee
            {
                Ename = obj.Ename,
                Job = obj.Job,
                Salary = obj.Salary,
                Did = obj.Did,
                Status = true
            };
            dc.Employees.InsertOnSubmit(Emp);
            dc.SubmitChanges();
        }
    }
}