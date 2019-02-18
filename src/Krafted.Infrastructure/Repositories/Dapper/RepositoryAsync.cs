﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Krafted.Framework.SharedKernel.Domain;
using Krafted.Framework.SharedKernel.Transactions;

namespace Krafted.Infrastructure.Repositories.Dapper
{
    public class RepositoryAsync<TEntity> : Repository, IRepositoryAsync<TEntity>
        where TEntity : Entity
    {
        private readonly QueryBuilder<TEntity> _queryBuilder;

        public RepositoryAsync(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _queryBuilder = new QueryBuilder<TEntity>(Connection);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await Connection.QueryAsync<TEntity>(_queryBuilder.GetSelectCommand(), null, Transaction).ConfigureAwait(false);

        public async Task<IEnumerable<TEntity>> GetAllAsync(object whereConditions)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
            => await Connection.QueryFirstAsync<TEntity>(_queryBuilder.GetSelectByIdCommand(id), id, Transaction).ConfigureAwait(false);

        public async Task CreateAsync(TEntity entity, object param = null)
            => await Connection.ExecuteAsync(_queryBuilder.GetInsertCommand(), param ?? GetParams(entity), Transaction).ConfigureAwait(false);

        public async Task UpdateAsync(TEntity entity, object param = null)
            => await ExecuteAsync(_queryBuilder.GetUpdateCommand(), param ?? GetParams(entity)).ConfigureAwait(false);

        public async Task DeleteAsync(TEntity entity) =>
            await ExecuteAsync(_queryBuilder.GetDeleteCommand(), GetParam(entity)).ConfigureAwait(false);

        private async Task ExecuteAsync(string query, object param)
            => await Connection.ExecuteAsync(query, param, Transaction).ConfigureAwait(false);

        private static object GetParams(TEntity entity) => entity.ToParams(typeof(TEntity).Name);

        private static object GetParam(TEntity entity) => entity.ToParam(typeof(TEntity).Name);
    }
}