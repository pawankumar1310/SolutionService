using DBService;

namespace Service
{
 public class AddComponentService
 {
    private readonly AddComponent _addComponent;

    public AddComponentService(AddComponent addComponent)
    {
        _addComponent=addComponent;
    }
    public async  Task AddComponentServiceAsync(string featureID, string name, string code, string createdBy)
    {
        await _addComponent.AddComponentAsync(featureID,name,code,createdBy);

    }

 
 }
}