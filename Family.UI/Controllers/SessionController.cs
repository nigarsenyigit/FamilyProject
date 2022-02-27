using Family.DAL;
using Family.DAL.Entities;
using Family.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Family.UI.Controllers
{
    public class SessionController : Controller
    {
        FamilyContext db = new FamilyContext();
        // GET: Session
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Person person, string rePassword)
        {
            // GSozdemir To Do: Aynı kullanıcı adı ile kayıt kontrolü yapılsın.
            if (person.Password == rePassword)
            {
                Person newPerson = new Person()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    UserName = person.UserName,
                    Password = person.Password,
                    BirthOfDay = person.BirthOfDay,
                    IsLife = true,
                    Gender = person.Gender,
                    CreatedOn = DateTime.Now
                };
                db.People.Add(newPerson);
                db.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Person person)
        {
            Person currentPerson = db.People.Where(x => x.UserName == person.UserName && x.Password == person.Password).SingleOrDefault();
            if (currentPerson != null)
            {
                Session["CurrentUser"] = currentPerson;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}