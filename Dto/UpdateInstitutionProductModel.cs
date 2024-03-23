namespace Dto
{
    public class UpdateInstitutionProductModel
    {
        public string USRInstitutionID { get; set; }
        public string ProductSubscriptionID { get; set; }
        public string PYMPaymentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
