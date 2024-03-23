using DBService;
using Dto;

namespace Service
{
 public class GetComponentService
 {
    private readonly GetComponent _getComponent;

    public GetComponentService(GetComponent getComponent)
    {
        _getComponent=getComponent;
    }
    public async Task<List<GetComponentModel>> GetAllComponentsAsync()
    {
        List<GetComponentModel> lst=await _getComponent.GetAllComponentsAsync();
        return lst;
    }

 
 }
}