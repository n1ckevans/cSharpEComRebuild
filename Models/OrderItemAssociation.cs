using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Models
{
  public class OrderItemAssociation
  {
    [Key]
    public int OrderItemAssociationId { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; }

     public OrderItem OrderItem { get; set; }

    public int OrderItemId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


  }
}