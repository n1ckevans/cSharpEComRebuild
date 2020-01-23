using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace ECom.Controllers
{
  public class HomeController : Controller
  {
    private EComContext dbContext;
    public HomeController(EComContext context)
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

    [HttpGet("")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet("/allprod")]
    public IActionResult AllProducts()
    {
      ViewBag.AllProds = dbContext.Products.ToList();
      ViewBag.AllProds.Reverse();
      return View();
    }

    [HttpGet("/product/{productid}")]
    public IActionResult Product(int productid)
    {
      ViewBag.CurrentProd = dbContext.Products.Include(c => c.AssocCats).FirstOrDefault(p => p.ProductId == productid);

      ViewBag.ShowCats = dbContext.Categories.Include(c => c.AssocProds).Where(cp => cp.AssocProds.Any(pc => pc.ProductId == productid));

      return View();
    }

    [HttpGet("/allcat")]
    public IActionResult AllCategories()
    {
      ViewBag.AllCats = dbContext.Categories.ToList();
      return View();
    }

    [HttpGet("category/{categoryid}")]
    public IActionResult Category(int categoryid)
    {

      ViewBag.CurrentCat = dbContext.Categories.Include(c => c.AssocProds).FirstOrDefault(p => p.CategoryId == categoryid);


      ViewBag.ShowProds = dbContext.Products.Include(p => p.AssocCats).Where(pc => pc.AssocCats.Any(c => c.CategoryId == categoryid));

      return View();
    }

    [HttpGet("addcart/{productid}")]
    public IActionResult AddCart(int productid)
    {
      // Order newOrder = new Order();
      //   newOrder.Quantity = 1;
      //   newOrder.ProductId = productid;
      //   newOrder.ProdOrder = dbContext.Products.FirstOrDefault(p => p.ProductId == productid);
      //   newOrder.UserId = 1;
      //   // change to (int)_uid;

      //   List<Order> orders = new List<Order>();
      //   orders.Add(newOrder);

      var usercart = HttpContext.Session.GetString("Cart");

      if (usercart == null)
      {
        Order newOrder = new Order();
        newOrder.Quantity = 1;
        newOrder.ProductId = productid;
        newOrder.ProdOrder = dbContext.Products.FirstOrDefault(p => p.ProductId == productid);
        newOrder.UserId = 1;
        // change to (int)_uid;

        List<Order> orders = new List<Order>();
        orders.Add(newOrder);

        HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(orders));
      }
      else
      {


        List<Order> cartitems = JsonConvert.DeserializeObject<List<Order>>(usercart);

        Order newOrder = new Order();
        newOrder.Quantity = 1;
        newOrder.ProductId = productid;
        newOrder.ProdOrder = dbContext.Products.FirstOrDefault(p => p.ProductId == productid);
        newOrder.UserId = 1;

        cartitems.Add(newOrder);
        HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cartitems));

      }



      return RedirectToAction("Cart");
    }

    [HttpGet("cart")]
    public IActionResult Cart()
    {
      var usercart = HttpContext.Session.GetString("Cart");
      

      if (usercart == null)
      {
        List<Order> orders = new List<Order>();
        ViewBag.Items = orders;
        return View();
      }


      List<Order> cartitems = JsonConvert.DeserializeObject<List<Order>>(usercart);
      ViewBag.Items = cartitems;

      return View();
    }

    [HttpGet("cart/checkout")]
    public IActionResult Checkout()
    {
      var usercart = HttpContext.Session.GetString("Cart");


      if (usercart == null)
      {
        return RedirectToAction("Cart");
      }

      List<Order> cartitems = JsonConvert.DeserializeObject<List<Order>>(usercart);

      foreach (Order currentOrder in cartitems)
      {
        
        //This is hard-coded. Replace with User from session
        // currentOrder.UserId = 1;
        dbContext.Orders.Add(new Order(){
        Quantity = currentOrder.Quantity,
        ProductId = currentOrder.ProductId,
        UserId = currentOrder.UserId

        });
        
      }

      dbContext.SaveChanges();

      return RedirectToAction("Summary");
    }

    [HttpGet("summary")]
    public IActionResult Summary()
    {
      var usercart = HttpContext.Session.GetString("Cart");
      

      if (usercart == null)
      {
        List<Order> orders = new List<Order>();
        ViewBag.Items = orders;
        return View();
      }


      List<Order> cartitems = JsonConvert.DeserializeObject<List<Order>>(usercart);
      ViewBag.Items = cartitems;
      
      HttpContext.Session.Clear();
      
      return View("Summary");
    }

  }
}
