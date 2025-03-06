using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Model
{
    public class DetailsOfAccounts
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AadharNumber { get; set; }
        public string PanNumber { get; set; }
        public string AccountNumber { get ;  }

        public AccountMode AccountType { get; set; }    


        public DetailsOfAccounts(string firstname , string middlename , string lastname , string aadharnumber , string pannumber , string accountnumber , AccountMode accounttype) 
        {

            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            AadharNumber = aadharnumber;
            PanNumber = pannumber;
            AccountNumber = accountnumber;
            AccountType = accounttype;

        }


    }
}
