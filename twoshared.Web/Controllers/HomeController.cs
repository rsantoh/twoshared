using Newtonsoft.Json;
using twoshared.Core.Interfaces;
using twoshared.Core.Models;
using twoshared.Infraestructure.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace twoshared.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository _home;

        public static async Task SimulatesApiCall()
        {
            var json = JsonConvert.SerializeObject(
                   new
                   {
                       name1 = "value1",
                       name2 = "value2",
                       name3 = "value3"                      
                   });
            //Ser
            await Task.Delay(2 * 1000);
        }
        public HomeController()
        {
            this._home = new HomeRepository();
        }
        public ActionResult Index()
        {
            List<Products> products = LoadProductList();
            ViewBag.IdCustomer = 1; //session variable
            return View(products);
        }

        public dynamic LoadProductList()
        {
            List<Products> products;
            try
            {
                products = _home.Get_Products();
            }
            catch
            {
                products = new List<Products>();
            }
            return products;
        }

        [HttpPost]
        public ActionResult Insert_Prouct_cart(int idProduct)
        {
            string message = string.Empty;
            string resp = string.Empty;
            // get client id from session variables

            int idCustomer = 1;
            string result = _home.Insert_Shopping_Item_Post(idProduct, idCustomer);
            if (result == "1")
            {
                resp = "1";
                message = "Stored data";
                
            }
            else
            {
                resp = "0";
                message = "Error";
            }
            return Json(new { message = message, resp = resp }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult myShoppingCart()
        {
            List<ItemsCart> products = LoadProduct_CustomerCartList();
            return View(products);
        }    

        public dynamic LoadProduct_CustomerCartList()
        {
            // get client id from session variables
            int IdCustomer = 1;
            List<ItemsCart> products;
            try
            {
                products = _home.Get_Products_Customer(IdCustomer);
            }
            catch
            {
                products = new List<ItemsCart>();
            }
            return products;
        }
       
        public ActionResult Delete_Item_MyCart(int id)
        {
            string message = string.Empty;
            string resp = string.Empty;
            string result = _home.Shopping_Item_Delete(id);
            if (result == "1")
            {
                resp = "1";
                message = "Stored data";
            }
            else
            {
                resp = "0";
                message = "Error";
            }
            return Json(new { message = message, resp = resp }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert_Tag(int idItem, string name)
        {
            string message = string.Empty;
            string resp = string.Empty;
            string result = _home.Shopping_Item_tag_insert(idItem, name);
            if (result == "1")
            {
                resp = "200";
                message = "Stored data";
            }
            else
            {
                resp = "500";
                message = "Error";
            }
            return Json(new { message = message, resp = resp }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult _Tags(int id)
        {
            // get tags from id product, show partial view for tags
            ViewBag.idItem = id;
            List<Tags> tags = Load_Items_Tags(id);
            return PartialView(tags);
        }
        public dynamic Load_Items_Tags(int item)
        {
            // get client id from session variables
            int IdCustomer = 1;
            List<Tags> tags;
            try
            {
                tags = _home.Get_Tags_Item(item);
            }
            catch
            {
                tags = new List<Tags>();
            }
            return tags;
        }
        public ActionResult Delete_tag(int idTag)
        {
            string message = string.Empty;
            string resp = string.Empty;
            string result = _home.Shopping_Item_tag_delete(idTag);
            if (result == "1")
            {
                resp = "200";
                message = "Stored data";
            }
            else
            {
                resp = "500";
                message = "Error";
            }
            return Json(new { message = message, resp = resp }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}