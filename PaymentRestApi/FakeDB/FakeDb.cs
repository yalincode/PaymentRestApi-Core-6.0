using PaymentRestApi.Entities;

namespace PaymentRestApi.FakeDB
{
    public static class FakeDb
    {
        static FakeDb()
        {
            Seed();
        }
 
        public static List<Account> accounts=new List<Account>();

        public static List<Transaction> transactions=new List<Transaction>();

        public static void Seed()
        {
            Account personal1 = new Account()
            {
                Id=1,
                accountNumber=100,
                curencyCode=(CurencyCode)0,
                ownerName="Yalın",
                accountType=(AccountType)0,
                balance=100,
            };
            Account personal2 = new Account()
            {
                Id = 2,
                accountNumber = 101,
                curencyCode = (CurencyCode)1,
                ownerName = "Yalın",
                accountType = (AccountType)0,
                balance = 100,
            };
            Account company1 = new Account()
            {
                Id = 3,
                accountNumber = 102,
                curencyCode = (CurencyCode)0,
                ownerName = "Company1",
                accountType = (AccountType)1,
                balance = 100,
            };

            accounts.Add(personal1);
            accounts.Add(personal2);
            accounts.Add(company1);
        }
    }
}
