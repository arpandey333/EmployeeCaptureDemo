using DomainModels;
using MvcProj.Models.DTO;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProj.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeService employeeService;
        private IDepartmentService departmentService;
        public HomeController(IEmployeeService empService, IDepartmentService deptService)
        {
            this.employeeService = empService;
            this.departmentService = deptService;
        }

        // GET: Home
        public ActionResult Index(EmplyeeListDto emp)
        {
            var lstEmp = employeeService.GetFilteredEmployees(emp?.filter?.EmployeeName, emp?.filter?.DepartmentName);
            EmplyeeListDto empDto = new EmplyeeListDto();
            empDto.filter = new Models.DTO.Filter();
            empDto.employeeList = lstEmp != null && lstEmp.Count() > 0 ? lstEmp.Select(oo => new EmployeeList()
            {
                Id = oo.Id,
                Address = oo.Address,
                AnnualSalary = oo.AnnualSalary,
                DateOfJoining = string.Format("{0} Years and {1} Months",(DateTime.Now.Year - oo.DateOfJoining.Year), (DateTime.Now.Month - oo.DateOfJoining.Month)),
                Department = oo.Department,
                Name = oo.Name,
                IscurrentEmployee = oo.IscurrentEmployee
            }).ToList()
            : null;

            return View("EmployeeList", empDto);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            EmplyeeDTO emp = new EmplyeeDTO();
            emp.DateOfJoining = DateTime.Now;
            emp.DepartmentList = departmentService.GetDepartmentList().Select(oo=> new SelectListItem() {Text=oo.Name,Value = oo.Id.ToString() }).ToList();
            return View("AddEmployee", emp);
        }
        [HttpPost]
        public ActionResult AddEmployee(EmplyeeDTO empDto)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee();
                emp.Name = empDto.Name;
                emp.Address = empDto.Address;
                emp.AnnualSalary = emp.AnnualSalary;
                emp.DateOfJoining = empDto.DateOfJoining;
                emp.DepartementId = empDto.DepartementId;
                emp.IscurrentEmployee = empDto.IscurrentEmployee;
                employeeService.AddNewEmployee(emp);
                RedirectToAction("Index");
            }
            empDto.DepartmentList = departmentService.GetDepartmentList().Select(oo => new SelectListItem() { Text = oo.Name, Value = oo.Id.ToString() }).ToList();
            return View(empDto);
        }
    }
}