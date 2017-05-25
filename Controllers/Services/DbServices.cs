using eTohumApplication.Models.Base;
using System;
using System.Data;
using System.Data.SqlClient;

namespace eTohumApplication.Controllers.Services
{
    public class DbServices
    {
        public static OperationResult SetBsUser(BsUser bsUser)
        {
            OperationResult operationResult = new OperationResult();
            try
            {
                // All changes must be on master database for main smuser tables.
                /* With SetBsUser StoredProcedure, Name,Surname and Emailuser is inserted in the user table in database.
                 * In the same time EmailGuest is inserted in the EmailSend  table with BsUserId and Sended paramter with default value 0
                 */
                using (SqlConnection conn = new SqlConnection(BaseService.GetConnectionString()))
                {
                    using (SqlCommand comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SetBsUser";
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.AddWithValue("@pName", bsUser.Name);
                        comm.Parameters.AddWithValue("@pSurname", bsUser.Surname);
                        comm.Parameters.AddWithValue("@pEmail", bsUser.Email);

                        conn.Open();

                        using (SqlDataReader reader = comm.ExecuteReader())
                        {
                            operationResult = WebService.PrepareUpdateOperationResult(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                operationResult.ErrorMessage = ex.Message;
                BaseService.LogError(new BsError(ex), bsUser);
            }
            return operationResult;
        }
    }
}