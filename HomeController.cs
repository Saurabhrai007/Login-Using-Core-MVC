using CrudCore.Data;
using CrudCore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Diagnostics;

namespace CrudCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = UserManager;
        }

        public HomeController(Context context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var res = _context.Details.ToList();
            return View(res);
        }
        public IActionResult Delete(int Id)
        {
            var data = _context.Details.Where(a => a.Id == Id).First();
            _context.Details.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Detail1());
        }
        [HttpPost]
        public IActionResult Create([Bind("Id, Name, PhoneNumber, Address, Email")] Detail1 detail1)
        {
            if (ModelState.IsValid)
            {

                _context.Add(detail1);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View(detail1); // Return the view with the current model data in case of errors
        }



        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Detail1 = _context.Details.Find(id);
            if (Detail1 == null)
            {
                return NotFound();
            }
            return View(Detail1);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Name, PhoneNumber, Address, Email")] Detail1 Detail1)
        {
            if (id != Detail1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(Detail1);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(Detail1);
        }


     

[HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
        public async Task<IActionResult> Login(Login models)
    {
        if (ModelState.IsValid)
        {
                var result = await _signInManager.PasswordSignInAsync(models.Email, models.Password, models.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        return View(models);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index");
    }
    public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
