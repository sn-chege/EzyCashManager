namespace AccountService.Models
{
    public class TransferRequest
    {
        public int RecipientAccountId { get; set; }
        public double Amount { get; set; }
    }
}
