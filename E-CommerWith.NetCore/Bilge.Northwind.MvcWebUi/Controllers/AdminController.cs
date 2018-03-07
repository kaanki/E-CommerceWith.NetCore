﻿using Bilge.Northwind.Business.Abstract;
using Bilge.Northwind.Entities.Concrete;
using Bilge.Northwind.MvcWebUi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bilge.Northwind.MvcWebUi.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController:Controller
    {
        
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }
        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Ürün Başarıyla Eklendi");
            }
            
            return RedirectToAction("Add");
        }
        public ActionResult Update(int productId)
        {
            var model =new ProductUpdateViewModel
                {
                Product = _productService.GetById(productId),
                Categories=_categoryService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Ürün Başarıyla Güncellendi");
            }

            return RedirectToAction("Update");
        }
        public ActionResult Delete(int productId)
        {
            _productService.delete(productId);
            TempData.Add("message", "Ürün başarıyla Silindi");
            return RedirectToAction("Index");

        }
    }

    
}
