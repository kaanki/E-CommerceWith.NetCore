using Bilge.Northwind.MvcWebUi.Models;
using Bilge.Northwind.MvcWebUi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilge.Northwind.MvcWebUi.ViewComponents
{
    public class CartSummaryViewComponent:ViewComponent
    {
        ICartSessionService _cartSessionService;

        public CartSummaryViewComponent(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);

        }
    }
}
