using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hm14_filesystem
{
    internal class DataManager
    {
        private const string DataFilePath = "creditcards.json";

        public void SaveCreditCards(List<CreditCard> creditCards)
        {
            string json = JsonConvert.SerializeObject(creditCards, Formatting.Indented);
            File.WriteAllText(DataFilePath, json);
        }

        public List<CreditCard> LoadCreditCards()
        {
            List<CreditCard> creditCards = new List<CreditCard>();

            if (File.Exists(DataFilePath))
            {
                string json = File.ReadAllText(DataFilePath);
                creditCards = JsonConvert.DeserializeObject<List<CreditCard>>(json);
            }

            return creditCards;
        }
    }
}
