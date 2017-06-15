namespace Sollicitatiebeheer.Model.Shared {
    public abstract class Entity<TKey> : IEntity<TKey> {
        public TKey Id { get; set; }
    }
}