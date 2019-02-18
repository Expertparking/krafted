﻿using Dapper.FluentMap.Configuration;
using SharedKernel.Domain;

namespace Krafted.Infrastructure.Maps
{
    public static class FluentMapConfigurationExtension
    {
        public static void AddMap<TEntity>(this FluentMapConfiguration config)
            where TEntity : Entity
        {
            config.AddMap(new DefaultMap<TEntity>());
        }
    }
}