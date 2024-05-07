using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCLab.Models;
using MVCLab.Repository;
using MVCLab.ViewModel;

namespace MVCLab.Controllers
{
    public class CourseController : Controller
    {
        //courseRepository courseRepository;
//        departmentRepository departmentRepository;


        IcourseRepository courseRepository;
        IdepartmentRepository departmentRepository;
    public  CourseController( IcourseRepository courseRepo,IdepartmentRepository deptRepo)

        {
            courseRepository = courseRepo;
            departmentRepository = deptRepo;
        }
        context context=new context();
        public IActionResult Index()
        {
            List<Course> courses = courseRepository.getAll().Where(c => !c.IsDeleted).ToList();


            return View("showAll",courses);
        }

        public IActionResult New()
        {
            CourseDataVM courseDataVM = new CourseDataVM();

           
            List<Department>departments=departmentRepository.getAll().Where(e=>e.isDeleted==false).ToList();

           
            courseDataVM.Department = departments;

            return View("addCourse",courseDataVM);
        }
        public IActionResult checkMinDegree(int MinDegree,int Degree)
        {
            if(MinDegree<Degree)
            {
                return Json(true);
            }else
            {
                return Json(false); 
            }

        }

        public IActionResult checkHours(int Hours)
        {
            if(Hours%3==0)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }

        [HttpPost]
        public IActionResult saveNew(CourseDataVM courseDataVM)
        { if (ModelState.IsValid==true)
            {

                if (courseDataVM.Degree != null && courseDataVM.DepartmentId != null && courseDataVM.Name != null && courseDataVM.MinDegree != null)

                {
                    Course course = new Course();
                    course.Name = courseDataVM.Name;
                    course.minDegree = courseDataVM.MinDegree;
                    course.DepartmentID = courseDataVM.DepartmentId;
                    course.Degree = courseDataVM.Degree;
                    course.Hours= courseDataVM.Hours;
                    courseRepository.Insert(course);
                    courseRepository.save();

                    return RedirectToAction("Index");
                }
            }
          List< Department> department = departmentRepository.getAll().ToList();
          

            courseDataVM.Department = department;
          
            return View("addCourse", courseDataVM);
        }

        public IActionResult courseListTrainee(int ID)
        {
            List<courseResultTraineeName> trainees = new List<courseResultTraineeName>();

          
            List<CrsResult> crsResult = context.CrsResult
                .Include(t => t.trainee)
                .Include(c => c.course)
                .Where(c => c.CourseID == ID)
                .ToList();

            foreach (var item in crsResult)
            {
                courseResultTraineeName courseResultTraineeName = new courseResultTraineeName();

                // Populate the properties of courseResultTraineeName
                courseResultTraineeName.courseName = item.course.Name;
                courseResultTraineeName.minDegree = item.course.minDegree;
                courseResultTraineeName.traineeDegree = item.Degree;
                courseResultTraineeName.TraineeName = item.trainee.Name;

                if (item.Degree > item.course.minDegree)
                {
                    courseResultTraineeName.color = "green";
                }
                else
                {
                    courseResultTraineeName.color = "red";
                }

                trainees.Add(courseResultTraineeName);
            }

            return View("courseListTrainee", trainees);
        }


        public IActionResult Edit(int id)
        {
            Course course = courseRepository.get(id);

            if (course == null)
            {
                return NotFound();
            }

            CourseDataVM courseDataVM = new CourseDataVM
            {
                Id = course.ID,
                Name = course.Name,
                Degree = course.Degree,
                MinDegree = course.minDegree,
                DepartmentId = course.DepartmentID??0
            };

            List<Department> departments = departmentRepository.getAll().ToList();
            courseDataVM.Department = departments;

            return View("Edit", courseDataVM);
        }

        [HttpPost]
        public IActionResult savechange(CourseDataVM courseDataVM)
        {
            if (courseDataVM.Degree!=null &&courseDataVM.MinDegree!=null&&courseDataVM.DepartmentId!=null&&courseDataVM.Name!=null)
            {
                Course course = courseRepository.get(courseDataVM.Id);

                if (course == null)
                {
                    return NotFound();
                }

                course.Name = courseDataVM.Name;
                course.Degree = courseDataVM.Degree;
                course.minDegree = courseDataVM.MinDegree;
                course.DepartmentID = courseDataVM.DepartmentId;


                courseRepository.save();

                return RedirectToAction("Index");
            }

            List<Department> departments = departmentRepository.getAll().ToList();
            courseDataVM.Department = departments;

            return View("Edit", courseDataVM);
        }



        public IActionResult DeleteCourse(int id)
        {
            Course course = courseRepository.get(id);
            if(course == null)
            {
                return NotFound();

            }

            courseRepository.softDelete(id);
            courseRepository.save();
            return RedirectToAction("Index");   


        }
    }
}
