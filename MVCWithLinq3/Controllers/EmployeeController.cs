﻿using System;
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
        
    }
}