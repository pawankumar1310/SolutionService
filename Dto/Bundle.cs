namespace Dto 
{

    public class Bundle
    {
    public string BundleID { get; set; }
    public string BundleName { get; set; }
    public string BundleCode { get; set; }
    
    public string CreatedBy {get; set; }
    public string UpdatedBy {get; set; }
    public DateTime CreatedDate {get; set; }
    public DateTime UpdatedDate {get; set; }
    public List<string> ProductName { get; set; }
    public decimal ProductTotalCost { get; set; }
      
    }


}