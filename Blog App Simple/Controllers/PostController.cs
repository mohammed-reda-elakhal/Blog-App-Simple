using Blog_App_Simple.Models;
using Blog_App_Simple.Repository;
using Blog_App_Simple.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Blog_App_Simple.Controllers
{
    public class PostController : Controller
    {
        public PostController(IUnitOfWork Unit)
        {
            _Unit = Unit;
        }
        private readonly IUnitOfWork _Unit;


        // function
        private void UploadImage(Post post)
        {
            var file = HttpContext.Request.Form.Files;
            if (file.Count > 0)
            {
                // Upload Image
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(file[0].FileName);
                var filStream = new FileStream(Path.Combine(@"wwwroot/", "images", ImageName), FileMode.Create);
                file[0].CopyTo(filStream);
                post.Image = ImageName;

            }
            else if (post.Image == null && post.Id == null)
            {
                // Not Upload Image And New Employee
                post.Image = "DefaultImage.png";
            }
            else
            {
                // Edit
                post.Image = post.Image;
            }
        }

        public IActionResult Index()
        {
            var posts = _Unit.post.FindAll() ?? new List<Post>();
            ViewBag.Categories = new SelectList(_Unit.category.FindAll(), "categoryId", "Name");
            return View(posts);
        }

        //GET
        public IActionResult New()
        {
            ViewBag.Categories = new SelectList(_Unit.category.FindAll(), "categoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Post post)
        {
            UploadImage(post);
            if(ModelState.IsValid)
            {
                post.category = _Unit.category.FindById(post.CategoryId);
                _Unit.post.addOne(post);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_Unit.category.FindAll(), "categoryId", "Name");
            return View();
        }

        public IActionResult Edit(int Id)
        {
            ViewBag.Categories = new SelectList(_Unit.category.FindAll(), "categoryId", "Name");
            var Result = _Unit.post.FindById(Id);
            return View(Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            UploadImage(post);
            if(ModelState.IsValid)
            {
                _Unit.post.updateOne(post);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_Unit.category.FindAll(), "categoryId", "Name");
            return View();
        }

        public IActionResult Delete(int Id)
        {
            var Result = _Unit.post.FindById(Id);
            if (Result != null)
            {
                _Unit.post.removeOne(Result);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int Id)
        {
            var result = _Unit.post.FindById(Id);
            if(result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_Unit.category.FindAll(), "categoryId", "Name");
            return View(result);
        }
    }
}
