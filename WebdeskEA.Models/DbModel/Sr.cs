using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class Sr
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? Date { get; set; }

    public int? BusinessCategoryId { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Disc { get; set; }

    public decimal? Total { get; set; }
}
