using NewCI.Entities;
using NewCI.Entities.DTOs;
using NewCI.Entities.Models;
using NewCI.Entities.ViewModels;
using NewCI.Interfaces.RepositoryInterfaces;
using NewCI.Interfaces.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NewCI.Business.Services
{
    public class SkillService : GenericService<Skill>, ISkillService
    {
        public SkillService(IGenericInterface<Skill> repository) : base(repository)
        {
        }
        public AdminScreenDto<SkillCRUDDto> GetSkills(int pagenumber = 1, int pageSize = 5)
        {
            PagedResult<Skill> records = GetAll(pagenumber, "SkillName", pageSize);
            var skillDtos = records.Entries!.Select(skill => new SkillCRUDDto(skill.SkillId, skill.SkillName!, skill.Status)).ToList();
            return new AdminScreenDto<SkillCRUDDto>(skillDtos, records.TotalPages, pagenumber);
        }
        public SkillCRUDDto? GetByID(long id)
        {
            Skill? skill = base.GetByID(id);
            if (skill == null)
            {
                throw new Exception();
            }
            SkillCRUDDto skillCRUDDto = new SkillCRUDDto(skill.SkillId, skill.SkillName!, skill.Status);
            return skillCRUDDto;
        }
        private async Task<bool> SkillExists(string skillName)
        {
            var allSkills = await GetAllRecordsAsync();
            var existingSkill = allSkills.FirstOrDefault(s => string.Equals(s.SkillName, skillName, StringComparison.OrdinalIgnoreCase));
            return existingSkill != null;
        }
        public async Task<bool> SaveSkill(SkillCRUDDto skilldata)
        {
            bool skillExists = await SkillExists(skilldata.SkillName);
            if (skillExists)
            {
                return false;
            }
            if (skilldata.SkillId == null)
            {
                Skill skill = new Skill()
                {
                    SkillName = skilldata.SkillName,
                    Status = skilldata.Status,
                };
                if (base.Add(skill))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Failed to add the skill.");
                }
            }
            else
            {
                Skill? skill = base.GetByID((long)skilldata.SkillId!);
                if (skill == null)
                {
                    throw new Exception("Skill not found.");
                }
                else
                {
                    skill.Status = skilldata.Status;
                    skill.SkillName = skilldata.SkillName;
                    skill.UpdatedAt = DateTime.Now;
                    if (base.Update(skill))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Failed to add the skill.");
                    }
                }
            }
        }
        public bool DeleteSkill(long id)
        {
            return base.Delete(id);
        }
    }
}
