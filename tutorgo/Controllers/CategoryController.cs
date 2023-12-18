using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tutorgo.Models;
using tutorgo.Repository;

namespace tutorgo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        public CategoryController(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<IActionResult> Index(string Slug = "")
        {
            CategoryModel category = _dataContext.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
            if (category == null) return RedirectToAction("Index");
            var coursesByCategory = _dataContext.Courses.Where(p => p.CategoryId == category.Id);
            return View(await coursesByCategory.OrderByDescending(p => p.Id).ToListAsync());
        }
    }
}
