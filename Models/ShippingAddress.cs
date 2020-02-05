using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace ECom.Models
{
  public class ShippingAddress
  {
    [Key] public int ShippingAddressId { get; set; }

    public string Street { get; set; }

    public string Street2 { get; set; }
    public string City { get; set; }

    public string State { get; set; }

    public int ZipCode { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Order Order { get; set; }

    public User User { get; set; }

  }
}