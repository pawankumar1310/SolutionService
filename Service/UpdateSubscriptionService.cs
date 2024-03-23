using DBService;
using Dto;

namespace Service
{
 public class UpdateSubscriptionService
 {
    private readonly UpdateSubscription _updateSubscription;

    public UpdateSubscriptionService(UpdateSubscription updateSubscription)
    {
        _updateSubscription=updateSubscription;
    }
    public async Task UpdateSubscriptionAsync(string subscriptionID, string mode, long maximumDays, long minimumDays, string updatedBy)
    {
        await   _updateSubscription.UpdateSubscriptionAsync(subscriptionID,mode,maximumDays,minimumDays,updatedBy);
    }

 
 }
}