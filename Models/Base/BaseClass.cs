using System;
using eTohumApplication.Models.Base;

namespace eTohumApplication.Models.Base
{
    public class BaseClass
    {
        public string Culture { get; set; }
        public string Currency { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public object Object { get; set; }
        public int OperationType { get; set; }
        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public DateTime LastTransactionStartTime { get; set; }
        public DateTime LastTransactionEndTime { get; set; }

        public string DatabaseName { get; set; }
        public bool UseMasterDb { get; set; }

        public string Server { get; set; }

        public string SourceLocation { get; set; }

    }
}