using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLab.Models;
using MVCLab.Repository;
using MVCLab.ViewModel;

namespace MVCLab.Controllers
{
    public class TraineeController : Controller
    {context context = new context();
     //traineeRepository traineeRepository;

     //  public TraineeController()
     //   {
     //       traineeRepository = new traineeRepository();
     //   }

     
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult showResult(int id,int crsID)
        {

            return View("showResult",id);
        }

        public IActionResult traineeDetails(int id ,int crsID)
        {



            List<CrsResult> crsResult = context.CrsResult.
                 Include(e => e.trainee).
                 Include(c => c.course).Where(c => c.TraineeID == id&&c.CourseID==crsID).ToList();

            traineeNameWithCourseNameAndDegree trainee1 = new traineeNameWithCourseNameAndDegree();

            foreach (var c in crsResult) { 
            trainee1.traineeName = c.trainee.Name;
            trainee1.degree = c.Degree;
            trainee1.crsName = c.course.Name;
            trainee1.mindegree = c.course.minDegree;

            if (trainee1.degree > trainee1.mindegree)
            {
                trainee1.color = "blue";
            }
            else
            {
                trainee1.color = "red";
            }

        }
            return View("traineeDetails",trainee1);
        }
       
        public IActionResult traineeCourseResult(int id)
        {
            traineeResultData trainee =new traineeResultData();


            List<CrsResult> crsResult = context.CrsResult
                .Include(t => t.trainee)
                .Include(c => c.course)
                .Where(c => c.TraineeID == id)
                .ToList();

            trainee.TraineeName = crsResult.FirstOrDefault().trainee.Name;
            foreach(var item in crsResult)
            {
                if (item.Degree > item.course.minDegree)
                {
                    trainee.coursesData.Add(new CourseWithDegree
                    {
                        CourseName = item.course.Name,
                        CourseDegree = item.Degree
                        ,color="green"
                    });
                }
                else
                {
                    trainee.coursesData.Add(new CourseWithDegree
                    {
                        CourseName = item.course.Name,
                        CourseDegree = item.Degree
                       ,
                        color = "red"
                    });

                }
            }
            

            
            return View("traineeCourseResult", trainee);
        }


    }
}
