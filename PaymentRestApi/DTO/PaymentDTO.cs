namespace PaymentRestApi.DTO
{
    public class PaymentDTO :BaseDTO
    {
        public int senderAccount { get; set; }
        public int receiverAccount { get; set; }
    }
}
