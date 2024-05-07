using MVCLab.Models;

namespace MVCLab.Repository
{
    public interface IdepartmentRepository
    {

        public List<Department> getAll();
        public Department get(int id);
        public void Insert(Department department);

        public void Update(Department department);
        public void Delete(int id);
        public void softDelete(int id);

        public int save();
    }
}