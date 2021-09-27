using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsluzniObrt.Model;
using UsluzniObrt.MVC.ViewModels;
using UsluzniObrt.Service;
using UsluzniObrt.Repository;
using UsluzniObrt.Service.DTO;
using UsluzniObrt.Service.Menu.DTO;

namespace UsluzniObrt.MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        public AdminController()
        {
        }
        public AdminController(IMenuService menuService, ICategoryService categoryService, IOrderService orderService)
        {
            _menuService = menuService ;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult Index()
        {
             List<Order> OrderList = new List<Order>();
            OrderList = _orderService.GetAll();
            return View(new OrdersViewModel {
                OrderList = OrderList
                
            });

        }
        [HttpGet]
        public ActionResult Menu()
        {
            PopulateDropdownList();
            var model = new ItemsViewModel();
            model.Items = _menuService.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateItem()
        {
            PopulateDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateItem(ItemCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdownList();
                return View(model);
            }
            _menuService.Add(new CreateMenuItem
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Status = model.Status

            });

            return RedirectToAction("Menu", "Admin");

        }

        [HttpGet]
        public ActionResult CreateCategory()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _categoryService.Add(new Category
            {
                Name = model.Name
            });
            return RedirectToAction("Menu", "Admin");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditViewBag(id);
            PopulateDropdownList();
            return View();
        }


        [HttpPost]
        public ActionResult Edit(ItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdownList();
                return View();
            }

            _menuService.edit(new EditMenuItem {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId,
                Description = model.Description,
                Status = model.Status

            });
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult EditOrder(OrdersViewModel model)
        {

            _orderService.edit(new ModifyOrder {
                OrderId = model.Order.Id,
                status = model.Order.Status
            });
            return RedirectToAction("Index");

        }

        private void PopulateDropdownList()
        {
            ViewBag.CategoryList = _categoryService.GetAll().ToList();
        }
        private void EditViewBag(int id)
        {
            ViewBag.EditItem = _menuService.GetById(id);
        }

        [HttpGet]
        public ActionResult DeleteItem (int id)
        {

            _menuService.Delete(id);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {

            _categoryService.Delete(id);
            return RedirectToAction("Index");

        }

    }
}