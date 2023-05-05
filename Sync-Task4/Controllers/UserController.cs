using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sync_Task3.Models.Repository;
using Sync_Task4.Models;
using Sync_Task4.Models.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sync_Task4.Controllers
{
    public class UserController : Controller
    {
        private readonly ITaskRepo<User> userRepo;
        private readonly ITaskRepo<Train> trainRepo;
        private readonly ITaskRepo<Ticket> ticketRepo;
        public static int currentid;
        TicketTrainViewModel viewModel = new TicketTrainViewModel();
        public UserController(ITaskRepo<User> userRepo , ITaskRepo<Train> trainRepo , ITaskRepo<Ticket> ticketRepo)
        {
            this.userRepo = userRepo;
            this.trainRepo = trainRepo;
            this.ticketRepo = ticketRepo;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User guestuser)
        {
             
            //check if the id is wrong
             if (!(userRepo.list().Contains(userRepo.find(guestuser.Id))))
            {
                ViewBag.wrongid = "there is no user id like that";
                return View();
            }
            //check if the password is correct 
            else if (guestuser.password == userRepo.find(guestuser.Id).password)
            {
                var trueuser = userRepo.find(guestuser.Id);
                currentid = guestuser.Id;
                return RedirectToAction("Index", trueuser);
            }
            else
            {
                ViewBag.wrongpass = "please check the correct password and try again";
                return View();
            }
        }
        public ActionResult Index(User user)
        {
            user = userRepo.find(currentid);
            return View(user);
        }

        public ActionResult ViewTickets(int id)
        {
            var user = userRepo.find(id);
            return View(user.Tickets.ToList());
        }

        public ActionResult List()
        {
            return View(userRepo.list());
        }
        
        public ActionResult Addticket(TicketTrainViewModel model)
        {
            var ticket = new Ticket()
            {
                Payment = model.Payment,
                Train = trainRepo.find(model.TrainId),
                Price = trainRepo.find(model.TrainId).Price
            };
            ticketRepo.add(ticket);
            var user = userRepo.find(currentid);
            user.Tickets.Add(ticket);
            return View("ViewTickets",user.Tickets);
        }
    }
}
