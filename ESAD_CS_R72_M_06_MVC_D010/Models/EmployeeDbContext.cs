using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ESAD_CS_R72_M_06_MVC_D010.Models
{
    public class EmployeeDbContext: DbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Qualification> Qualifications { get; set; }
        DbSet<EmployeeQualification> EmployeeQualifications { get; set; }
    }
}