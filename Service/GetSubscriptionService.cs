using DBService;
using Dto;

namespace Service
{
 public class GetSubscriptionService
 {
    private readonly GetSubscription _getSubscription;

    public GetSubscriptionService(GetSubscription getSubscription)
    {
        _getSubscription=getSubscription;
    }
    public async Task<List<GetSubscriptionModel>> GetAllSubscriptionAsync()
    {
        List<GetSubscriptionModel> lst=await _getSubscription.GetAllSubscriptionsAsync();
        return lst;
    }

    public async Task<GetSubscriptionModel> GetSubscriptionByIDAsync(string subscriptionID)
    {
        return await _getSubscription.GetAllSubscriptionByIdAsync(subscriptionID);
        
    }

 
 }
}