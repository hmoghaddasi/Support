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
        public const int MobileExists = 1002;
        public const int NotExistPharmacyCode = 1003;
        public const int ForignKeyDeleteCode = 1004;
        public const int PersonAlreadyConfirmed = 1005;
        public const int IncorrectConfirmationPassword = 1006;
        public const int NotExistProductCode = 1007;
        public const int InvalidDataAccess = 1008;
        public const int AccessPolicyNotFoundCode = 1009;
        public const int NotExistConfigCode = 1010;
        public const int NotExistRegionCode = 1011;
        public const int NotExistLocationCode = 1012;
        public const int NotExistRequestCode = 1013;
        public const int PersonNotActiveCode = 1014;
        public const int NotExistResponseCode = 1015;
        public const int NotExistCreditCode = 1016;
        public const int NotExistImageCode = 1017;
        public const int PharmacyIsNotActive = 1018;
        public const int RequestAlreadyConfirmed = 1019;
        public const int ExpressionBuilderFailCode = 1020;
    }
}
