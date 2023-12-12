using System.Runtime.Serialization;

namespace PaymentDemo.Domain.Enums
{
    public enum TransactionType
    {
        [EnumMember(Value = "Sale")]
        Sale = 1,

        [EnumMember(Value = "Refund")]
        Refund = 2,

        [EnumMember(Value = "Cancel")]
        Cancel = 3,
    }
}
