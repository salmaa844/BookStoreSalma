using BookStore.Data;
using BookStore.Models;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext context;
        public AuthorsController(ApplicationDbContext context)
        {
           this. context = context;
        }

        

        public IActionResult Index()
        {
            var authors = context.Authors.ToList();
            var authorsVM = new List<AuthorVM>();
            foreach(var author in authors)
            {
                var authorVM = new AuthorVM()
                {
                    Id = author.Id,
                    Name = author.Name,
                    CreatedOn = author.CreatedOn,
                    UpdatedOn = author.UpdatedOn,
                };
                authorsVM.Add(authorVM);

            }
            return View(authorsVM);
        }
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Form(AuthorVM authorVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", authorVM);
            }

            var author = new Author
            { Name = authorVM.Name };

            try
            {
                context.Authors.Add(author);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                ModelState.AddModelError("Name", "category name aready exists");

                return View(authorVM);
            }

        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            var model = new AuthorFormVM
            {
                Id = author.Id,
                Name = author.Name
            };
            return View("Form", model);
        }
        [HttpPost]
        public IActionResult Edit(AuthorFormVM authorFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", authorFormVM);
            }

            var author = context.Authors.Find(authorFormVM.Id);
            if (author == null)
            {
                return NotFound();
            }

           
            author.Name = authorFormVM.Name;
            author.UpdatedOn = DateTime.Now;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var author = context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            context.Authors.Remove(author);
            context.SaveChanges();
            return Ok();

        }
    }
}
