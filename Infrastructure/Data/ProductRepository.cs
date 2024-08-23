using Application.Interfaces;
using Core.Entities;
using Dapper;
using System.Data;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public ProductRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _connection.QueryAsync<Product>(
                "SELECT * FROM Products", transaction: _transaction);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Product>(
                "SELECT * FROM Products WHERE Id = @Id", new { Id = id }, _transaction);
        }

        public async Task AddAsync(Product product)
        {
            await _connection.ExecuteAsync(
                "INSERT INTO Products (Name, Price, Stock) VALUES (@Name, @Price, @Stock)", product, _transaction);
        }

        public async Task UpdateAsync(Product product)
        {
            await _connection.ExecuteAsync(
                "UPDATE Products SET Name = @Name, Price = @Price, Stock = @Stock WHERE Id = @Id", product, _transaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _connection.ExecuteAsync(
                "DELETE FROM Products WHERE Id = @Id", new { Id = id }, _transaction);
        }
    }
}
