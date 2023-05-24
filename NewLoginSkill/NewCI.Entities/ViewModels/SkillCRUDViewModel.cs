using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Entities.ViewModels
{
    public class SkillCRUDViewModel
    {

        public long SkillId { get; set; }
        [Required(ErrorMessage = "Please Enter Skill. ")]
        //[RegularExpression(@"[a-zA-Z] [a-zA-Z]+[a-zA-Z]$",ErrorMessage="Please Enter Proper Skill.")]
        [RegularExpression(@"^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "Name must contain only letters.")]

        public string SkillName { get; set; } = null!;
        [Required(ErrorMessage = "Select Status")]
        public bool Status { get; set; } = true;
    }
}
