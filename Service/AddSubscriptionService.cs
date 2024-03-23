using DBService;

namespace Service
{
 public class AddSubscriptionService
 {
    private readonly AddSubscription _addSubscription;

    public AddSubscriptionService(AddSubscription addSubscription)
    {
        _addSubscription=addSubscription;
    }
    public async  Task AddSubscriptionServiceAsync(string? mode, string? createdBy, long? maximumDays, long? minimumDays)
    {
        await _addSubscription.AddSubscriptionAsync(mode,createdBy,maximumDays,minimumDays);

    }

 
 }
}