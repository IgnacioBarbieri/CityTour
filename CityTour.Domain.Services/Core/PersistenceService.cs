using CityTour.Persistence.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CityTour.Domain.Services
{
    public abstract class PersistenceService<TEntity> : IPersistenceService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IRepository<TEntity> repository;

        public PersistenceService(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return repository.Query();
        }

        public void Save(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            repository.Add(entity);
            unitOfWork.Commit();
        }

    }

}


