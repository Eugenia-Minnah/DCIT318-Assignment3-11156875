using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Management_System
{
    public class FinanceApp
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public void Run()
        {
            SavingsAccount account = new SavingsAccount("ACC123", 1000m);

            Transaction t1 = new Transaction(1, DateTime.Now, 150m, "Groceries");
            Transaction t2 = new Transaction(2, DateTime.Now, 300m, "Utilities");
            Transaction t3 = new Transaction(3, DateTime.Now, 250m, "Entertainment");

            ITransactionProcessor processor1 = new MobileMoneyProcessor();
            ITransactionProcessor processor2 = new BankTransferProcessor();
            ITransactionProcessor processor3 = new CryptoWalletProcessor();

            processor1.Process(t1);
            account.ApplyTransaction(t1);
            _transactions.Add(t1);

            processor2.Process(t2);
            account.ApplyTransaction(t2);
            _transactions.Add(t2);

            processor3.Process(t3);
            account.ApplyTransaction(t3);
            _transactions.Add(t3);

            Console.WriteLine("\nAll transactions processed.");
        }
    }
}
