using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto1_web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            return View(Data.Memory.products); 
        }




        // GET: ProductController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {

                Data.Memory.products.Add(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: ProductController/Edit/5
        public ActionResult Edit(string id)
        {
            Product product = new Product();

            foreach (Product product1 in Data.Memory.products)
            {
                if (product1.Product_Id == id)
                {
                    product.Product_Id = product1.Product_Id;
                    product.Product_Descrition = product1.Product_Descrition;
                    product.Year_in = product1.Year_in;
                    product.Price = product1.Price;
                    product.Utility = product1.Utility;
                }

            }


            return View(product);
        }

        [Authorize(Roles = "Admin")]
        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Product product)
        {
            try
            {

                foreach (Product product1 in Data.Memory.products)
                {
                    if (product1.Product_Id == id)
                    {
                        product1.Product_Id = product.Product_Id;
                        product1.Product_Descrition = product.Product_Descrition;
                        product1.Year_in = product.Year_in;
                        product1.Price = product.Price;
                        product1.Utility = product.Utility;
                    }



                }






                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        // GET: ProductController/Delete/5
        public ActionResult Delete(string id)
        {
            Product product = new Product();

            foreach (Product product1 in Data.Memory.products)
            {
                if (product1.Product_Id == id)
                {
                    product.Product_Id = product1.Product_Id;
                    product.Product_Descrition = product1.Product_Descrition;
                    product.Year_in = product1.Year_in;
                    product.Price = product1.Price;
                    product.Utility = product1.Utility;
                }

            }



            return View(product);
        }
        [Authorize(Roles = "Admin")]
        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Product product)
        {
            try
            {
                Product prod = new Product();
                foreach (Product product1 in Data.Memory.products)
                {
                    if (product1.Product_Id == id)
                    {
                        Data.Memory.products.Remove(product1);
                        break;
                    }

                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
