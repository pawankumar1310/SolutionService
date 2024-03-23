using Microsoft.VisualBasic;

namespace Dto
{
    public class GetComponentModel
    {
            public string ComponentID { get; set; }
            public string FeatureID { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public string CreatedBy { get; set; }
            public string UpdatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public DateTime UpdatedDate { get; set; }
    }
}