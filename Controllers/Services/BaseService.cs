using System;
using eTohumApplication.Controllers;

namespace eTohumApplication.Models.Base
{
    public static class BaseService
    {

        /// <summary>
        /// This service gets SQL connections string.
        /// </summary>
        /// <returns>Return SQL connections string.</returns>
        public static string GetConnectionString(BaseClass baseClass = null)
        {

            //Connection String Info Set
            DbConnectionString dbConnectionString = new DbConnectionString
            {
                DataSource = "192.168.1.10",
                InitialCatalog = Constants.Databases.Master,
                UserId = "etohum",
                Password = "etohum1"
            };

            return dbConnectionString.GetConnectionString();
        }

        public static void LogError(BsError bsError, BsUser bsUser)
        {
            throw new NotImplementedException();
        }
    }
}
