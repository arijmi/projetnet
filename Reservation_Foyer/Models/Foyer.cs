namespace Reservation_Foyer.Models
{
    public class Foyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacite { get; set; }

        public IEnumerable<Universite> Universites { get; set; }
        public IEnumerable<Chambre> Chambres { get; set; }
    }
}