namespace Reservation_Foyer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public int Cin { get; set; }
        public int Sex { get; set; }
        public int Role { get; set; }
        public int UniversiteId { get; set; }
        public int ChambreId { get; set; }
        public Universite Universite { get; set; }
        public Chambre Chambre { get; set; }
    }
}
