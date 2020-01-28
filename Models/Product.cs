using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;         
using Microsoft.AspNetCore.Mvc;                       

namespace ECom.Models
{
  public class Product
  {
    [Key]
    public int ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public string Photo { get; set;}
 
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> AssocCats { get; set; }

   
    
  }
}
