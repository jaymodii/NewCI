using NewCI.Entities.Data;
using NewCI.Entities.DTOs;
using NewCI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace NewCI.Repositories
//{
//    public class SkillRepository : GenericRepository<Skill>
//    {

//        public readonly DatabasewithDataContext _db;
//        public SkillRepository(DatabasewithDataContext db) : base(db)
//        {
//            _db = db;
//        }

//        public List<Skill> GetAllSkills(int page = 1, int size = 5)
//        {
//            return base.GetAll(page, size).ToList();
//        }
//        public SkillCRUDDto? GetSkill(long id)
//        {
//            Skill? skill = base.GetById(id);
//            if (skill == null)
//            {
//                throw new Exception();

//            }

//            SkillCRUDDto skillCRUDDto = new SkillCRUDDto(skill.SkillId, skill.SkillName!, skill.Status);

//            return skillCRUDDto;
//        }
//    }
//}
