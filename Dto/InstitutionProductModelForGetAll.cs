namespace Dto
{
    public class InstitutionProductModelForGetAll
    {
        public string InstitutionProductID { get; set; }
        public string USRInstitutionID { get; set; }
        public string ProductSubscriptionID { get; set; }
        public string PYMPaymentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
