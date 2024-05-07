using Microsoft.AspNetCore.Mvc;
using MVCLab.Models;
using MVCLab.Repository;
using MVCLab.ViewModel;

namespace MVCLab.Controllers
{
    public class InstructorController : Controller
    {
        // context context=new context();
        // InstructorBL instructorBL=new InstructorBL();

        //instructorRepository instructorRepository;
        //courseRepository courseRepository;
        //departmentRepository departmentRepository;

        IinstructorRepository instructorRepository;
        IcourseRepository courseRepository;
        IdepartmentRepository departmentRepository;

    public InstructorController(IinstructorRepository _instructorRepository,IcourseRepository _icourseRepository,IdepartmentRepository _idepartmentRepository) {
            instructorRepository = _instructorRepository;
            courseRepository = _icourseRepository;
            departmentRepository = _idepartmentRepository;
        } 
        public IActionResult Index()
        {
            List<Instructor> instructors = instructorRepository.getAll();

            return View("showall",instructors);
        }

        public IActionResult GetInsDetails(int id)
        {
            Instructor instructor = instructorRepository.get(id);
            return View("GetInsDetails", instructor);

        }
        public IActionResult GetInsById(int id)
        {
            List<Instructor> instructorsModels = instructorRepository.getAll().Where(e => e.departmentID == id).ToList();
                
                //instructorBL.GetInstructorsInDepartment(id);
            return View("GetInsById", instructorsModels);
        }

        public IActionResult getCourseByDeptID(int id)
        {
            List<Course> courses=courseRepository.getAll().Where(e=>e.DepartmentID==id&&e.IsDeleted==false)
                .ToList();
            return Json(courses);

        }
        [HttpGet]
        public IActionResult New()
        {
            InstructorDataVM instructorDataVM=new InstructorDataVM();

           List<Course>courses=courseRepository.getAll().ToList(); 
            List<Department>departments=departmentRepository.getAll().ToList();
            instructorDataVM.department = departments;
            instructorDataVM.course = courses.Where(e=>e.IsDeleted==false).ToList();


            return View("addInstructor",instructorDataVM);
        }
        [HttpPost]
       public IActionResult SaveRecord(InstructorDataVM  instructorDataVM)
        {
            if (instructorDataVM.Name != null && instructorDataVM.Salary != null && instructorDataVM.Image != null && instructorDataVM.Address != null)
            {
                Instructor instructor = new Instructor();

                instructor.Address = instructorDataVM.Address;
                instructor.Name = instructorDataVM.Name;
                instructor.Salary = instructorDataVM.Salary;
                instructor.departmentID = instructorDataVM.departmentID;
                instructor.courseID = instructorDataVM.courseID;
                instructor.Image=instructorDataVM.Image;
                instructorRepository.Insert(instructor);
                instructorRepository.save();
                return RedirectToAction("index");
            }
             List<Department> department = departmentRepository.getAll().ToList();
            List<Course>courses=courseRepository.getAll().ToList();
            instructorDataVM.department = department;
            instructorDataVM.course = courses;
            return View("addInstructor",instructorDataVM);
        }


    }
}
