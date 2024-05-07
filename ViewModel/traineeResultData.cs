using MVCLab.Models;

namespace MVCLab.ViewModel
{
    public class traineeResultData
    {
       public string TraineeName { set; get; }
        public List<CourseWithDegree> coursesData { get; set; }

 
        public traineeResultData()
        {
            coursesData = new List<CourseWithDegree>();
        }

    }

    public class CourseWithDegree
    {
        public string CourseName { get; set; }
        public int CourseDegree { get; set; }
        public string color { get; set; }
    }
}
