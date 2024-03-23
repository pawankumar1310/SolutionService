namespace Dto
{
    public class UpdateSubscriptionModel
    {
        public string Mode { get; set; }
        public long MaximumDays { get; set; }
        public long MinimumDays { get; set; }
        public string? UpdatedBy { get; set; }
    }
}