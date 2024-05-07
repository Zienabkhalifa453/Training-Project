using Microsoft.EntityFrameworkCore;

namespace MVCLab.Models
{
    public class InstructorBL
    {
        context context = new context();

        public List<Instructor> GetAllInstructors()
        {
            return context.Instructors.ToList();
        }

        public Instructor GetInstructorDetails(int id)
        {
            return context.Instructors.FirstOrDefault(e => e.ID == id);
        }

        public List<Instructor> GetInstructorsInDepartment(int deptID)
        {
            return context.Instructors
                          .Include(e => e.department)
                          .Where(e => e.departmentID == deptID)
                          .ToList();

        }
    }
}
