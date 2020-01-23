using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Models
{
  public class Association
  {
    [Key]
    public int AssociationId { get; set; }

    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Product AssocProd { get; set; }
    public Category AssocCat { get; set; }
  }
}