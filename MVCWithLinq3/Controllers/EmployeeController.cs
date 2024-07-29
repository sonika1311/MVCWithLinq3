using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithLinq3.Models;

namespace MVCWithLinq3.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL obj = new EmployeeDAL();
        public ViewResult DisplayEmployees()
        {
        return View(obj.GetEmployees()); 
        }    
        public ViewResult DisplayEmployee(int Eid)
        {
            return View(obj.GetEmployee(Eid));
        }
        [HttpGet]
        public ViewResult AddEmployee()
        {
            EmpDept emp = new EmpDept();
            emp.Departments = obj.GetDepartments();
            return View(emp);
        }
        [HttpPost]
        public RedirectToRouteResult AddEmployee(EmpDept Emp) 
        { 
            obj.Employee_Insert(Emp);
            return RedirectToAction("DisplayEmployees");
        }
        public ViewResult EditEmployee(int Eid)
        {
            EmpDept emp = obj.GetEmployee(Eid);
            emp.Departments = obj.GetDepartments();
            return View(emp);
        }
        public RedirectToRouteResult UpdateEmployee(EmpDept emp)
        {
            obj.Employee_Update(emp);
            return RedirectToAction("DisplayEmployees");
        }
        public RedirectToRouteResult DeleteEmployee(int Eid)
        {
            obj.Employee_Delete(Eid);
            return RedirectToAction("DisplayEmployees");
        }
    }
}