namespace PaymentRestApi.Entities
{
    public class Transaction:BaseEntity
    {
        public decimal amount { get; set; }
        public int accountNumber { get; set; }
        public TransactionType transactionType { get; set; }
        public DateTime? createdAt { get; set; }
    }

    public enum TransactionType
    {
        payment,
        deposit,
        withdraw
    }
}
