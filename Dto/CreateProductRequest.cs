namespace Dto
{
    public class CreateProductRequest
    {
    
    public string? Name { get; set; }
    public decimal? AmountPerDay { get; set; }
    public string? Code { get; set; }
    public List<string>? SubscriptionModes { get; set; }
    public string? CreatedBy { get; set; }
    

    }


}