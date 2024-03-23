namespace Dto
{
    public class UpdateProductRequest
    {
    //public string ProductId { get; set; }
    public string Name { get; set; }
    public decimal AmountPerDay { get; set; }
    public string Code { get; set; }
    public List<string> SubscriptionModes { get; set; }
    public string UpdatedBy { get; set; }
    }
}