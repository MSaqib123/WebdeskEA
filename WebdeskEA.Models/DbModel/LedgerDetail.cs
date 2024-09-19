using System;
using System.Collections.Generic;

namespace WebdeskEA.Models.DbModel;

public partial class LedgerDetail
{
    public int Id { get; set; }

    public int? LedgerId { get; set; }

    public int? SrNo { get; set; }

    public int? Coaid { get; set; }

    public decimal? DrAmount { get; set; }

    public decimal? CrAmount { get; set; }

    public string? DrCr { get; set; }

    public string? Remarks { get; set; }

    public int? RefAccLedgerMstId { get; set; }
}
