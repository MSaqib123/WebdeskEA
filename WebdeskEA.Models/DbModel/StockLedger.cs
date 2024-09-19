using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class StockLedger
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? InvoiceTypeId { get; set; }

    public string? InvoiceCode { get; set; }

    public int? StockIn { get; set; }

    public int? StockOut { get; set; }

    public int? StockReturn { get; set; }

    public decimal? Amount { get; set; }

    public int? BusinessCategoryId { get; set; }

    public int? AlterIn { get; set; }

    public int? AlterOut { get; set; }
}
