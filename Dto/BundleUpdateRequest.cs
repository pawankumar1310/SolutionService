namespace Dto
{
    public class BundleUpdateRequest
    {
    public string BundleName { get; set; }
    public string BundleCode { get; set; }
    public List<string> Products { get; set; }
    public string UpdatedBy { get; set; }
    }

}
