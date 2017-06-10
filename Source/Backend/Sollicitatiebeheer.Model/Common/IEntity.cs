namespace Sollicitatiebeheer.Model.Common {
    public interface IEntity<TKey> {
        TKey Id { get; }
    }
}
