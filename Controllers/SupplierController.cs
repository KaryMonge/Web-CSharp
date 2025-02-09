using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto1_web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SupplierController : Controller
    {
        // GET: SupplierController
        public ActionResult Index()
        {
            return View(Data.Memory.suppliers);
        }




        // GET: SupplierController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }




        [Authorize(Roles = "Admin")]

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }






        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                Data.Memory.suppliers.Add(supplier);



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }





        [Authorize(Roles = "Admin")]

        // GET: SupplierController/Edit/5
        public ActionResult Edit(string id)
        {
            Supplier supplier = new Supplier();

            foreach (Supplier supplier1 in Data.Memory.suppliers)
            {
                if (supplier1.Legal_Doc == id)
                {
                    supplier.Legal_Doc = supplier1.Legal_Doc;
                    supplier.Supplier_Description = supplier1.Supplier_Description;

                }

            }


            return View(supplier);
        }





        [Authorize(Roles = "Admin")]

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Supplier supplier)
        {
            try
            {

                foreach (Supplier supplier1 in Data.Memory.suppliers)
                {
                    if (supplier1.Legal_Doc == id)
                    {
                        supplier1.Legal_Doc = supplier.Legal_Doc;
                        supplier1.Supplier_Description = supplier.Supplier_Description;

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
        // GET: SupplierController/Delete/5
        public ActionResult Delete(string id)
        {

            Supplier supplier = new Supplier();
            foreach (Supplier supplier1 in Data.Memory.suppliers)
            {
                if (supplier1.Legal_Doc == id)
                {
                    supplier.Legal_Doc = supplier1.Legal_Doc;
                    supplier.Supplier_Description = supplier1.Supplier_Description;
                }
            }



            return View(supplier);
        }


        [Authorize(Roles = "Admin")]

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Supplier supplier)
        {
            try
            {
                Supplier supp = new Supplier();
                foreach (Supplier supplier1 in Data.Memory.suppliers)
                {
                    if (supplier.Legal_Doc == id)
                    {
                        Data.Memory.suppliers.Remove(supplier1);
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
