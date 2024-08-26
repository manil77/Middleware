using Application.Interfaces;
using Infrastructure.Interfaces.UnitOfWork;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryUnitOfWork _repositoryUnitOfWork;
        public ProductService()
        {
            
        }

        public void PostData(string value1, string value2)
        {
            var result = _repositoryUnitOfWork.Product.PostData(value1, value2);
        }
    }
}
