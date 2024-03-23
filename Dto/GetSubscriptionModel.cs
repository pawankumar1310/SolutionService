using Microsoft.VisualBasic;

namespace Dto
{
    public class GetSubscriptionModel
    {
        public string SubscriptionID { get; set; }
        public string Mode { get; set; }
        public double MaximumDays { get; set; }
        public double MinimumDays { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}