using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext Context;
        public CategoryController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        public IActionResult Index()
        {
            var category = Context.Categories.ToList();
            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", categoryVM);
            }

            var category = new Category
            { Name = categoryVM.Name };

            try
            {
                Context.Categories.Add(category);
                Context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                ModelState.AddModelError("Name", "category name aready exists");

                return View(categoryVM);
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = Context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            var model = new CategoryVM { Id = id, Name = category.Name };
            return View("Create", model);

        }
        [HttpPost]
        public IActionResult Edit(CategoryVM categoryvm)
        {
            var category = Context.Categories.Find(categoryvm.Id);
            if (!ModelState.IsValid)
            {
                return View("Create", categoryvm);
            }
            if (category == null)
            {
                return NotFound();
            }
            category.Name = categoryvm.Name;
            category.UpdatedOn = DateTime.Now;
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            var categories = Context.Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }
            var viewmodel = new CategoryVM
            {
                Id = categories.Id,
                Name = categories.Name,
                CreatedOn = categories.CreatedOn,
                UpdatedOn = categories.UpdatedOn
            };
            return View(viewmodel);

        }
        public IActionResult Delete(int id)
        {
            var category = Context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            Context.Categories.Remove(category);
            Context.SaveChanges();
            return Ok();

        }
        public IActionResult ChakeName(CategoryVM categoryVM)
        {
            var IsExists = Context.Categories.Any(Category => Category.Name == categoryVM.Name);
            return Json(IsExists);
        }

    }
}
