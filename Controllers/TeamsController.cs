using System;
using System.Web.Mvc;
using FootballLeague.Data.Repositories.Interfaces;
using FootballLeague.Models;
using FootballLeague.Models.Interfaces;

namespace FootballLeague.Controllers
{
    [HandleError(ExceptionType = typeof(Exception))]
    public class TeamsController : Controller
    {
        private readonly ITeamsRepository<Team> _teamsrepository;

        public TeamsController(ITeamsRepository<Team> teamsrepository)
        {
            _teamsrepository = teamsrepository;
        }

        public ActionResult Index()
        {

            return View(_teamsrepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Points")] Team team)
        {
            if (ModelState.IsValid && team.Points > -1)
            {
                team.CreatedTime = DateTime.Now;
                this._teamsrepository.Insert(team);
                return RedirectToAction("Index");
            }

            return View(team);
        }

        public ActionResult Edit(int id)
        {
            var team = this._teamsrepository.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Points")] Team team)
        {
            if (ModelState.IsValid && team.Points > -1)
            {
                this._teamsrepository.Update(team);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var team = this._teamsrepository.GetById(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this._teamsrepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
