namespace Structure
{
    public interface IAddComponent
    {
        public  Task AddComponentAsync(string featureID, string name, string code, string createdBy);
    }
}