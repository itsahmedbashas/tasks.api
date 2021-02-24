using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Tasks.API.Connections;
using Tasks.API.Models;
using System.Linq;

namespace Tasks.API.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly IConnFactory _connFactory;

        public UserRepo(IConnFactory connFactory)
        {
            _connFactory = connFactory;
        }

        // insert user
        public async Task<bool> InsertUser(UserModel user)
        {
            var query = @"INSERT INTO Users (UserName,UserPassword,UserFullName,UserEmail,UserPhoneNumber,UserGender) 
                Values (@UserName,@UserPassword,@UserFullName,@UserEmail,@UserPhoneNumber,@UserGender)";

            using (IDbConnection conn = _connFactory.GetSqlConnection())
            {
                var x = await conn.ExecuteAsync(query, user);
            }
            return true;
        }

        // get user
        public async Task<UserModel> GetUser(UserModel user)
        {
            UserModel usr;
            var query = @"select UserId,UserName from Users where UserName=@UserName and UserPassword=@UserPassword";

            using (IDbConnection conn = _connFactory.GetSqlConnection())
            {
                usr = await conn.QuerySingleOrDefaultAsync<UserModel>(query, user);
            }
            return usr;
        }

        // checking username 
        public async Task<bool> CheckUserName(string userName)
        {
            int userC = 0;
            var query = @"select count(1) from Users where UserName=@UserName";

            using (IDbConnection conn = _connFactory.GetSqlConnection())
            {
                userC = await conn.QuerySingleAsync<int>(query, new { UserName = userName });
            }

            if (userC == 1)
                return true;
            else
                return false;
        }

        //update user
        public async Task<bool> UpdateUser(UserModel user)
        {
            var query = @"Update Users 
                Set 
                UserName=@UserName,
                UserPassword=@UserPassword,
                UserFullName=@UserFullName,
                UserEmail=@UserEmail,
                UserPhoneNumber=@UserPhoneNumber,
                UserGender=@UserGender 
                where UserId=@UserId";

            using (IDbConnection conn = _connFactory.GetSqlConnection())
            {
                await conn.ExecuteScalarAsync<UserModel>(query, user);
            }
            return true;
        }

        //get users
        public async Task<List<UserModel>> GetUsers()
        {
            var query = "Select * from Users order by 1 desc";
            var result = new List<UserModel>();
            using (IDbConnection conn = _connFactory.GetSqlConnection())
            {
                var res = await conn.QueryAsync<UserModel>(query);
                result = res.ToList();
            }
            //throw new ArgumentException();
            return result;
        }

        //delete user
        public async Task<bool> DeleteUser(int userId)
        {
            var query = "delete from Users where UserId=@UserId";
            using (IDbConnection conn = _connFactory.GetSqlConnection())
            {
                await conn.ExecuteAsync(query, new { UserId = userId });
            }

            return true;
        }
    }
}