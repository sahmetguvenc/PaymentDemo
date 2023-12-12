namespace PaymentDemo.Domain.Result
{
    public record Error(string Code, string Name)
    {
        public static Error None = new(string.Empty, string.Empty);

        public static Error NullValue = new("Error.NullValue", "Null value was provided");

        public static Error Insert = new("Error.Insert", "An error occurred while adding record");

        public static Error Update = new("Error.Update", "An error occurred while update record");

        public static Error InvalidTransaction = new("Error.InvalidTransaction", "Invalid transaction");

        public static Error NotSameDayTransaction = new("Error.NotSameDayTransaction", "Cancellation is valid for same-day transfers");

        public static Error NotPassedOneDayTransaction = new("Error.NotPassedOneDayTransaction", "Refunds can be made for payments that are 1 day past due.");

        public static Error NotFound = new("Record.NotFound", "The record with the specified identifier was not found");

    }

}
