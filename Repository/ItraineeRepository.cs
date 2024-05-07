using MVCLab.Models;

namespace MVCLab.Repository
{
    public interface ItraineeRepository
    {


        public List<Trainee> getAll();
       
        public Trainee get(int id);
        public void Insert(Trainee trainee);
       

        public void Update(Trainee trainee);
      

        public void Delete(int id);
      

        public void softDelete(int id);



        public int save();
      
    }
}