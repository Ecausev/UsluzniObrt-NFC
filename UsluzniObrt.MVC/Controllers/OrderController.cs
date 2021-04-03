using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsluzniObrt.Repository;
using UsluzniObrt.Model;
using UsluzniObrt.MVC.ViewModels;
using UsluzniObrt.Service;
using UsluzniObrt.Service.DTO;

namespace UsluzniObrt.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        // GET: Item
        public OrderController()
        {

        }
        public OrderController(
            IMenuService itemService, 
            ICategoryService categoryService, 
            IOrderService orderService )
        {
            _menuService = itemService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        
        [HttpGet]
        public ActionResult Menu(int id)
        {
            if (id != 0)
            {
                PopulateDropdownList();
                var model = new ItemsViewModel();
                model.Items = _menuService.GetAll();
                GetCart().Table = id;
                GetTableId();
                return View(model);
            }
            return null;
        }
        

        public ActionResult Cart(int id)
        {
            GetTableId();
            var Table = Convert.ToInt32(GetCart().Table);
            if (_orderService.CanPlaceOrder(Table))
            {
                var item = _menuService.GetById(id);
                GetCart().AddItem(item, 1);
                return RedirectToAction("Checkout", "Order");
            }
            else
            {
                return RedirectToAction("MyOrder", "Order", new { id = Table });
            }
        }

        public ActionResult RemoveFromCart(int id)
        {
            GetTableId();
            var item = _menuService.GetById(id);
            GetCart().RemoveItem(item);
            return RedirectToAction("Checkout");
        }
        public ActionResult RemoveOneFromCart(int id)
        {
            GetTableId();
            var item = _menuService.GetById(id);
            GetCart().RemoveOne(item, 1);
            return RedirectToAction("Checkout");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            GetTableId();
            var ItemList = _menuService.GetAll().ToList();
            return View(new CartViewModel {
                Cart = GetCart(),
                MenuItemList = ItemList,
            });
        }

        public ActionResult CreateOrder(CartViewModel model)
        {
            GetTableId();
            Cart cart = (Cart)Session["CartSession"];
            Order MyOrder = new Order();

            int table = cart.Table;
            var orderItems = new List<OrderItem>();
            foreach (var item in cart.OrderList)
            {

                orderItems.Add(new OrderItem
                {
                    MenuItemId = item.MenuItemId,
                    Quantity = item.Quantity
                });
            }


            var order = new Order
            {
                Date = DateTime.Now,
                TableNumber = table,
                Status = OrderStatus.Pending,
                Items = orderItems
            };

            _orderService.Add(order);
            Session.Remove("CartSession");
            return RedirectToAction("MyOrder","Order", new {id = table });
        }
        /// <summary>
        /// Stranica za pregled narudzbe lkvnmsklgskjgnvvn 
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MyOrder (int id)
        {
            ViewBag.Table = id;
            Order myOrder = new Order();
            myOrder = _orderService.GetAll().Where(x => x.TableNumber == id).LastOrDefault();
            if (myOrder != null)
            {
                return View(new OrdersViewModel
                {

                    Order = myOrder,
                    itemOrderList = myOrder.Items.ToList()

                });
            }

            else
            {
                return View(new OrdersViewModel { });
            }
            

        }

        private void GetTableId()
        {
            ViewBag.Table = GetCart().Table;
        }

        private void PopulateDropdownList()
        {
            ViewBag.CategoryList = _categoryService.GetAll().ToList();

        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["CartSession"];
            if (cart == null)
            {
                cart = new Cart();
                Session["CartSession"] = cart;
            }
            return cart;
        }

        
    }
}
