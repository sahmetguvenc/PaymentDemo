using System.Runtime.Serialization;

namespace PaymentDemo.Domain.Enums
{
    public enum TransactionStatus
    {
        [EnumMember(Value = "Success")]
        Success = 1,

        [EnumMember(Value = "Fail")]
        Fail = 2,
    }
}
