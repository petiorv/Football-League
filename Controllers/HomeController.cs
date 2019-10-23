using FootballLeague.Models;
using FootballLeague.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class HomeController : Controller
    {        
        private IMatchesService _matchesService;

              
        public HomeController(IMatchesService matchesService)
        {
            this._matchesService = matchesService;
        }
        public ActionResult Index()
        {
            var teams = this._matchesService.GetTeams().OrderByDescending(t => t.Points);

            RankingAndMatches rankingAndMatches = new RankingAndMatches();

            rankingAndMatches.TeamsRanking = teams.ToList();
            
            return View(rankingAndMatches);
        }

        [HttpPost]
        public JsonResult GetTeamMatches(int id)
        {
            return Json(this._matchesService.GetCurrentTeamMatches(id), JsonRequestBehavior.AllowGet);
        }
    }
}