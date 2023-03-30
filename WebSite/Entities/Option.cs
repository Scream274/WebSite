namespace WebSite.Entities
{
    public class Option
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Relation { get; set; }
        public int Order { get; set; }
    }
}
