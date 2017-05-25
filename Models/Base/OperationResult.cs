using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTohumApplication.Models.Base
{
    /// <summary>
    /// The model for getting operation results on services.
    /// </summary>
    public class OperationResult
    {
        public OperationResult()
        {
            Result = false;
        }
        public bool Result { get; set; }
        public string Message { get; set; }
        public int ErrorId { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Byte ErrorType { get; set; }
        public object Response { get; set; }

        public bool ProductWasDeleted { get; set; }
        public string IntegrationErrorCode { get; set; }

        public long QueryTime { get; set; }
    }
}