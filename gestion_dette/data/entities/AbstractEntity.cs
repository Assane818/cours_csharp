namespace GesDette.Data.entities
{
    public abstract class AbstractEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
        public DateTime UpdateAt { get; set; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

    }
}