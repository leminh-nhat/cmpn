using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tutorgo.Repository;

namespace tutorgo.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _dataContext;

        public CourseController(DataContext context)
        {
            _dataContext = context;
        }

        public IActionResult Index()
        {
            var courses = _dataContext.Courses.Include("Category").ToList();
            return View(courses);
        }
        public async Task<IActionResult> Details(int Id)
        {
            if (Id == null) return RedirectToAction("Index");

            var coursesById = _dataContext.Courses.Where(p => p.Id == Id).FirstOrDefault();
            return View(coursesById);
        }
    }
}
