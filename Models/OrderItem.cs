using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Models
{
  public class OrderItem
  {
    [Key]
    public int OrderItemId { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Product Product { get; set; }

    public ICollection<OrderItemAssociation> OrderItemAssociations { get; set; }

  }
}
