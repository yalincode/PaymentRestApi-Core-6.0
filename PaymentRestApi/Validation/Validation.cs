using PaymentRestApi.Entities;

namespace PaymentRestApi.Validation
{
    public static class Validation
    {
        public static bool IndividualAccountTypeValidation(Account account)
        {
            if (account.accountType == (AccountType)0)
            {
                return true;
            }
            return false;   
        }
        public static bool CorporateAccountTypeValidation(Account account)
        {
            if (account.accountType == (AccountType)1)
            {
                return true;
            }
            return false;
        }

        public static bool CurrencyCodeTypeValidation(Account sender,Account receiver)
        {
            if (sender.curencyCode==receiver.curencyCode)
            {
                return true;
            }
            return false;
        }

        public static bool WithdrawAccountBalanceValidation(Account account,decimal amount)
        {
            if (account.balance>=amount)
            {
                return true;
            }
            return false;
        }
    }
}
