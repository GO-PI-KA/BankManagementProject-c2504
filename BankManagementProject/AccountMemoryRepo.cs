using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace BankManagementProject
{
    public class AccountMemoryRepo : IAccountRepo
    {
        private static AccountMemoryRepo _instance;
        public ObservableCollection<AccountModel> accounts = new ObservableCollection<AccountModel>()
        {
            new AccountModel
            {
                AccNo = 1234,
                Name = "Anamika",
                Balance = 0,
                AccType = "savings",
                Email = "anamika@gmail.com",
                PhNo = "789456123",
                Address = "xxx street",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,


            },
            new AccountModel
            {
                AccNo = 4567,
                Name = "Paru",
                Balance = 0,
                AccType = "current",
                Email = "paru@gmail.com",
                PhNo = "4561233",
                Address = "yyy street",
                IsActive = true,
                InterestPercentage = "0",
                TransactionCount = 0,
                LastTransactionDate = DateTime.Now,


            }
        };
        public static AccountMemoryRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountMemoryRepo();
                }
                return _instance;
            }
        }

        public void Create(AccountModel accModel)
        {
            accounts.Add(accModel);
        }
        public void UpdateAccount(AccountModel accModel)
        {
            foreach (var ac in accounts)
            {
                if (ac.AccNo == accModel.AccNo)
                {
                    ac.Address = accModel.Address;
                }
            }
        }
        public ObservableCollection<AccountModel> ReadAllAccount()
        {
            return accounts;
        }
        public void DeleteAccount(AccountModel accModel)
        {

            foreach (var ac in accounts)
            {
                if (ac.AccNo == accModel.AccNo)
                {
                    ac.Address = accModel.Address;
                }
            }
        }

        public void Deposit(int acNo, int Amount)
        {

            var account = accounts.FirstOrDefault(a => a.AccNo == acNo);
            if (account != null)
            {
                account.Balance = account.Balance + Amount;
                account.LastTransactionDate = DateTime.Now;
                account.TransactionCount = account.TransactionCount + 1;

                MessageBox.Show(messageBoxText: $"Deposited Successfully to account {acNo}",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show(messageBoxText: $"Account Not Found , Please input valid account number",
                    caption: "Warning",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Warning);
                return;
            }

        }

        public void Withdraw(int acNo, int Amount)
        {
            var account = accounts.FirstOrDefault(a => a.AccNo == acNo);
            if (account != null)
            {
                if (account.Balance < Amount)
                {
                    MessageBox.Show(messageBoxText: $"Insufficient balance",
                   caption: "Warning",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Warning);
                    return;
                }
                account.Balance = account.Balance - Amount;
                account.LastTransactionDate = DateTime.Now;
                account.TransactionCount = account.TransactionCount + 1;

                MessageBox.Show(messageBoxText: $"Withdrawed Successfully from account {acNo}",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show(messageBoxText: $"Account Not Found , Please input valid account number",
                    caption: "Warning",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Warning);
                return;
            }
        }

        public void CalculateInterestAndUpdateBalance()
        {
            throw new NotImplementedException();
        }

        
    }
}