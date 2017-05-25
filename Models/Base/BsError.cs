using System;

namespace eTohumApplication.Models.Base
{
    public class BsError
    {
        public Exception ex;

        public BsError(Exception ex)
        {
            this.ex = ex;
        }

        public static class ErrorType
        {
            public const byte None = 0;
            public const byte Error = 1;
            public const byte LoginOff = 2;
            public const byte SuspectAttack = 3;
            public const byte Permission = 4;
            public const byte SuccessButCanNotContinue = 5;
        }
    }
}