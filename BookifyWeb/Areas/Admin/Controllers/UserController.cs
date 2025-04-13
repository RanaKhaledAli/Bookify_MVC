using Bookify.DataAcess.Repository.IRepository;
using Bookify.Models;
using Bookify.Utility;
using BookifyWeb.DataAcess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace BookifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;


        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
            public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        
      
        
        
        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u=>u.Company).ToList();
           var userRoles=_db.UserRoles.ToList();
            var roles=_db.Roles.ToList();
            foreach (var user in objUserList) 
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new() { Name=""};
                }
            }
            return Json(new { data = objUserList });
        }
        [HttpPost]
        public IActionResult LockUnLock([FromBody] string id)
        {
            var objFromDb=_db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { sucess = false, message = "Error while Locking/unLocking" });
            }
            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now) {
                // user is currently locked and we need to unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            } else { 
            objFromDb.LockoutEnd= DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new {sucess=true , message="Operation Sucessfully"});
        }
        #endregion
    }
}
