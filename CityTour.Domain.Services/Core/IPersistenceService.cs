using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CityTour.Domain.Services
{
    public interface IPersistenceService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        
        void Save(TEntity entity);
    }
}