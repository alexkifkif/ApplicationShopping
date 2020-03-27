using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTest.Services
{
    public class ProductDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ProductDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Product>().Wait();
        }

        public Task<List<Product>> GetAllProductAsync()
        {
            return _database.Table<Product>().ToListAsync();
        }

        public Task<Product> GetProductAsync(int id)
        {
            return _database.Table<Product>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveProductAsync(Product product)
        {
            if (product.Id != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }

        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }

    }
}
