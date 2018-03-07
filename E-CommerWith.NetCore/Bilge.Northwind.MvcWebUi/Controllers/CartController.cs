using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bilge.Northwind.Business.Abstract;
using Bilge.Northwind.Entities.Concrete;
using Bilge.Northwind.MvcWebUi.Models;
using Bilge.Northwind.MvcWebUi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bilge.Northwind.MvcWebUi.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(ICartSessionService cartSessionService, ICartService carService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = carService;
            _productService = productService;
        }
        public ActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, productToBeAdded);
            _cartSessionService.SetCart(cart);

            TempData.Add("message", string.Format("Ürününüz , {0} , başarıyla sepete eklendi", productToBeAdded.ProductName));

            return RedirectToAction("Index", "Product");
        }

        public ActionResult List ()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }

        public ActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", string.Format("Ürününüz başarıyla silindi"));
            return RedirectToAction("List");
        }

        public ActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            }; 
            return View(shippingDetailsViewModel);
        }
        [HttpPost]
        public ActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", string.Format("Teşekkürler {0} ,Siparişiniz başarıyla alındı", shippingDetails.FirstName));
            return View();
        }



    }
}