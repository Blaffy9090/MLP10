namespace MLP10.Data
{
    public class Apartament
    {
        public int ApartamentId { get; set; }
        public int? ApartamentNumber { get; set; }
        public string? ApartamentType { get; set; }
        public int? Cost { get; set; }

        public virtual ICollection<Arenda>? brons { get; set; }
    }
}
