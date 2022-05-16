namespace PaymentRestApi.Entities
{
    public class Account:BaseEntity
    {
        public int accountNumber { get; set; }
        public CurencyCode curencyCode { get; set; }
        public string ownerName { get; set; } = string.Empty;
        public AccountType accountType { get; set; }
        public decimal balance { get; set; }
    }

    public enum CurencyCode
    {
        TRY,
        USD,
        EUR
    }

    public enum AccountType
    {
        individual,
        corporate,
    }
}
