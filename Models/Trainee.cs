using Microsoft.AspNetCore.Cors.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCLab.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Adress { get; set; }
        public int Grade { get; set; }
        [ForeignKey("department")]
        public int ?departmentID { get; set; }
        public Department department { set; get; }

        public List<CrsResult> courseResults { set; get; }



        public  bool isDeleted { get; set; }
    }
}
