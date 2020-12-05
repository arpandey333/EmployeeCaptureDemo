using DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProj.Models.DTO
{
    public class Filter
    {
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
    }
    public class EmployeeList
    {
        public int? Id { get; set; }


        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }


        [Display(Name = "Experience")]
        public String DateOfJoining
        {
            get; set;
        }


        [Display(Name = "Is Current Employee")]
        public bool IscurrentEmployee { get; set; }


        [Display(Name = "Annual Salary")]
        public decimal AnnualSalary { get; set; }


        [Display(Name = "Department")]
        public Department Department { get; set; }
    }
    public class EmplyeeListDto
    {
        public Filter filter { get; set; }
        public List<EmployeeList> employeeList { get; set; }
    }

}