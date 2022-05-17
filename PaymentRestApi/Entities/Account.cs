namespace PaymentRestApi.Entities
{
    public class Account:BaseEntity
    {
        public int accountNumber { get; set; }
        public CurencyCode curencyCode { get; set; }
        public string ownerName { get; set; } = string.Empty;
        public AccountType accountType { get; set; }

        private decimal _balance;

        public decimal balance
        {
            get 
            { 
                return Math.Round(_balance,2); 
            }
            set { _balance = value; }
        }

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
