using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class Ledger
{
    public int Id { get; set; }

    public int? InvoiceTypeId { get; set; }

    public string? InvoiceNo { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public int? RefId { get; set; }

    public DateOnly? DueDate { get; set; }

    public int? InvoiceStatusId { get; set; }

    public int? VoucherId { get; set; }
}
