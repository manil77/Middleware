using Application.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        private IProductRepository _productRepository;

        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository(_connection, _transaction);
            }
        }

        public async Task<int> CompleteAsync()
        {
            try
            {
                _transaction.Commit();
                return 1; // Return a success code or the number of affected rows if needed
            }
            catch
            {
                _transaction.Rollback();
                return 0; // Return a failure code or throw an exception
            }
            finally
            {
                await DisposeAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public void Dispose()
        {
            DisposeAsync().GetAwaiter().GetResult();
        }



    }
}
