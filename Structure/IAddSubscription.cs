namespace Structure
{
    public interface IAddSubscription
    {
       public  Task AddSubscriptionAsync(string? mode, string? createdBy, long? maximumDays, long? minimumDays);
    }
}