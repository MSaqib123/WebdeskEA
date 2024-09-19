using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebdeskEA.Models.MappingModel
{
    public class UserRightDto
    {
        public UserRightDto()
        {
            UserRigthsList = new List<UserRightDto>();
        }
        public int Id { get; set; }
        [Required]
        public int ModuleId { get; set; }
        [Required]
        public string UserId { get; set; }
        public bool RightInsert { get; set; }
        public bool RightUpdate { get; set; }
        public bool RightView { get; set; }
        public bool RightDelete { get; set; }
        public bool RightPrint { get; set; }
        public bool RightEdit { get; set; }
        public bool RightApprove { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }

        [ValidateNever]
        public string ModuleName { get; set; }
        [ValidateNever]
        public string UserName { get; set; }

        [ValidateNever]
        public IEnumerable<UserRightDto> UserRigthsList { get; set; }

    }
}
