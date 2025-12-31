using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class User
    {
        public string UserName { get; set; }

        // Unique customer identity (immutable)
        public string CIFNumber { get; private set; }

        // Linked by BankAccountManager
        public string AccountNumber { get; internal set; }

        public string AccountType { get; set; }
        public string UserAddress { get; set; }
        public string PhoneNumber { get; set; }

        // Compliance-controlled
        public bool IsKYCVerified { get; internal set; }

        public string NomineeDetails { get; set; }

        public User(
            string userName,
            string cifNumber,
            string accountType,
            string userAddress,
            string phoneNumber)
        {
            UserName = userName;
            CIFNumber = cifNumber;
            AccountType = accountType;
            UserAddress = userAddress;
            PhoneNumber = phoneNumber;
            IsKYCVerified = false;
        }
    }
}

