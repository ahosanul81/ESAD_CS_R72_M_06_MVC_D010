using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D010.Models
{
    public class EmployeeQualification
    {
        public int EmployeeQualificationId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Qualification")]
        public int QualificationId { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual Qualification Qualification { get; set; }
    }
}