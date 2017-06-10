namespace Sollicitatiebeheer.Model.Common {
    public abstract class Entity<TKey> : IEntity<TKey> {
        public TKey Id { get; protected set; }
    }
}