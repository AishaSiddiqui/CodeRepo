using CRUDApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDApplication.DAL
{
    public class UserRepository:IUserRepository
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString);
        SqlCommand cmd;
        private UsersContext _context;
        public UserRepository(UsersContext userContext) { this._context = userContext; }
        public IEnumerable<Users> GetUsers() { return _context.Users.ToList(); }
        public Users GetUserByID(int userid)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "Execute MasterInsertUpdateDelete @userid,@username,@useremail,@userpassword,@StatementType";
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = userid;         
            cmd.Parameters.Add("@StatementType", SqlDbType.NVarChar, 20).Value = "SelectByID";
            var data=ExecuteSP(conn, cmd);
            return _context.Users.Where(x => x.UserID == userid) != null ? _context.Users.FirstOrDefault(x => x.UserID == userid) : null;
        }
        public void InsertUser(Users user)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "Execute MasterInsertUpdateDelete @userid,@username,@useremail,@userpassword,@StatementType";
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = user.UserID;
            cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = user.UserName;
            cmd.Parameters.Add("@useremail", SqlDbType.VarChar, 50).Value = user.UserEmail;
            cmd.Parameters.Add("@userpassword", SqlDbType.VarChar, 50).Value = user.UserPassword;
            cmd.Parameters.Add("@StatementType", SqlDbType.NVarChar, 20).Value = "Insert";
            ExecuteSP(conn, cmd);

        }
        public void DeleteUser(int userid)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "Execute MasterInsertUpdateDelete @userid,@username,@useremail,@userpassword,@StatementType";
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = userid;
            cmd.Parameters.Add("@StatementType", SqlDbType.NVarChar, 20).Value = "Delete";
            ExecuteSP(conn, cmd);
            // _context.Users.Remove(_context.Users.FirstOrDefault(x => x.UserID == userid));
        }
        public void UpdateUser(Users user)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "Execute MasterInsertUpdateDelete @userid,@username,@useremail,@userpassword,@StatementType";
            cmd.Parameters.Add("@userid", SqlDbType.Int).Value = user.UserID;
            cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = user.UserName;
            cmd.Parameters.Add("@useremail", SqlDbType.VarChar, 50).Value = user.UserEmail;
            cmd.Parameters.Add("@userpassword", SqlDbType.VarChar, 50).Value = user.UserPassword;
            cmd.Parameters.Add("@StatementType", SqlDbType.NVarChar, 20).Value = "Update";
            ExecuteSP(conn, cmd);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IEnumerable<Users> ExecuteSP(SqlConnection conn,SqlCommand cmd)
        {           
            conn.Open();
            var result= cmd.ExecuteNonQuery();
            conn.Close();
          
        }
    }
}