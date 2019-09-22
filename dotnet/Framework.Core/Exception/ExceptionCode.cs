using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Exception
{
    public static class ExceptionCode
    {
        public const int PersonNotFoundCode = 1001;
        public const int DuplicateOrderNumber = 1002;
        public const int PersonIsNotActiveCode = 1003;
        public const int ForignkeyDeleteCode = 1004;
        public const int DuplicatePersonCustomerCode = 1005;
        public const int DuplicateShipmentNumberCode = 1006;
        public const int InvalidDataAccess = 1007;
        public const int EmailNotFoundCode = 1008;
        public const int TestNotFoundCode = 1009;
        public const int QuestionNotFoundCode = 1010;
        public const int AccessPolicyNotFoundCode = 1011;
        public const int NotExistConfigCode = 1012;
    }
}
