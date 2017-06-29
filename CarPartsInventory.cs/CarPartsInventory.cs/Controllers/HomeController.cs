using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPartsInventory.cs.Models;
using CarPartsInventory.cs.ViewModels;

namespace CarPartsInventory.cs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }

        public ActionResult AddToOrder(IndexViewModel input)
        {
            input.CurrentOrder.OrderItemsList.Add(new OrderItem
            {
                ItemName = ((Enums.Parts)input.SelectedPart).ToString()
            });
            return View(input);
        }

        public ActionResult EnterOrder(IndexViewModel input,string addItem,string goToCart)
        {
            if (!String.IsNullOrEmpty(addItem))
                
                //AddToOrder(input);
            if (!string.IsNullOrEmpty(goToCart))
                Cart(input.CurrentOrder);

        }

        public ActionResult Cart(Order input)
        {
            return View(input);
        }
    }
}