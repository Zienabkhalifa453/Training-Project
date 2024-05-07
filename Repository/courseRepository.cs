using MVCLab.Models;

namespace MVCLab.Repository
{
    public class courseRepository:IcourseRepository
    {


        context context;
        public courseRepository(context _context)
        {

            context = _context;
        }

        public List<Course> getAll()
        {
            return context.Courses.ToList();
        }

        public Course get(int id)
        {
            return context.Courses.FirstOrDefault(e => e.ID == id);

        }
        public void Insert(Course course)
        {
            context.Add(course);
        }

        public void Update(Course course)
        {
            context.Update(course);
        }

        public void Delete(int id)
        {

            Course course = get(id);
            context.Remove(course);

        }

        public void softDelete(int id)
        {

            Course course = get(id);

            course.IsDeleted = true;
        }

        public int save()
        {
            return context.SaveChanges();
        }
    }
}
