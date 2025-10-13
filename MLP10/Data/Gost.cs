namespace MLP10.Data
{
    public class Gost
    {
        public int GostId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birht { get; set; }
        public string? Pasport { get; set; } 
        public string? Phone { get; set; }
        
        public virtual ICollection<Arenda>? brons { get; set; }
    }
}
