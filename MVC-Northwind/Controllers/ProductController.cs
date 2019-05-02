using MVC_Northwind.Classes;
using MVC_Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Northwind.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities ctx = new NorthwindEntities();
        //Model yöntemi ile çoklu veri listesi yollama,,class oluşturduk
        ViewModel prdcat = new ViewModel(); //yeni instance oluşturduk


        // GET: Product //actionla aynı simde olan view ı bulup açar default olarak hepsi get
        // GET  Action bir view ı çalıştırmayı sağlar.Deer alablir ve aldığı değeri view e gönderir

        //POST Action:View tarafından girilen değerleri alır ve sql e gönderir
        //tanımlandığı formun içindeki very alır db e gönderir
        //Bi action get yada post olarak belirtilmezse varsayılanı Get action dır
        public ActionResult Index()
        {
            List<Category> catList = ctx.Categories.ToList(); //2 tane liste yollayamadığımız için ViewBag yöntemini kullanırız.
            List<Product> prdList = ctx.Products.ToList();
            //  ViewBag.categoryList = catList; //categoryList dinamik tip oluşturuyoruz.Dinamik tip için herhangi bir isim(alan) yazılabilir ve bu alana atama yapılabilir. Bu yönteme viewbag yöntemiyle veri gönderme denir.
            List<Supplier> spList = ctx.Suppliers.ToList();
            prdcat.catList = catList;
            prdcat.prodList = prdList;
            prdcat.supList = spList;
            return View(prdcat);

            //View metodunun arasına bir değişken vermek o değişkeni MODEL yöntemi ile view'e göndermek demektir
            //MODEL yöntemi view'e veri gönderme yöntemlerinden birisidir.
            //View'e veri göndermek için 2 yöntem vardır. Yöntemlerden biri ViewBag yöntemidir, diğeri Model yöntemidir. Model yöntem en sık kullanılan yöntemdir.
            //  return View(prdList); //aldığımız listeyi viewe vermek zorundayız
        }
        public ActionResult AddProduct() //get action ı
        {
            List<Category> cat = ctx.Categories.ToList();
            List<Supplier> sup = ctx.Suppliers.ToList();

            ViewBag.catList = cat;
            ViewBag.supList = sup;
            return View();
        }
        //View tarafından girilen verileri çekmeyi sağlayacak action dır.
        // [HttpPost] //altındaki action ın post action ı olduğunu söyler
        //public ActionResult AddProduct(string prdName, decimal prdPrice, short prdStock, int prdCatID, int prdSupID) //post action ı aynı isimde
        //{
        //    Product prd = new Product();
        //    prd.ProductName = prdName;
        //    prd.UnitPrice = prdPrice;
        //    prd.UnitsInStock = prdStock;
        //    prd.CategoryID = prdCatID;
        //    prd.SupplierID = prdSupID;

        //    ctx.Products.Add(prd);  //yeni eklenen ürünü contexte(db) ekliyoruz
        //    ctx.SaveChanges();
        //    //Aşağıdaki return View("Index") satırı aynı controllerdaki Index action'ın çalıştırdığı Index sayfasını açar ama Index action'ını çalıştırmaz. Bunun yerine return RedirectToAction
        //    //return View("Index"); //aynı controllerda aynı isimli view e yönlendirir,ama action ı çalıştırmaz.

        //    //aynı controller'daki Index action'ına gider ve  action'ı çalıştırır.Eğer farklı bir controlerdaki Index action'ını çalıştırmak istersek return RedirectToAction("Index","ControllerName"); yazmalıyız.
        //    return RedirectToAction("Index");
        //}
        
        /*2.yol*/
        [HttpPost]
        public ActionResult AddProduct(Product prd)
        {
            ctx.Products.Add(prd);
            ctx.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}