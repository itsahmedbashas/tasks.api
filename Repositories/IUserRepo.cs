using System.Collections.Generic;
using System.Threading.Tasks;
using Tasks.API.Models;

namespace Tasks.API.Repositories
{
    public interface IUserRepo
    {

        public Task<bool> InsertUser(UserModel user);
        public Task<UserModel> GetUser(UserModel user);
        public Task<bool> CheckUserName(string userName);
        public Task<bool> UpdateUser(UserModel user);   
        public Task<List<UserModel>> GetUsers();

        public Task<bool> DeleteUser(int userId);
    }
 
}