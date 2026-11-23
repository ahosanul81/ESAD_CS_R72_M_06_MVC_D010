using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D010.Models
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        [Required, StringLength(50), Display(Name = "Qualification Name")]
        public string QualificationName { get; set; }

        public virtual ICollection<EmployeeQualification> EmployeeQualifications { get; set; } = new List<EmployeeQualification>();
    }
}