namespace OrderManagement;

public interface IProduct<T>
{
    public string FullName { get; }
    public bool Save();
    public T Find(Guid productId);
    public List<T> ListAll();
}