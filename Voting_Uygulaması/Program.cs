namespace Voting_Uygulaması
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Transactions transactions = new Transactions();
            Console.WriteLine("Lütfen kullanıcı adınızı giriniz");
            string userName = Console.ReadLine();
            Console.WriteLine("Lütfen şifrenizi giriniz");
            string password = Console.ReadLine();
            transactions.Login(userName,password);
            transactions.Results();
        }
    }
}
