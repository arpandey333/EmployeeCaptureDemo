using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MvcProj.Models.DTO
{
    public class EmplyeeDTO
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name="Date Of Joining")]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [Display(Name = "Is Current Employee")]
        public bool IscurrentEmployee { get; set; }

        [Required]
        [Display(Name = "Annual Salary")]
        public decimal AnnualSalary { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartementId { get; set; }

        public List<SelectListItem> DepartmentList { get; set; }
    }
}