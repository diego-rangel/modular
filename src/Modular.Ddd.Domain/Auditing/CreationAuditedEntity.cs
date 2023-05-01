﻿using Modular.Ddd.Domain.Auditing.Contracts;
using Modular.Ddd.Domain.Entities;

namespace Modular.Ddd.Domain.Auditing
{
    /// <summary>
    /// A shortcut of <see cref="CreationAuditedEntity{TEntityPrimaryKey, TUserKey}"/> for most used primary key type (<see cref="Guid"/>).
    /// </summary>
    public abstract class CreationAuditedEntity : CreationAuditedEntity<Guid, Guid>
    {

    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="ICreationAudited"/>.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    public abstract class CreationAuditedEntity<TEntityPrimaryKey, TUserKey> : 
        Entity<TEntityPrimaryKey>, 
        ICreationAudited<TEntityPrimaryKey, TUserKey>
        where TUserKey : struct
    {
        /// <inheritdoc/>
        public DateTime CreationTime { get; set; }

        /// <inheritdoc/>
        public TUserKey CreatorId { get; set; }
    }

    /// <summary>
    /// This class can be used to simplify implementing <see cref="ICreationAudited{TEntityPrimaryKey, TUserKey, TUser}"/>.
    /// </summary>
    /// <typeparam name="TEntityPrimaryKey">The entity's key type</typeparam>
    /// <typeparam name="TUserKey">The user's primary key type</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public abstract class CreationAuditedEntity<TEntityPrimaryKey, TUserKey, TUser> : 
        CreationAuditedEntity<TEntityPrimaryKey, TUserKey>, 
        ICreationAudited<TEntityPrimaryKey, TUserKey, TUser>
        where TUser : IEntity<TUserKey>
        where TUserKey : struct
    {
        /// <inheritdoc/>
        public TUser CreatorUser { get; set; } = default!;
    }
}