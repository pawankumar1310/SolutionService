namespace Structure
{
    public interface IUpdateComponent
    {
       public  Task UpdateComponentAsync(string componentID, string featureID, string name, string code, string updatedBy);
    }
}