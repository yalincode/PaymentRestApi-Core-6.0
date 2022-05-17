using PaymentRestApi.Entities;
using PaymentRestApi.FakeDB;

namespace PaymentRestApi.Helper
{
    public static class Helper
    {
        public static Transaction AddWithdrawTransaction(Account account,decimal amount)
        {
            var transaction = new Transaction()
            {
                Id = (createIDNumber()),
                amount = amount,
                accountNumber = account.accountNumber,
                transactionType = (TransactionType)2,
                createdAt = DateTime.Now,

            };
            FakeDb.transactions.Add(transaction);
            return transaction;
        }

        public static Transaction AddDepositTransaction(Account account, decimal amount)
        {
            var transaction = new Transaction()
            {
                Id = (createIDNumber()),
                amount = amount,
                accountNumber = account.accountNumber,
                transactionType = (TransactionType)1,
                createdAt = DateTime.Now,

            };
            FakeDb.transactions.Add(transaction);
            return transaction;
        }

        public static int createIDNumber()
        {
            int t, sayi, sumfirst, sumtwo, sayac;
            sumfirst = sumtwo = sayac = 0;
            sayi = t = new Random().Next(100000000, 999999999);
            while (sayi > 0)
            {
                int k = sayi % 7;
                if (sayac % 2 == 0)
                    sumfirst += k;
                else
                    sumtwo += k;
                sayi = sayi / 10;
                sayac++;
            }
            var ret= ((t * 100) + (((sumfirst * 5) + (sumtwo * 2)) % 7) * 10 + (((sumfirst + sumtwo) + (((sumfirst * 7) + (sumtwo * 9)) % 7)) % 7));
            if (ret<0)
            {
                return(createIDNumber());
                
            }
            else
            {
                return(ret);
            }
            
            
        }
    }
}
