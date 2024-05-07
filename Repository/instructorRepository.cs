
using MVCLab.Models;

namespace MVCLab.Repository
{
    public class instructorRepository:IinstructorRepository
    {
        context context;
        public instructorRepository() {

            context = new context();
        }

        public List<Instructor> getAll()
        {
            return context.Instructors.ToList();
        }

        public Instructor get(int id)
        {
            return context.Instructors.FirstOrDefault(e => e.ID == id);

        }
        public void Insert(Instructor instructor)
        {
            context.Add(instructor);
        }

        public void Update(Instructor instructor)
        {
            context.Update(instructor);
        }

        public void Delete(int id) {

            Instructor instructor = get(id);
           context.Remove(instructor);

        }

        public void  softDelete(int id)
        {

            Instructor instructor = get(id);

            instructor.isDeleted = true;
        }

        public int save()
        {
            return context.SaveChanges(); 
        }
    }
}
