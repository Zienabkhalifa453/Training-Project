using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLab.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int minDegree { get; set; }

        public int Hours { set; get; }

        [ForeignKey("department")]
        public int ?DepartmentID { get; set; }
        public Department department { set; get; }
        public List<Instructor> instructors { set; get; }

        public List<CrsResult> courseResults { set; get; }
        public bool IsDeleted { get; set; } // Default value is false


    }
}
