using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLab.Models
{
    public class CrsResult
    {
        public int ID { get; set; }
        public int Degree { get; set; }

        [ForeignKey("trainee")]
        public int? TraineeID { get; set; }
        public Trainee trainee { set; get; }

        [ForeignKey("course")]
        public int? CourseID { get; set; }
        public Course course { set; get; }

    }
}
