using Family.DAL;
using Family.DAL.Entities;
using Family.DAL.Enums;
using Family.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Family.UI.Controllers
{
    [SessionFilter]
    public class RelationController : Controller
    {
        FamilyContext db = new FamilyContext();
        // GET: Relation
        public ActionResult MyRequest()
        {
            Person currentUser = Session["CurrentUser"] as Person;
            List<Request> requests = db.Requests.Where(x => x.ReceiverId == currentUser.Id).ToList();
            return View(requests);
        }

        public ActionResult ReturnResponse(int senderId, RelationEnum relation, ResponseEnum response)
        {
            Person currentUser = Session["CurrentUser"] as Person;
            Request currentRequest = db.Requests.Where(x => x.SenderId == senderId && x.ReceiverId == currentUser.Id && x.Relation == relation).SingleOrDefault();


            switch (relation)
            {
                case RelationEnum.Mother:
                    break;
                case RelationEnum.Fother:
                    break;
                case RelationEnum.Husband:
                    if (response == ResponseEnum.Accept)
                    {
                        Parent newParent = new Parent()
                        {
                            FatherId = currentUser.Id,
                            MotherId = senderId,
                            IsMaried = true,
                            MarriedDate = DateTime.Now,
                            CreatedOn = DateTime.Now
                        };
                        db.Parents.Add(newParent);
                    }
                    break;
                case RelationEnum.Wife:
                    if (response == ResponseEnum.Accept)
                    {
                        Parent newParent = new Parent()
                        {
                            FatherId = senderId,
                            MotherId = currentUser.Id,
                            IsMaried = true,
                            MarriedDate = DateTime.Now,
                            CreatedOn = DateTime.Now
                        };
                        db.Parents.Add(newParent);
                    }
                    break;
                case RelationEnum.Sister:
                    break;
                case RelationEnum.Brother:
                    break;
                default:
                    break;
            }

            currentRequest.Response = response;
            db.SaveChanges();
            return RedirectToAction("MyRequest");
        }

        public ActionResult SendRequest()
        {
            List<Person> people = db.People.ToList();
            return View(people);
        }

        [HttpPost]
        public ActionResult SendRequest(int receiverId, RelationEnum relation)
        {
            Person currentUser = Session["CurrentUser"] as Person;
            Request newReqest = new Request()
            {
                ReceiverId = receiverId,
                SenderId = currentUser.Id,
                CreatedOn = DateTime.Now,
                Relation = relation,
                RequestDate = DateTime.Now,
                Response = ResponseEnum.Waiting
            };
            db.Requests.Add(newReqest);
            db.SaveChanges();
            return RedirectToAction("SendRequest");
        }
    }
}