using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Models.MappingModel;
public class ProductDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Sku { get; set; }
    public int? BrandId { get; set; }
    public string? DesignNumber { get; set; }
    public decimal? Ppq { get; set; }
    public decimal? SalePrice { get; set; }
    public string? ProductCode { get; set; }
}
