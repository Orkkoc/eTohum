using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using eTohumApplication.Models.Base;

namespace eTohumApplication.Controllers.Services
{
    public class WebService
    {
        //Prepare recevived SQLdata for use
        public static OperationResult PrepareUpdateOperationResult(SqlDataReader dataReader, bool justLastReader = false)
        {

            List<DataTable> readers = GetDataReaders(dataReader);
            if (justLastReader)
            {
                readers = readers.GetRange(readers.Count - 1, 1);
            }

            DataTable table = null;
            DataTable pretable = null;

            if (readers.Count > 1)
                pretable = readers[readers.Count - 2];
            if (readers.Count > 0)
                table = readers[readers.Count - 1];

            OperationResult operationResult = new OperationResult();
            if (table.Rows.Count > 0)
            {
                int result = Convert.ToInt32(table.Rows[0]["Result"]);
                switch (result)
                {
                    case 0:
                        operationResult.ErrorMessage = table.Rows[0]["Message"].ToString();
                        operationResult.Message = operationResult.ErrorMessage;
                        break;
                    case 1:
                        if (Convert.ToInt32(table.Rows[0]["AffectedRowCount"]) > 0)
                        {
                            operationResult.Result = true;
                            operationResult.Message = "Operation Succeeded";
                            List<long> ids = new List<long>();
                            if (pretable != null)
                            {
                                ids.AddRange(from DataRow row in pretable.Rows select Convert.ToInt64(row["Id"]));
                            }
                            operationResult.Response = ids;

                        }
                        break;
                    default:
                        operationResult.ErrorMessage = "Operation Failed";
                        operationResult.Message = operationResult.ErrorMessage;
                        break;
                }
            }
            else
            {
                operationResult.ErrorMessage = "Operation Failed";
                operationResult.Message = operationResult.ErrorMessage;
            }
            return operationResult;
        }

        // Return DataReaders for contaning table information
        public static List<DataTable> GetDataReaders(SqlDataReader dataReader)
        {
            List<DataTable> readers = new List<DataTable>();

            while (!dataReader.IsClosed)
            {
                DataTable table = new DataTable();
                table.Load(dataReader);
                readers.Add(table);
            }
            return readers;
        }
    }
}
