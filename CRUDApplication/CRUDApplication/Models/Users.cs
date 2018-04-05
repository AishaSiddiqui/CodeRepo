using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDApplication.Models
{
    public class Users
    {
        private int m_UserID;
        private string m_UserName;
        private string m_UserEmail;
        private string m_UserPassword;

        public int UserID { get { return m_UserID; }set { m_UserID = value; } }
        public string UserName { get { return m_UserName; } set {m_UserName = value; } }
        public string UserPassword { get { return m_UserPassword; } set { m_UserPassword = value; } }
        public string UserEmail { get { return m_UserPassword; } set { m_UserPassword = value; } }
    }
}