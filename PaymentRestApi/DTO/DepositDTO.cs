namespace PaymentRestApi.DTO
{
    public class DepositDTO : BaseDTO, IAccountNumber
    {
        public int accountNumber { get; set ; }
    }
}
