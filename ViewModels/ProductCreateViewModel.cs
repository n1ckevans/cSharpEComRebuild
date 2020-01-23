using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace ECom.ViewModels
{
  public class ProductCreateViewModel
  {
   
    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }


   public IFormFile Photo { get; set;}

  }
}


