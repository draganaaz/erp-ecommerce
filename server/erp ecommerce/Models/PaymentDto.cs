namespace erp_ecommerce.Models
{
    public class PaymentDto
    {
        public string tokenId { get; set; }
        public string productName { get; set; }
        public int amount { get; set; }
    }
}
