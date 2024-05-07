namespace MVCLab.Models
{
    public class Department
    {


        public int ID { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }

        public List<Instructor> instructors { set; get; }
        public List<Course> courses { set; get; }

        public List<Trainee> trainees { set; get; }
        public  bool isDeleted { get; set; }
    }
}
