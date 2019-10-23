using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballLeague.Data.Repositories.Interfaces;
using FootballLeague.Models;
using FootballLeague.Services.Interfaces;

namespace FootballLeague.Controllers
{
    [HandleError(ExceptionType = typeof(Exception))]
    public class MatchesController : Controller
    {
        private IMatchesRepository<Match> _matchesRepository;
        private IMatchesService _matchesService;

        public MatchesController(IMatchesRepository<Match> matchesRepository, IMatchesService matchesService)
        {
            this._matchesRepository = matchesRepository;
            this._matchesService = matchesService;
        }

        // GET: Matches
        public ActionResult Index()
        {
            var matches = this._matchesRepository.GetAll();
            if (matches == null)
            {
                return View();
            }
            return View(matches);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HomeTeamId,AwayTeamId,HomeGoals,AwayGoals,IsOver")] Match match)
        {
            if (ModelState.IsValid && match.AwayGoals > -1 && match.HomeGoals > -1)
            {
                this._matchesRepository.Insert(match);
                if (match.IsOver)
                {
                    this._matchesService.UpdatePoints(match);
                }
                return RedirectToAction("Index");
            }

            return View(match);
        }

        public ActionResult Edit(int id)
        {
            var match = this._matchesRepository.GetById(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HomeTeamId,AwayTeamId,HomeGoals,AwayGoals,IsOver")] Match match)
        {
            if (ModelState.IsValid && match.AwayGoals > -1 && match.HomeGoals > -1)
            {
                this._matchesRepository.Update(match);
                if (match.IsOver)
                {
                    this._matchesService.UpdatePoints(match);
                }
                return RedirectToAction("Index");
            }
            return View(match);
        }

        public ActionResult Delete(int id)
        {
            Match match = this._matchesRepository.GetById(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = this._matchesRepository.GetById(id);
            this._matchesRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetTeams()
        {
            var teams = this._matchesService.GetTeams();
            return Json(teams, JsonRequestBehavior.AllowGet);
        }
    }
}
