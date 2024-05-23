namespace Course.Infrastructure.Entities
{
    public class PriceEntity
    {
        public decimal? Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string? Currency {  get; set; }   

    }
}