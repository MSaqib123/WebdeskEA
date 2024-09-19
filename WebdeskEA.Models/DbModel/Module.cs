using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Models.DbModel
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ModuleName { get; set; }
        public bool IsModule { get; set; }
        public bool IsSubModule { get; set; }
        public bool IsForm { get; set; }
        public bool SubForm { get; set; }
        public int? ParentModuleId { get; set; }
        [MaxLength(500)]
        public string ModuleUrl { get; set; }
        [MaxLength(500)]
        public string ModulePath { get; set; }
        public bool IsTab { get; set; }
        [MaxLength(200)]
        public string ModuleIcon { get; set; }
        public bool IsExpand { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
