using Application.Interfaces;
using Core.Entities;
using Dapper;
using System.Data;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly SQLHelper.SQLHelper _sqlHelper;

        public ProductRepository()
        {
            
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var result = _sqlHelper.ExecuteSqlScript<Product>("select * from sometable");
            return result;
        }

       
    }
}
