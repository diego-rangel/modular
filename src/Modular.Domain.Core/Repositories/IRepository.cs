﻿using Modular.Domain.Core.Entities;

namespace Modular.Domain.Core.Repositories;

public interface IRepository<TEntity, in TPrimaryKey> :
    IReadableRepository<TEntity, TPrimaryKey>,
    ICreatableRepository<TEntity, TPrimaryKey>,
    IUpdatableRepository<TEntity, TPrimaryKey>,
    IDeletableRepository<TEntity, TPrimaryKey>
    where TEntity : IEntity<TPrimaryKey>
{

}

public interface IRepository<TEntity> : IRepository<TEntity, Guid>
    where TEntity : IEntity<Guid>
{

}