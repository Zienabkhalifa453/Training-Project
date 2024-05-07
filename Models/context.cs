using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace MVCLab.Models
{
    public class context:DbContext
    {

		public context() : base()
		{

		}

		public context(DbContextOptions<context> options) : base(options)
		{
		}

		public DbSet<Department> Departments { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CrsResult> CrsResult { get; set; }
        public DbSet<Course> Courses { get; set; }



   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { ID = 1, ManagerName = "Ayman", Name = "SD" },
                new Department { ID = 2, ManagerName = "Sara", Name = "HR" },
                new Department { ID = 3, ManagerName = "Ahmed", Name = "Finance" },
                new Department { ID = 4, ManagerName = "Layla", Name = "Marketing" }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { ID = 1, courseID = 2, Name = "Ahmed", departmentID = 1, Image = "m.png", Address = "Address1" },
                new Instructor { ID = 2, courseID = 3, Name = "Fatima", departmentID = 2, Image = "female.png", Address = "Address2" },
                new Instructor { ID = 3, courseID = 4, Name = "Omar", departmentID = 3, Image = "male.png", Address = "Address3" },
                new Instructor { ID = 4, courseID = 1, Name = "Lina", departmentID = 4, Image = "2.jpg", Address = "Address4" }
            );

            modelBuilder.Entity<Trainee>().HasData(
                new Trainee { Id = 1, Name = "Mariam", Image = "female.png", departmentID = 1, Grade = 95, Adress = "Alex" },
                new Trainee { Id = 2, Name = "Karim", Image = "male.png", departmentID = 2, Grade = 85, Adress = "Cairo" },
                new Trainee { Id = 3, Name = "Nour", Image = "female.png", departmentID = 3, Grade = 75, Adress = "Giza" },
                new Trainee { Id = 4, Name = "Tamer", Image = "male.png", departmentID = 4, Grade = 80, Adress = "Luxor" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { ID = 1, Name = "C#", Degree = 90, DepartmentID = 1, Hours = 40 },
                new Course { ID = 2, Name = "Java", Degree = 85, DepartmentID = 2, Hours = 35 },
                new Course { ID = 3, Name = "Python", Degree = 88, DepartmentID = 3, Hours = 45 },
                new Course { ID = 4, Name = "Marketing Strategies", Degree = 92, DepartmentID = 4, Hours = 30 }
            );

            modelBuilder.Entity<CrsResult>().HasData(
                new CrsResult() { ID = 1, Degree = 60, CourseID = 1, TraineeID = 1 },
                new CrsResult() { ID = 2, Degree = 75, CourseID = 2, TraineeID = 2 },
                new CrsResult() { ID = 3, Degree = 80, CourseID = 3, TraineeID = 3 },
                new CrsResult() { ID = 4, Degree = 85, CourseID = 4, TraineeID = 4 }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LENOVO\\MSSQLSERVER02;Initial Catalog=MvcLab;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }



    }
}
