using Microsoft.AspNetCore.Mvc;
using MVCLab.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCLab.ViewModel
{
    public class CourseDataVM
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="name must be less than 20")]
        [MinLength(2, ErrorMessage = "NAme Must be More Than 2 Letter")]
        [unique]
        public string Name { get; set; }
        [Required]
        [Range(50,100)]
        public int Degree { get; set; }
        [Required]
        [Remote("checkMinDegree","Course",ErrorMessage ="min degree must be less than the course degree",AdditionalFields = "Degree")]
        public int MinDegree { get; set; }
        public int DepartmentId { get; set; }
        public List<Department >?Department { get; set; }
        [Required]
        [Remote("checkHours","Course",ErrorMessage ="Invalid Hour")]
        public int Hours { get; set; }
        public int InstructorId { get; set; }
    }
}
