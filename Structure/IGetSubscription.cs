using Dto;

namespace Structure
{
    public interface IGetSubscription
    {
         public Task<List<GetSubscriptionModel>> GetAllSubscriptionsAsync();

    }
}