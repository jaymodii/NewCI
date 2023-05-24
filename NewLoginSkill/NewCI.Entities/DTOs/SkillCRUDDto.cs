using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Entities.DTOs
{
    public class SkillCRUDDto
    {


        public long? SkillId { get; set; } = 0;

        [Required(ErrorMessage = "Please Enter Skill Name. ")]
        //[RegularExpression(@"[a-zA-Z] [a-zA-Z]+[a-zA-Z]$",ErrorMessage="Please Enter Proper Skill.")]
        [RegularExpression(@"^[a-zA-Z]+( [a-zA-Z]+)*$", ErrorMessage = "Please Enter a valid skill.")]
        public string SkillName { get; set; } = null!;
        [Required(ErrorMessage = "Select Status")]
        public bool Status { get; set; }

        public SkillCRUDDto(long id, string name, bool status)
        {
            SkillId = id;
            SkillName = name;
            Status = status;
        }
        public SkillCRUDDto() { }
    }
}
