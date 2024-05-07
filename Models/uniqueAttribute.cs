using System.ComponentModel.DataAnnotations;

namespace MVCLab.Models
{
    public class uniqueAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid
           (object? value, ValidationContext validationContext)
        {
            context context = new context();
            string name = value.ToString();
        Course courseFromDB=context.Courses.FirstOrDefault(c => c.Name == name);
           
            if (courseFromDB == null)
            {
                
                return ValidationResult.Success;
            }

            return new ValidationResult("this course Already Found");
        }
    }
}
