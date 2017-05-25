using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTohumApplication.Models
{
    public class DbConnectionString
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int ConnectionTimeout { get; set; }


        public string GetConnectionString()
        {
            return String.Format(
                "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Connection Timeout={4}",
                DataSource, InitialCatalog, UserId, Password, ConnectionTimeout);
        }
    }
}