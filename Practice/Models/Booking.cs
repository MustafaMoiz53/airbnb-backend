namespace Practice.Models
{
    public class Booking
    {
        public int Id { get; private set; }
        public int CampID { get; set; }
        public int UserID{ get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
