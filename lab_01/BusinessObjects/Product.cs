using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BusinessObjects;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    [Required(ErrorMessage = "Category is required")]
    public int CategoryId { get; set; }

    public short? UnitsInStock { get; set; }

    public decimal? UnitPrice { get; set; }
    [ValidateNever]
    public virtual Category Category { get; set; } = null!;
}
