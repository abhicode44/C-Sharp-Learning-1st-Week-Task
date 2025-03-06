using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BankApp.Model;

namespace BankApp.Services
{
    internal class DataSerialization
    {
        public void Serialize (List<DetailsOfAccounts> detailsOfAccounts)
        {
            string fileName = "Account.json";

            string jsonString ;
            jsonString = JsonSerializer.Serialize(detailsOfAccounts);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine(" Serialization Completed ");

        }


        public List<DetailsOfAccounts> DeSerializer()
        {
            string fileName = "Account.json";
            List<DetailsOfAccounts> account_deserilize = new List<DetailsOfAccounts>();
            string jsonString;
            if (File.Exists(fileName))
            {
                jsonString = File.ReadAllText(fileName);
                account_deserilize = JsonSerializer.Deserialize<List<DetailsOfAccounts>>(jsonString);
            }
            return account_deserilize;
        }

    }
}
