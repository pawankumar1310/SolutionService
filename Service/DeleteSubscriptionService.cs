using DBService;

namespace Service
{
 public class DeleteSubscriptionService
 {
    private readonly DeleteSubscription _deleteSubscription;

    public DeleteSubscriptionService(DeleteSubscription deleteSubscription)
    {
       _deleteSubscription=deleteSubscription;
    }
    public async  Task DeleteSubscriptionServiceAsync(string SubscriptionID)
    {
        await _deleteSubscription.DeleteSubscriptionAsync(SubscriptionID);

    }

 
 }
}