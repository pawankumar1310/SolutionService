using Dto;

namespace Structure
{
    public interface IGetComponent
    {
        public  Task<List<GetComponentModel>> GetAllComponentsAsync();

    }
}