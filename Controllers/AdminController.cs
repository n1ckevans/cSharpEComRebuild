using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;


namespace ECom.Controllers
{
  public class AdminController : Controller
  {

    private EComContext dbContext;
    private readonly IHostingEnvironment hostingEnvironment;
    public AdminController(EComContext context,
                           IHostingEnvironment hostingEnvironment)
    {
      dbContext = context;

    }

    private int? _uid
    {
      get
      {
        return HttpContext.Session.GetInt32("UserId");
      }
    }

    private bool _isLoggedIn
    {
      get
      {
        int? uid = _uid;

        if (uid != null)
        {
          User loggedInUser =
              dbContext.Users.FirstOrDefault(u => u.UserId == uid);

          HttpContext.Session
              .SetString("FullName", loggedInUser.FullName());
        }
        return uid != null;
      }
    }

    [HttpGet("/admin")]
    public IActionResult Admin()
    {
      return View();

    }

    // Register as Admin
    public IActionResult Register(User newUser)
    {
      if (ModelState.IsValid)
      {
        bool isEmailTaken =
            dbContext.Users.Any(user => newUser.Email == user.Email);

        if (isEmailTaken)
        {
          ModelState.AddModelError("Email", "Email Taken");
        }
      }

      if (ModelState.IsValid == false)
      {
        return View("Admin");
      }

      PasswordHasher<User> hasher = new PasswordHasher<User>();
      newUser.Password = hasher.HashPassword(newUser, newUser.Password);

      dbContext.Users.Add(newUser);
      dbContext.SaveChanges();

      HttpContext.Session.SetInt32("UserId", newUser.UserId);
      return RedirectToAction("Dashboard");
    }

    public IActionResult Login(LoginUser loginUser)
    {
      if (ModelState.IsValid == false)
      {
        return View("Admin");
      }
      else
      {
        User dbUser = dbContext.Users.FirstOrDefault(user => loginUser.LoginEmail == user.Email);

        if (dbUser == null)
        {
          ModelState.AddModelError("LoginEmail", "Invalid Credentials");
        }
        else
        {
          User viewUser = new User
          {
            Email = loginUser.LoginEmail,
            Password = loginUser.LoginPassword
          };

          PasswordHasher<User> hasher = new PasswordHasher<User>();

          PasswordVerificationResult result =
              hasher.VerifyHashedPassword(viewUser, dbUser.Password, viewUser.Password);


          if (result == 0)
          {
            ModelState.AddModelError("LoginEmail", "Invalid Credentials");
          }
          else
          {
            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
          }
        }
      }
      if (ModelState.IsValid == false)
      {

        return View("Admin");
      }

      return RedirectToAction("Dashboard");
    }


    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
      int? uid = _uid;

      if (!_isLoggedIn)
      {
        return RedirectToAction("Admin");
      }

      ViewBag.User = dbContext.Users.FirstOrDefault(u => u.UserId == uid);




      return View();
    }


    [HttpGet("/addproduct")]
    public IActionResult AddProduct()
    {

      return View();
    }


    [HttpPost("/createprod")]
    public IActionResult CreateProd(Product newProd)
    {
      if (!ModelState.IsValid)
      {

        return View("AddProduct");
      }
      dbContext.Products.Add(newProd);
      dbContext.SaveChanges();
      return RedirectToAction("AllProductsAdmin");
    }



    [HttpGet("/addcategory")]
    public IActionResult AddCategory()
    {

      return View();
    }

    [HttpPost("/createcat")]
    public IActionResult CreateCat(Category newCat)
    {
      if (!ModelState.IsValid)
      {

        return View("AddCategory");
      }
      dbContext.Categories.Add(newCat);
      dbContext.SaveChanges();
      return RedirectToAction("AllCategoriesAdmin");
    }






    [HttpGet("/logout")]
    public IActionResult Logout()
    {

      int? uid = _uid;

      if (uid == null)
      {
        return RedirectToAction("Index", "Home");
      }

      HttpContext.Session.Clear();
      return RedirectToAction("Admin");
    }

    [HttpGet("/allprodadmin")]
    public IActionResult AllProductsAdmin()
    {
      int? uid = _uid;

      if (!_isLoggedIn)
      {
        return RedirectToAction("Admin");
      }

      ViewBag.AllProds = dbContext.Products.ToList();
      ViewBag.AllProds.Reverse();
      return View();
    }



    [HttpGet("/allcatadmin")]
    public IActionResult AllCategoriesAdmin()
    {
      int? uid = _uid;

      if (!_isLoggedIn)
      {
        return RedirectToAction("Admin");
      }

      ViewBag.AllCats = dbContext.Categories.ToList();
      return View();
    }



    [HttpGet("/deleteprod/{productid}")]
    public IActionResult DeleteProd(int productid)
    {
      int? uid = _uid;

      if (!_isLoggedIn)
      {
        return RedirectToAction("Admin");
      }

      Product CurrentProd = dbContext.Products.FirstOrDefault(p => p.ProductId == productid);
      dbContext.Products.Remove(CurrentProd);
      dbContext.SaveChanges();


      return RedirectToAction("AllProductsAdmin");

    }

    [HttpGet("/deletecat/{categoryid}")]
    public IActionResult DeleteCat(int categoryid)
    {
      int? uid = _uid;

      if (!_isLoggedIn)
      {
        return RedirectToAction("Admin");
      }

      Category CurrentCat = dbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryid);
      dbContext.Categories.Remove(CurrentCat);
      dbContext.SaveChanges();


      return RedirectToAction("AllCategoriesAdmin");

    }


    [HttpGet("/adminproduct/{productid}")]
    public IActionResult AdminProduct(int productid)
    {
      ViewBag.CurrentProd = dbContext.Products.Include(c => c.AssocCats).FirstOrDefault(p => p.ProductId == productid);

      ViewBag.AddCats = dbContext.Categories.Include(c => c.AssocProds).Where(cp => !cp.AssocProds.Any(pc => pc.ProductId == productid));

      ViewBag.ShowCats = dbContext.Categories.Include(c => c.AssocProds).Where(cp => cp.AssocProds.Any(pc => pc.ProductId == productid));

      return View();
    }

    [HttpGet("admincategory/{categoryid}")]
    public IActionResult AdminCategory(int categoryid)
    {

      ViewBag.CurrentCat = dbContext.Categories.Include(c => c.AssocProds).FirstOrDefault(p => p.CategoryId == categoryid);

      ViewBag.AddProds = dbContext.Products.Include(p => p.AssocCats).Where(pc => !pc.AssocCats.Any(c => c.CategoryId == categoryid));


      ViewBag.ShowProds = dbContext.Products.Include(p => p.AssocCats).Where(pc => pc.AssocCats.Any(c => c.CategoryId == categoryid));

      return View();
    }


    [HttpPost("/addprodcat")]
    public IActionResult AddProdCat(Association newAssoc)
    {
      int id = newAssoc.ProductId;


      if (dbContext.Associations.FirstOrDefault(p => p.ProductId == newAssoc.ProductId && p.CategoryId == newAssoc.CategoryId) != null)
      {
        return RedirectToAction("AdminProduct", new { productid = id });
      }

      dbContext.Associations.Add(newAssoc);
      dbContext.SaveChanges();
      return RedirectToAction("AdminProduct", new { productid = id });
    }



    [HttpPost("/addcatprod")]
    public IActionResult AddCatProd(Association newAssoc)
    {
      int id = newAssoc.CategoryId;


      if (dbContext.Associations.FirstOrDefault(c => c.CategoryId == newAssoc.CategoryId && c.ProductId == newAssoc.ProductId) != null)
      {
        return RedirectToAction("AdminCategory", new { categoryid = id });
      }

      dbContext.Associations.Add(newAssoc);
      dbContext.SaveChanges();
      return RedirectToAction("AdminCategory", new { categoryid = id });
    }

  }
}
