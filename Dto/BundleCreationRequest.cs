namespace Dto
{
    public class BundleCreationRequest
    {
        public string BundleName { get; set; }
        public string BundleCode { get; set; }
        public string CreatedBy { get; set; }
        public List<string> Products { get; set; }
    }
}
