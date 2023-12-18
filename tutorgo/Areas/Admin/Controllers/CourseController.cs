using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tutorgo.Models;
using tutorgo.Repository;

namespace tutorgo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CourseController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Courses.OrderByDescending(p => p.Id).Include(p => p.Category).ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseModel course)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", course.CategoryId);
            if (ModelState.IsValid)
            {
                course.Slug = course.Name.Replace(" ", "-");
                var slug = await _dataContext.Courses.FirstOrDefaultAsync(p => p.Slug == course.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Khoá học đã có");
                    return View(course);
                }
                if (course.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/img");
                    string imageName = Guid.NewGuid().ToString() + "_" + course.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await course.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    course.Image = imageName;
                }
                _dataContext.Add(course);
                await _dataContext.SaveChangesAsync();
                TempData["message"] = "Create course successfully";
                return RedirectToAction("Index", "Course");
            }
            else
            {
                List<string> errors = new List<string>();
                foreach(var value in ModelState.Values)
                {
                    foreach(var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            return View(course);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            CourseModel course = await _dataContext.Courses.FindAsync(Id);
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", course.CategoryId);
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, CourseModel course)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", course.CategoryId);
            if (ModelState.IsValid)
            {
                course.Slug = course.Name.Replace(" ", "-");
                var slug = await _dataContext.Courses.FirstOrDefaultAsync(p => p.Slug == course.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Khoá học đã có");
                    return View(course);
                }
                if (course.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/img");
                    string imageName = Guid.NewGuid().ToString() + "_" + course.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await course.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    course.Image = imageName;
                }
                _dataContext.Update(course);
                await _dataContext.SaveChangesAsync();
                TempData["message"] = "Update course successfully";
                return RedirectToAction("Index", "Course");
            }
            else
            {
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            return View(course);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            CourseModel course = await _dataContext.Courses.FindAsync(Id);
            if(!string.Equals(course.Image, "noimage.jpg"))
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/img");
                string oldfileImage = Path.Combine(uploadsDir, course.Image);
                if (System.IO.File.Exists(oldfileImage))
                {
                    System.IO.File.Delete(oldfileImage);
                }
            }
            _dataContext.Courses.Remove(course);
            await _dataContext.SaveChangesAsync();
            TempData["message"] = "Delete course successfully";
            return RedirectToAction("Index", "Course");
        }
    }
}
