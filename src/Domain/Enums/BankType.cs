using System.Runtime.Serialization;

namespace PaymentDemo.Domain.Enums
{
    public enum BankType
    {
        [EnumMember(Value = "Akbank")]
        Akbank = 1,

        [EnumMember(Value = "Garanti")]
        Garanti = 2,

        [EnumMember(Value = "Yapı Kredi")]
        YapiKredi = 3
    }
}
