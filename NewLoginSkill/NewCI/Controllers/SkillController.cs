using Microsoft.AspNetCore.Mvc;
using NewCI.Entities.DTOs;
using NewCI.Entities.ViewModels;
using NewCI.Interfaces.ServiceInterfaces;

namespace NewCI.Controllers
{
    public class SkillController : Controller
    { 
        public readonly ISkillService _skillService ;
        
        public SkillController(ISkillService skillService)
        {
            
            _skillService=skillService;
        }
        public bool CheckSession()
        {
            return HttpContext.User.Identity!.IsAuthenticated;
        }
      
        public  IActionResult SkillsPage(int pagenumber=1,int pagesize=5,string? search=null)
        {
            AdminScreenDto<SkillCRUDDto> adminScreen = _skillService.GetSkills(pagenumber, pagesize,search);
            if (adminScreen == null)
            {
                TempData["info"] = "Unable to fetch skills , Contact Developer";
            }
            
                ViewBag.searchString=search;

            
            return View(adminScreen);
        }
        [HttpGet]
        public IActionResult AddSkillPage(long Id=0,int pagenumber=1,string? search=null)
        {
            ViewBag.page = pagenumber;
            ViewBag.search=search;
            if (Id == 0)
            {
                return View();
            }
            else
            {
                SkillCRUDDto? skill = _skillService.GetByID(Id);
                if(skill != null)
                {
                return View(skill);

                }
                else
                {
                    TempData["info"] = "Unable to Get Skill Data";
                    return RedirectToAction("SkillsPage", "Skill");
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> SaveSkill(SkillCRUDDto skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            bool isSaved = await _skillService.SaveSkill(skill);
            if (isSaved)
            {
               if(skill.SkillId == null)
                {
                    TempData["success"] = "Skill is Saved Successfully!!";
                }
                else
                {

                TempData["success"] = "Skill is Updated Successfully!!";
                }
            }
            else
            {
                TempData["info"] = "This skill is already added.\nInstead of adding modify existing one !!";
            }
            return RedirectToAction("AddSkillPage", "Skill", new { Id = skill.SkillId });
        }
        [HttpPost]
        public bool DeleteSkill(long Id)
        {
            TempData["success"] = "Skill is Deleted!!";
            return _skillService.DeleteSkill(Id);

        }

    }
}
