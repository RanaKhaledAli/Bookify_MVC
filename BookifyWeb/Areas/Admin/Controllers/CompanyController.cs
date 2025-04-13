using Bookify.DataAcess.Repository.IRepository;
using Bookify.Models;
using Bookify.Models.ViewModels;
using Bookify.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookifyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public CompanyController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
           
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
           
            return View(objCompanyList);
        }
        [HttpGet]
        //Update-Insert
        public IActionResult Upsert(int? id)
        {

            
            if (id == null||id==0)
            {
                //Create
                // Return the View with the CompanyVM populated
                return View(new Company());

            }
            else
            {
                //update
                Company Companyobj=_unitOfWork.Company.Get(u=>u.Id==id);
                return View(Companyobj);
            }
            

        }
        [HttpPost]
        public IActionResult Upsert(Company objCompany)
        {
            // Check if the model is valid (i.e., all form data is correct and no validation errors).
            if (ModelState.IsValid)
            {
               
                // If the Company Id is 0, it's a new Company, so add it to the database.
                if (objCompany.Id == 0)
                {
                    _unitOfWork.Company.Add(objCompany);
                }
                else
                {
                    // If the Company already exists (not a new Company), update it in the database.
                    _unitOfWork.Company.Update(objCompany);
                }

                // Save the changes to the database.
                _unitOfWork.Save();

                // Set a success message in TempData that can be displayed after redirecting.
                TempData["Success"] = "Company Created Successfully";

                // Redirect to the Index action, where the list of Companys is displayed.
                return RedirectToAction("Index");
            }
            else
            {
                // If the model state is invalid

                return View(objCompany);
            }

        }

        
           
        
        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{

        //    if (id == 0 || id == null)
        //    {
        //        return NotFound();
        //    }
        //    Company? CompanyFromDb = _unitOfWork.Company.Get(p => p.Id == id);

        
        //    if (CompanyFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(CompanyFromDb);
        //}

        //[HttpPost]
        //public IActionResult Edit(Company Company)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Company.Update(Company);
        //        _unitOfWork.Save();
        //        TempData["Success"] = "Company Updated Successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            Company? CompanyFromDb = _unitOfWork.Company.Get(p => p.Id == id);
            if (CompanyFromDb == null)
            {
                return NotFound();
            }
            return View(CompanyFromDb);
        }
        [HttpPost,ActionName("Delete")]
       
        public IActionResult DeletePost(int? id)
        {
            Company? CompanyFromDb = _unitOfWork.Company.Get(p => p.Id == id);
            if (CompanyFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Company.Remove(CompanyFromDb);
            _unitOfWork.Save();
            TempData["Success"] = "Company Deleted Successfully";
            return RedirectToAction("Index");


        }
        #region API Calls
        [HttpGet]
        public IActionResult GetAll ()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();

            return Json(new {data=objCompanyList});
        }
        #endregion
    }
}

