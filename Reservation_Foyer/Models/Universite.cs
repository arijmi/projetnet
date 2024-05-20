namespace Reservation_Foyer.Models
{
    public class Universite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Adress { get; set; }
        public IEnumerable<Foyer> Foyers { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
