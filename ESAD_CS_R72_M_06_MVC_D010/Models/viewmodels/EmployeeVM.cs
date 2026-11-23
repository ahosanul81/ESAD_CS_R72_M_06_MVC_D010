using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D010.Models.ViewModels
{
    public class EmployeeVM
    {
        public int EmployeeId { get; set; }
        [Required, StringLength(50), Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        [Required, Display(Name = "Join Date"), Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Picture")]
        public HttpPostedFileBase PicturePath { get; set; }
        public bool IsActive { get; set; }
        [Required, Display(Name = "Salary"), Column(TypeName = "money")]
        public decimal Salary { get; set; }
        public List<int> QualificationList { get; set; }
        
    }
}