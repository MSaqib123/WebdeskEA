using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class VoucherDetail
{
    public int Id { get; set; }

    public int? VoucherId { get; set; }

    public string? InvoiceNo { get; set; }

    public int? FromCoa { get; set; }

    public int? ToCoa { get; set; }
}
