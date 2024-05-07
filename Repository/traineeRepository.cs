using MVCLab.Models;

namespace MVCLab.Repository
{
    public class traineeRepository: ItraineeRepository
    {
        context context;

        traineeRepository(context _context)
        {
            context = _context;
        }
        public List<Trainee> getAll()
        {
            return context.Trainees.ToList();
        }

        public Trainee get(int id)
        {
            return context.Trainees.FirstOrDefault(e => e.Id == id);

        }
        public void Insert(Trainee trainee)
        {
            context.Add(trainee);
        }

        public void Update(Trainee trainee)
        {
            context.Update(trainee);
        }

        public void Delete(int id)
        {

            Trainee trainee = get(id);
            context.Remove(trainee);

        }

        public void softDelete(int id)
        {

            Trainee trainee = get(id);

            trainee.isDeleted = true;
        }

        public int save()
        {
            return context.SaveChanges();
        }
    }
}
