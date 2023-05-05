using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sync_Task3.Models.Repository;
using Sync_Task4.Models;
using Sync_Task4.Models.Repository;

namespace Sync_Task4.Controllers
{
    public class TrainController : Controller
    {
        private readonly ITaskRepo<Train> trainRepo;
        private readonly ITaskRepo<Ticket> ticketrepo;
        TicketTrainViewModel viewModel = new TicketTrainViewModel();

        public TrainController(ITaskRepo<Train> trainRepo , ITaskRepo<Ticket> ticketrepo)
        {
            this.trainRepo = trainRepo;
            this.ticketrepo = ticketrepo;
        }
        // GET: TrainController
        public ActionResult Index()
        {
            return View(trainRepo.list());
        }

        public ActionResult List()
        {
            return View(trainRepo.list());
        }
        public ActionResult Book(int id)
        {
            viewModel.TrainId = id;
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(TicketTrainViewModel model)
        {   if(ModelState.IsValid)
            {
                return RedirectToAction("Addticket", "User", model);
            }
            ModelState.AddModelError("", "you must enter the vaild number");
            return View();
        }
    }
}
