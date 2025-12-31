using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class Bank
    {
       public string BankName { get; private set; }
       public string Email { get; set; }
       public string PhoneNumber { get; set; }

       // bank owns many branches 
       private readonly List<Branch> branches;


        public Bank(string bankName, string email, string phoneNumber)
         {
              BankName = bankName;
              Email = email;
              PhoneNumber = phoneNumber;
              branches = new List<Branch>();
        }

        // Add a branch to the bank
        internal void AddBranch(Branch branch)
        {
            if (branch == null)
                return;

            // Prevent duplicate IFSC
            if (GetBranchByIFSC(branch.IFSC) != null)
                return;

            branches.Add(branch);
        }

        // Find branch using IFSC
        internal Branch GetBranchByIFSC(string ifsc)
        {
            return branches.FirstOrDefault(b => b.IFSC == ifsc);
        }
    }
}
   