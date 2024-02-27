namespace WebAPI.Entity
{
    public class Phone
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Made { get; set; }
        public string Imei { get; set; }
    }
}
