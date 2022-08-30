using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Foundation.Classes;

namespace Foundation.Data;

public interface IRepository<TEntity>
    where TEntity : EntityBase
{
    Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default!);
    Task<IEnumerable<TEntity>> ReadAsync(CancellationToken cancellationToken = default!, params Func<TEntity, bool>[] predicates);
    Task<TEntity> ReadAsync(Guid id, CancellationToken cancellationToken = default!);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default!);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
}