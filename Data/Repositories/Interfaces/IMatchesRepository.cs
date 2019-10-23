using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Repositories.Interfaces
{
    public interface IMatchesRepository<T>
    {
        void Insert(T entity);

        void Delete(int id);

        void Update(T id);

        IQueryable<T> GetAll();

        T GetById(int id);

        IQueryable<T> GetTeamMatches (int id);
    }
}
