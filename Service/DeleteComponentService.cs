using DBService;

namespace Service
{
 public class DeleteComponentService
 {
    private readonly DeleteComponent _deleteComponent;

    public DeleteComponentService(DeleteComponent deleteComponent)
    {
       _deleteComponent=deleteComponent;
    }
    public async  Task DeleteComponentServiceAsync(string ComponentID)
    {
        await _deleteComponent.DeleteComponentAsync(ComponentID);

    }

 
 }
}