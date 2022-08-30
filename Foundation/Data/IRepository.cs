using System.Threading.Tasks;
using System.Threading;
using Foundation.Classes;
using System.Collections.Generic;
using System;

namespace Foundation.Data;

public interface IRepository<TEntity>
    where TEntity : EntityBase
{
    Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default!);
    Task<IEnumerable<TEntity>> ReadAsync(CancellationToken cancellationToken = default!, params Func<TEntity, bool>[] predicates);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default!);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default!);
}