using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class Sidetail
{
    public int Id { get; set; }

    public int? Siid { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public decimal? Total { get; set; }
}
