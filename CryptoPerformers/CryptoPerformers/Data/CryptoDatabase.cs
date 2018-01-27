using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoPerformers.Models;
using SQLite;

namespace CryptoPerformers.Data
{
    public class CryptoDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public CryptoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<CryptoData>().Wait();
        }

        public Task<List<CryptoData>> GetItemsAsync()
        {
            return _database.Table<CryptoData>().ToListAsync();
        }

        public Task<CryptoData> GetItemAsync(string id)
        {
            return _database.Table<CryptoData>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(CryptoData item)
        {
            if (!string.IsNullOrEmpty(item.Id)) return _database.UpdateAsync(item);

            return _database.InsertAsync(item);
        }


        public Task<int> DeleteItemAsync(CryptoData item)
        {
            return _database.DeleteAsync(item);
        }
    }
}