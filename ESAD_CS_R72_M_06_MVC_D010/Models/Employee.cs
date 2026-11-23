using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D010.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required, StringLength(50),Display(Name ="Employee Name")]
        public string EmployeeName { get; set; }

        [Required, Column(TypeName = "date"), Display(Name ="Join date"), DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime JoinDate { get; set; }

        [Required, Column(TypeName = "Money")]
        public decimal Salary { get; set; }
        public string Picture { get; set; }
        public decimal IsActive { get; set; }


        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; } = new List<EmployeeQualification>();
    }
}