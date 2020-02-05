using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Models
{
  public class PromoCode
  {
    [Key] public int PromoCodeId { get; set; }

    public string Code { get; set; }

    public float Discount { get; set; }


    public string Description { get; set; }

    public DateTime ExpirationDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;



  }
}
