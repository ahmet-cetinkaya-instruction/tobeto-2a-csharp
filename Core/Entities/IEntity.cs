namespace Core.Entities;

public interface IEntity<TId>
{
    public TId Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
