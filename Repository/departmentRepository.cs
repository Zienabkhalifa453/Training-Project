using MVCLab.Models;

namespace MVCLab.Repository
{
    public class departmentRepository:IdepartmentRepository
    {

        context context;
        public departmentRepository(context _context)
        {

            context = _context;
        }

        public List<Department> getAll()
        {
            return context.Departments.ToList();
        }

        public Department get(int id)
        {
            return context.Departments.FirstOrDefault(e => e.ID == id);

        }
        public void Insert(Department department)
        {
            context.Add(department);
        }

        public void Update(Department department)
        {
            context.Update(department);
        }

        public void Delete(int id)
        {

            Department department = get(id);
            context.Remove(department);

        }

        public void softDelete(int id)
        {

            Department department = get(id);

            department.isDeleted = true;
        }

        public int save()
        {
            return context.SaveChanges();
        }
    }
}
