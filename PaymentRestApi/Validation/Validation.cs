using Microsoft.AspNetCore.Mvc;
using PaymentRestApi.Entities;

namespace PaymentRestApi.Validation
{
    public static class Validation
    {
        public static Tuple<bool,string> AccountValidation(Account account)
        {

            foreach (var item in FakeDB.FakeDb.accounts)
            {
                if (item.accountNumber==account.accountNumber)
                {
                    var tuple1 = new Tuple<bool, string>(false, "This account number is already using.");
                    return tuple1;
                }
                
            }
            if (account.accountNumber < 100)
            {
                var tuple2 = new Tuple<bool, string>(false, "Account number must be more than 2 digits.");
                return tuple2;
            }
            if (account.balance < 0)
            {
                var tuple3 = new Tuple<bool, string>(false, "Account balance can not be less than 0");
                return tuple3;
            }
            var tuple = new Tuple<bool, string>(true, "Validation Completed");
            return tuple;
        }
        
        
        
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
