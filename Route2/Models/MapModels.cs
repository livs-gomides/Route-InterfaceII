namespace Route2.Models
{
    public class LocalItem
    {
        public Guid LocalID { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class SubLocalItem
    {
        public Guid SubLocalID { get; set; }
        public Guid LocalID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int FloorLevel { get; set; }
    }
}