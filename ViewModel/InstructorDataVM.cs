using MVCLab.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLab.ViewModel
{
    public class InstructorDataVM
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { set; get; }
        public int Salary { get; set; }
        public string Address { set; get; }
        public int departmentID { get; set; }
        public List <Department> department { set; get; }

        public int courseID { get; set; }
        public List<Course> course { set; get; }
    }

}

