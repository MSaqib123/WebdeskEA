using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class Po
{
    public int Id { get; set; }

    public int? SupplierId { get; set; }

    public DateOnly? Date { get; set; }

    public int? BusinessCategoryId { get; set; }

    public decimal? SubTotal { get; set; }

    public decimal? Disc { get; set; }

    public decimal? Total { get; set; }
}
