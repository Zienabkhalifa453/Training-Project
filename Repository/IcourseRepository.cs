using MVCLab.Models;

namespace MVCLab.Repository
{
    public interface IcourseRepository
    {
        public List<Course> getAll();

        public Course get(int id);

        public void Insert(Course course);

        public void Update(Course course);
       

        public void Delete(int id);
        
        public void softDelete(int id);


        public int save();
    }
}