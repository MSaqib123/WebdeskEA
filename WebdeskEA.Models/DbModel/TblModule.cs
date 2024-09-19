using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class TblModule
{
    public int ModuleId { get; set; }

    public string ModuleName { get; set; } = null!;

    public string? Icon { get; set; }

    public bool? Active { get; set; }
}
