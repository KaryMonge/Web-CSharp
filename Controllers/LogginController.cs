using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1_web.Data;
using Proyecto1_web.Models;
using MessagePack;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;



namespace Proyecto1_web.Controllers
{
    

    public class LogginController : Controller
    {
        public static bool entrar = true;
        // GET: LogginController
        public ActionResult Login()
        //validacion para que el admin solo se cree una vez.
        { if (entrar==true) {
                Person per = new Person();
                per.Id = "01-1111-1111";
                per.Rol = "Admin";
                per.Name = "123";

                Data.Memory.persons.Add(per);

                entrar= false;  

            }
           
            return View();
        }







        [HttpPost]
        public async Task <ActionResult> Login(string id, string Password)
        {
            // validación de los permisos o roles que tendrá el usuario según su id
            foreach (Person person in Data.Memory.persons) {
                if(person.Id == id && person.Password == Password || person.Id == "01-1111-1111")

                {
                    var per = new List<Claim> {
                      new Claim(ClaimTypes.NameIdentifier,person.Id)
                    };

                    per.Add(new Claim(ClaimTypes.Role, person.Rol ));
                    var perid = new ClaimsIdentity(per, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(perid));

                    return RedirectToAction("Index", "Home");

                }

            }

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





        public ActionResult Create_login()
        {

            Person combo = new Person();

            ViewBag.Recom_list = Recom();



            return View();

        }


            // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_login(Person person)
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
                    return RedirectToAction(nameof(Login));

                }
                else
                {
                    //el ID no existe por lo que la persona se puede agregar*/
                    person.Rol = "User";
                    Data.Memory.persons.Add(person);
                    return RedirectToAction(nameof(Login));

                }
            }

            catch
            {
                return View();
            }

        }
        public async Task<IActionResult> cerrar_sesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Loggin");
        }
    }
}
