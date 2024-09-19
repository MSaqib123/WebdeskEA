using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class Supplier
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? PhoneNo { get; set; }

    public string? Email { get; set; }

    public int? BusinessCategoryId { get; set; }

    public int? Coaid { get; set; }
}
