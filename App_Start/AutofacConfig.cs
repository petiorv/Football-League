using Autofac;
using Autofac.Integration.Mvc;
using FootballLeague.Data.Repositories;
using FootballLeague.Data.Repositories.Interfaces;
using FootballLeague.Models;
using FootballLeague.Models.Interfaces;
using FootballLeague.Services;
using FootballLeague.Services.Interfaces;
using System.Web.Mvc;

namespace FootballLeague.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<TeamsRepository>().As<ITeamsRepository<Team>>().InstancePerRequest();
            builder.RegisterType<MatchesRepository>().As<IMatchesRepository<Match>>().InstancePerRequest();

            builder.RegisterType<TeamsService>().As<ITeamsService>().InstancePerRequest();
            builder.RegisterType<MatchesService>().As<IMatchesService>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}