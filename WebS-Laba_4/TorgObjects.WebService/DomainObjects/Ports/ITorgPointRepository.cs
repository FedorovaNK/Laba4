using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TorgObjects.DomainObjects.Ports
{
    public interface IReadOnlyTorgPointRepository
    {
        Task<TorgPoint> GetTorgPoint(long id);

        Task<IEnumerable<TorgPoint>> GetAllTorgPoints();

        Task<IEnumerable<TorgPoint>> QueryTorgPoints(ICriteria<TorgPoint> criteria);

    }

    public interface ITorgPointRepository
    {
        Task AddTorgPoint(TorgPoint Torgpoint);

        Task RemoveTorgPoint(TorgPoint Torgpoint);

        Task UpdateTorgPoint(TorgPoint Torgpoint);
    }
}
