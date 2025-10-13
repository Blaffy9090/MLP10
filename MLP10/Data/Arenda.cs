namespace MLP10.Data
{
    public class Arenda
    {
        public int ArendaId {  get; set; }
        public int ApartamentId { get; set; }
        public int GostId { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public int Cost { get; set; }
       
        public virtual Apartament? apartament { get; set; }
        public virtual Gost? gost { get; set; }
    }
}
