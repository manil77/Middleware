
namespace Application.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository ProductRepository { get; }
        Task<int> CompleteAsync();
    }
}
