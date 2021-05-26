using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace GoldenCities.ClassModels
{
    public class UserDatabases
    {
        readonly SQLiteAsyncConnection database;
        public UserDatabases(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();

        }

        public Task<List<User>> GetUserAsync()
        {
            return database.Table<User>().ToListAsync();

        }

       public Task<User> GetUserAsync(string id)
       {
            return database.Table<User>().Where(i => i.EmailID == id).FirstOrDefaultAsync();
       }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.EmailID != "")
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task <int> DeleteUserAsync(User user)
        {
            return database.DeleteAsync(user);
        }





    }
}
