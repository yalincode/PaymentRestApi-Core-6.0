namespace PaymentRestApi.DTO
{
    public class WithdrawDTO : BaseDTO, IAccountNumber
    {
        public int accountNumber { get; set; }
    }
}
