using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLab.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { set; get; }
        public int Salary { get; set; }
        public string Address { set; get; }
        public bool isDeleted { get; set; }


        [ForeignKey("department")]
        public int? departmentID { get; set; }
        public Department department { set; get; }

        [ForeignKey("course")]
        public int? courseID { get; set; }
        public Course course { set; get; }
    }
}
