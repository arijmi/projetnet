namespace Reservation_Foyer.Models
{
    public class Chambre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bloc { get; set; }
        public string Discription { get; set; }
        public int Capacite { get; set; }
        public Foyer Foyer { get; set; }
        public int FoyerId { get; set; }
        public IEnumerable<User> Users { get; set; }



    }
}
