using hm14_filesystem;

DataManager dataManager = new DataManager();

CreditCard creditCard = new CreditCard("4367 5678 9012 8787", "John Doe", "12/25", "1111", 1000, 1000);

List<CreditCard> creditCards = new List<CreditCard>();
creditCards.Add(creditCard);

CardOwner cardOwner = new CardOwner(creditCard);

Console.WriteLine(creditCard);
Console.WriteLine("--------------------------------");

creditCard.Deposit(500);
creditCard.Withdraw(1700);
creditCard.ChangePIN("0990");
Console.WriteLine("--------------------------------");

Console.WriteLine(creditCard);
Console.WriteLine("--------------------------------");

dataManager.SaveCreditCards(creditCards);

List<CreditCard> loadedCreditCards = dataManager.LoadCreditCards();

foreach (CreditCard loadedCard in loadedCreditCards)
{
    Console.WriteLine("Loaded from creditcards.json file:");
    Console.WriteLine(loadedCard);
}