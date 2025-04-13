using Bookify.DataAcess.Repository.IRepository;
using Bookify.Models;
using Bookify.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BookifyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
          
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages");

            return View(productList);
        }
        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category,ProductImages")
            , Count = 1,
                ProductId = productId
            };   

            
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity=(ClaimsIdentity)User.Identity;
            var userId=claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            shoppingCart.ApplicationUserId = userId;
            ShoppingCart carFromDb=_unitOfWork.ShoppingCart.Get(u=>u.ApplicationUserId == userId && u.ProductId==shoppingCart.ProductId);
            if (carFromDb!=null)
            {
                //ShoppingCardExist
                carFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(carFromDb);

                _unitOfWork.Save();
            }
            else
            {
                //Add Card Record
                _unitOfWork.ShoppingCart.Add(shoppingCart);

                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.sessionCart,_unitOfWork.ShoppingCart.GetAll(u=>u.ApplicationUserId==userId).Count());
            }
            
            _unitOfWork.Save();
            TempData["Success"] = "Cart Updated Sucessfully";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
