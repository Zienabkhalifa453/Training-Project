using MVCLab.Models;

namespace MVCLab.Repository
{
    public interface IinstructorRepository
    {
        public List<Instructor> getAll();
       

        public Instructor get(int id);
       
        public void Insert(Instructor instructor);

        public void Update(Instructor instructor);

        public void Delete(int id);

        public void softDelete(int id);
        public int save();
    }
}