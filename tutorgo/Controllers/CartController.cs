using Microsoft.AspNetCore.Mvc;
using tutorgo.Models;
using tutorgo.Models.ViewModels;
using tutorgo.Repository;

namespace tutorgo.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _dataContext;
        public CartController(DataContext _context)
        {
            _dataContext = _context;
        }
        public IActionResult Index()
        {
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemViewModel cartVM = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Price)
            };
            return View(cartVM);
        }
        public async Task<IActionResult> Add(int Id)
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                CourseModel course = await _dataContext.Courses.FindAsync(Id);
                List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
                CartItemModel cartItems = cart.Where(c => c.CourseId == Id).FirstOrDefault();

                if (cartItems == null)
                {
                    cart.Add(new CartItemModel(course));
                }
                HttpContext.Session.SetJson("Cart", cart);
                TempData["message"] = "Add item to cart successfully!";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            //CourseModel course = await _dataContext.Courses.FindAsync(Id);
            //List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            //CartItemModel cartItems = cart.Where(c => c.CourseId == Id).FirstOrDefault();

            //if (cartItems == null)
            //{
            //    cart.Add(new CartItemModel(course));
            //}
            //HttpContext.Session.SetJson("Cart", cart);
            //TempData["message"] = "Add item to cart successfully!";
            //return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Remove(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            CartItemModel itemToRemove = cart.SingleOrDefault(p => p.CourseId == Id);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);

                HttpContext.Session.SetJson("Cart", cart);
            }
            //cart.RemoveAll(p => p.CourseId == Id);
            //HttpContext.Session.Remove("Cart");
            TempData["message"] = "Delete item successfully!";
            return RedirectToAction("Index");
        }
    }
}
