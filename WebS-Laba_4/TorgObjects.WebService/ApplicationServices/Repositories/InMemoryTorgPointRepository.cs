using TorgObjects.DomainObjects;
using TorgObjects.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TorgObjects.ApplicationServices.Repositories
{
    public class InMemoryTorgPointRepository : IReadOnlyTorgPointRepository,
                                           ITorgPointRepository 
    {
        private readonly List<TorgPoint> _Torgpoints = new List<TorgPoint>();

        public InMemoryTorgPointRepository(IEnumerable<TorgPoint> Torgpoints = null)
        {
            if (Torgpoints != null)
            {
                _Torgpoints.AddRange(Torgpoints);
            }
        }

        public Task AddTorgPoint(TorgPoint Torgpoint)
        {
            _Torgpoints.Add(Torgpoint);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TorgPoint>> GetAllTorgPoints()
        {
            return Task.FromResult(_Torgpoints.AsEnumerable());
        }

        public Task<TorgPoint> GetTorgPoint(long id)
        {
            return Task.FromResult(_Torgpoints.Where(mp => mp.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<TorgPoint>> QueryTorgPoints(ICriteria<TorgPoint> criteria)
        {
            return Task.FromResult(_Torgpoints.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveTorgPoint(TorgPoint Torgpoint)
        {
            _Torgpoints.Remove(Torgpoint);
            return Task.CompletedTask;
        }

        public Task UpdateTorgPoint(TorgPoint Torgpoint)
        {
            var foundTorgPoint = GetTorgPoint(Torgpoint.Id).Result;
            if (foundTorgPoint == null)
            {
                AddTorgPoint(Torgpoint);
            }
            else
            {
                if (foundTorgPoint != Torgpoint)
                {
                    _Torgpoints.Remove(foundTorgPoint);
                    _Torgpoints.Add(Torgpoint);
                }
            }
            return Task.CompletedTask;
        }
    }
}
