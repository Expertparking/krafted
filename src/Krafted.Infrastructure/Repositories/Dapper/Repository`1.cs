﻿using System;
using System.Collections.Generic;
using SharedKernel.Domain;
using SharedKernel.Transactions;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity>
        where TEntity : Entity
    {
        protected Repository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<TEntity> GetAll() => throw new NotImplementedException();

        public IEnumerable<TEntity> GetAll(object whereConditions) => throw new NotImplementedException();

        public TEntity GetById(Guid id) => throw new NotImplementedException();

        public virtual void Create(TEntity entity) => throw new NotImplementedException();

        public virtual void Update(TEntity entity) => throw new NotImplementedException();

        public void Delete(TEntity entity) => throw new NotImplementedException();

        public void Delete(Guid id) => throw new NotImplementedException();
    }
}