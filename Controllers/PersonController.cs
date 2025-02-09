using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_web.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Proyecto1_web.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        // GET: PersonController
        public ActionResult Index()
        {
            return View(Data.Memory.persons);
        }






        // GET: PersonController/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }





        public List<Person> Recom()
        {
            List<Person> recom = new List<Person>();


            recom.Add(new Person() { Combo_Recom = "Recomendado por un amigo(a)" });
            recom.Add(new Person() { Combo_Recom = "Por redes sociales" });
            recom.Add(new Person() { Combo_Recom = "Ya la conocía" });

            return recom;

        }



        // GET: PersonController/Create
        public ActionResult Create()
        {
            Person combo = new Person();

            ViewBag.Recom_list = Recom();



            return View(combo);
        }





        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {

                // Antes de insertar se verifica si el id de la persona existe
                // Si ya existe no permite insertarse

                string id_list;
                bool searched = false;

                for (int i = 0; i < Data.Memory.persons.Count; i++)
                {
                    id_list = Data.Memory.persons[i].Id;

                    if (person.Id.Equals(id_list))
                    {
                        searched = true;
                        break;
                    }
                }

                if (searched)
                {
                    //el ID existe por lo que la persona no se puede agregar
                    //enviar mensaje de error
                    ViewBag.Message = "ID Usuario ya existe";
                    //Thread.Sleep(2000);
                    //return View();
                    return RedirectToAction(nameof(Create));


                }
                else
                {
                    //el ID no existe por lo que la persona se puede agregar*/
                    Data.Memory.persons.Add(person);
                    return RedirectToAction(nameof(Index));

                }

                
            }
            catch
            {
                return View();
            }
        }





        // GET: PersonController/Edit/5
        public ActionResult Edit(string id)
        {
            Person combo = new Person();

            ViewBag.Recom_list = Recom();


           Person person = new Person();
            foreach (Person person1 in Data.Memory.persons)
            {
                if (person1.Id == id)
                {
                    person.Id = person1.Id;
                    person.Year_Age = person1.Year_Age;
                    person.Phone = person1.Phone;
                    person.email = person1.email;
                    person.Password = person1.Password;
                    person.Profession = person1.Profession;
                    person.Combo_Recom = person1.Combo_Recom;
                }



            }


            return View(person);
        }






        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Person person)
        {
            try
            {
                foreach (Person person1 in Data.Memory.persons)
                {
                    if (person1.Id == id)
                    {
                        person1.Id = person.Id;
                        person1.Year_Age = person.Year_Age;
                        person1.Phone = person.Phone;
                        person1.email = person.email;
                        person1.Password = person.Password;
                        person1.Profession = person.Profession;
                        person1.Combo_Recom = person.Combo_Recom;
                    }



                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(string id)
        {
            Person person = new Person();
            foreach (Person person1 in Data.Memory.persons)
            {
                if (person1.Id == id)
                {
                    person.Id = person1.Id;
                    person.Year_Age = person1.Year_Age;
                    person.Phone = person1.Phone;
                    person.email = person1.email;
                    person.Password = person1.Password;
                    person.Profession = person1.Profession;
                    person.Combo_Recom = person1.Combo_Recom;
                }



            }

            return View(person);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Person pers)
        {
            try
            {
                Person person = new Person();
                foreach (Person person1 in Data.Memory.persons)
                {
                    if (person1.Id == id)
                    {
                        Data.Memory.persons.Remove(person1);
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
