namespace TestTestServer.Models
{
    public class ParcelRequest
    {
        public string? ParDescription { get; set; }
        public string? ParStatus { get; set; }
        public DateTime ParDeliveryDate { get; set; }
        public string? ParLocation { get; set; }
        public DateTime Realtime { get; set; }
        public string? Note { get; set; }
        public int Price { get; set; }
        public int CusID { get; set; }
        public int ManID { get; set; }
    }
}
