using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1_web.Models;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Authorization;

namespace Proyecto1_web.Controllers
{
   
    public class TourController : Controller
    {
        // GET: TourController
        public ActionResult Index()
        {
            return View(Data.Memory.tours);
        }

        // GET: TourController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }



        public string generar_id()
        {
            Random tour_id_random = new Random();
            string tour_id_s = Convert.ToString(tour_id_random.Next(1, 999999999));
            return tour_id_s;
        }






        public List<Tour> Day_list( )
        {
            List<Tour> days = new List<Tour>();
            

            days.Add(new Tour() {Week_list= "Lunes a Viernes" });
            days.Add(new Tour() { Week_list = "Sábado y domingo" });
            days.Add(new Tour() { Week_list = "Solo Sábado" });
            days.Add(new Tour() { Week_list = "Solo Domingo" });


            return days;

        }

        [Authorize(Roles = "Admin")]
        // GET: TourController/Create
        public ActionResult Create()
        {
            Tour tour = new Tour();

            ViewBag.Week_list = Day_list();
            tour.Tour_Id = generar_id();

            return View(tour);
        }



        // POST: TourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tour tour)
        {
            try
            {

                
                Data.Memory.tours.Add(tour);
              

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }






        [Authorize(Roles = "Admin")]

        // GET: TourController/Edit/5
        public ActionResult Edit(string id)
        {
        
    
            Tour tour = new Tour();
            ViewBag.Week_list = Day_list();

            foreach (Tour tour1 in Data.Memory.tours)
            {
                if (tour1.Tour_Id == id)
                {
                    tour.Tour_Id = tour1.Tour_Id;
                    tour.Tour_Description = tour1.Tour_Description;
                    tour.Tour_Image = tour1.Tour_Image;
                    tour.Week_list = tour1.Week_list;

                }

            }


            return View(tour);
        }

        [Authorize(Roles = "Admin")]

        // POST: TourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Tour tour)
        {
            try
            {
                foreach (Tour tour1 in Data.Memory.tours)
                {
                    if (tour1.Tour_Id == id)
                    {
                        tour1.Tour_Id = tour.Tour_Id;
                        tour1.Tour_Description = tour.Tour_Description;
                        tour1.Tour_Image = tour.Tour_Image;
                        tour1.Week_list = tour.Week_list;

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

        // GET: TourController/Delete/5
        public ActionResult Delete(string id)
        {
            Tour tour = new Tour();

            foreach (Tour tour1 in Data.Memory.tours)
            {
                if (tour1.Tour_Id == id)
                {
                    tour.Tour_Id = tour1.Tour_Id;
                    tour.Tour_Description = tour1.Tour_Description;
                    tour.Tour_Image = tour1.Tour_Image;
                    tour.Week_list = tour1.Week_list;

                }

            }

            return View(tour);
        }




        // POST: TourController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Tour tour)
        {
            try
            {

                Tour totu = new Tour();
                foreach (Tour tour1 in Data.Memory.tours)
                {
                    if (tour1.Tour_Id == id)
                    {
                        Data.Memory.tours.Remove(tour);
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
