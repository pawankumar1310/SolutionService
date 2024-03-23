    namespace Dto
    {

        public class GetProduct
        {
            public string ProductID { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public decimal AmountPerDay { get; set; }
            public List<GetSubscriptionModel> subscriptions {get; set;}
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }
        }

    }
