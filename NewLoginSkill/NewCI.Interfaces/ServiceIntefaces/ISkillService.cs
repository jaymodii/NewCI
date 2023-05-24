using NewCI.Entities.DTOs;
using NewCI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCI.Interfaces.ServiceInterfaces
{
    public interface ISkillService
    {
        public AdminScreenDto<SkillCRUDDto> GetSkills(int pagenumber = 1, int pageSize = 5);
        public SkillCRUDDto? GetByID(long id);
        public Task<bool> SaveSkill(SkillCRUDDto skilldata);
        public bool DeleteSkill(long id);
    }
}
