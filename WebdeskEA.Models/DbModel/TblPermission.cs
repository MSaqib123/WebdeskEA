using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class TblPermission
{
    public int PermissionId { get; set; }

    public int MenuId { get; set; }

    public int RoleId { get; set; }

    public bool CanRead { get; set; }

    public bool CanWrite { get; set; }

    public bool CanView { get; set; }
}
