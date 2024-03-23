using DBService;
using Structure;

namespace Service
{
    public class FeatureService
    {
        private readonly IFeatures _features;
       // private readonly FeatureDBService _featureDBService;

        public FeatureService(IFeatures features)
        {
            _features=features;
        }
        public async Task<List<string>> GetFeatureCodeService(string userId)
        {
           List<string> result= await _features.GetFeatureCodeByUserId(userId);
            return result;  


        }

    }
}
