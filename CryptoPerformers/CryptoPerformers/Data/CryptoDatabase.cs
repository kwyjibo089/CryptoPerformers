using System;
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
            try
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<CryptoData>().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public Task<List<CryptoData>> GetItemsAsync()
        {
            return _database.QueryAsync<CryptoData>("SELECT * FROM [CryptoData] ORDER BY CAST(Rank AS INTEGER)");
        }

        public Task<CryptoData> GetItemAsync(string id)
        {
            return _database.Table<CryptoData>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(CryptoData item)
        {
            return _database.InsertOrReplaceAsync(item);
        }


        public Task<int> DeleteItemAsync(CryptoData item)
        {
            return _database.DeleteAsync(item);
        }
    }
}