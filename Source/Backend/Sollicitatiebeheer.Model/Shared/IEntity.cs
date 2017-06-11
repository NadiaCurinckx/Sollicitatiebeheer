namespace Sollicitatiebeheer.Model.Shared {
    public interface IEntity<TKey> {
        TKey Id { get; }
    }
}