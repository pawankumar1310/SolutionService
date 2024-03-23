namespace Structure
{
    public interface IFeatures
    {
        public Task<List<string>> GetFeatureCodeByUserId(string userId);
    }
}
