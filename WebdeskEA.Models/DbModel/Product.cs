using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Sku { get; set; }

    public int? BrandId { get; set; }

    public string? DesignNumber { get; set; }

    public decimal? Ppq { get; set; }

    public decimal? PurchasePrice { get; set; }

    public decimal? WholeSalePrice { get; set; }

    public decimal? SalePrice { get; set; }

    public int? ColorId { get; set; }

    public int? PurchaseCoaid { get; set; }

    public int? SaleCoaid { get; set; }

    public int? ReturnCoaid { get; set; }

    public int? DiscCoaid { get; set; }

    public int? ExpenseCoaid { get; set; }

    public string? ProductCode { get; set; }
}
