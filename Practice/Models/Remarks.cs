namespace Practice.Models
{
    public class Remarks
    {
        public int ID { get; private set; }
        public int UserID { get; set; }
        public int CampID { get; set; }
        public string Description { get; set; }
    }
}
