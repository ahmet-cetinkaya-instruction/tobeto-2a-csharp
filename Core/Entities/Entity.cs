using System.Security.Cryptography;

namespace Core.Entities;

public abstract class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
