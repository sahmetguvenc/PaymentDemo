namespace PaymentDemo.Application.Extensions
{
    public static class IntegerExtensions
    {
        public static T GetEnum<T>(this int enumValue) => (T)Enum.Parse(typeof(T), enumValue.ToString());

    }
}
