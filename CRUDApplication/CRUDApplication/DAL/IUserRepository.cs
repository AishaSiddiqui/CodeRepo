using CRUDApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDApplication.DAL
{
    public interface IUserRepository: IDisposable
    {
        IEnumerable<Users> GetUsers();
        Users GetUserByID(int userid);
        void InsertUser(Users user);
        void DeleteUser(int userid);
        void UpdateUser(Users user);
        void Save();
        
    }
}