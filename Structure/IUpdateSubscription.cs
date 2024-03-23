namespace Structure
{
    public interface IUpdateSubscription
    {
        public  Task UpdateSubscriptionAsync(string subscriptionID, string mode, long maximumDays, long minimumDays, string updatedBy);
    }
}