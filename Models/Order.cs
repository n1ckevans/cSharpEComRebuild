using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;         
using Microsoft.AspNetCore.Mvc;                       

namespace ECom.Models
{
  public class Order
  {
    [Key]public int OrderId { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public Product ProdOrder { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
  }
}
