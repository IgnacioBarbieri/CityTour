using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CityTour.Persistence.Core
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
        TEntity QueryById(object id);
        void Update(TEntity entityToUpdate);
    }
}