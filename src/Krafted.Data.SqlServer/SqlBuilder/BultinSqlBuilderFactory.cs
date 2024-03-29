﻿using System.Data;
using Krafted.Data.SqlBuilder;

namespace Krafted.Data.SqlServer.SqlBuilder
{
    /// <summary>
    /// Represents the ConcreteFactory [Gamma et al.] BultinSqlBuilderFactory.
    /// </summary>
    public class BultinSqlBuilderFactory : ISqlBuilderFactory
    {
        /// <summary>
        /// Create a SqlBuilder.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <returns>The SqlBuilder.</returns>
        public ISqlBuilder NewSqlBuilder<TEntity>(IDbConnection connection)
            where TEntity : Entity
                => new BultinSqlBuilder<TEntity>(connection);
    }
}