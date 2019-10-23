using System.Linq;

namespace FootballLeague.Data.Repositories.Interfaces
{
    public interface ITeamsRepository<T>
    {
        void Insert(T entity);

        void Delete(int id);

        void Update(T id);

        IQueryable<T> GetAll();

        T GetById(int id);
    }
}
