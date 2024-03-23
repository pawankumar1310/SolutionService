using DBService;
using Dto;

namespace Service
{
 public class UpdateComponentService
 {
    private readonly UpdateComponent _updateComponent;

    public UpdateComponentService(UpdateComponent updateComponent)
    {
        _updateComponent=updateComponent;
    }
    public async Task UpdateComponentAsync(string componentID, string featureID, string name, string code, string updatedBy)
    {
        await   _updateComponent.UpdateComponentAsync(componentID,featureID,name,code,updatedBy);
    }

 
 }
}