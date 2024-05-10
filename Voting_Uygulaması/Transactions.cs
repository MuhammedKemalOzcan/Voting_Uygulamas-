using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Voting_Uygulaması
{
    internal class Transactions
    {
        public static List<Categories> category = new List<Categories>();
        public static List<User> users = new List<User>();
        public Categories currentCategory;
        private User user;
        private bool isLoggedIn = false;
        public Transactions() 
        {
            category.Add(new Categories(1, "Basketball", 0));
            category.Add(new Categories(2, "Football", 0));
            category.Add(new Categories(3, "Volleyball", 0));

            users.Add(new User("Ali", "123456"));
            users.Add(new User("Veli", "123456"));
            users.Add(new User("Muhammed", "123456"));

        }
        public void Login(string userName,string password)
        {
            user = users.Find(usr => usr.UserName.ToLower() == userName && usr.Password == password);
            if (user == null)
            {
                Console.WriteLine("Oy vermek için önce kayıt olmanız gerekmektedir.");
                Register(userName,password);
                Vote();
            }
            else if (userName == user.UserName.ToLower() && password == user.Password)
            {
                Console.WriteLine($"{user.UserName} Hoşgeldiniz.");
                isLoggedIn = true;
                Vote();
            }
        }
        public void Register(string usr,string psw)
        {
            
            Console.WriteLine("Lütfen Kullanıcı adınızı giriniz");
            usr = Console.ReadLine();
            Console.WriteLine("Lütfen şifrenizi giriniz");
            psw = Console.ReadLine();
            users.Add(new User(usr,psw));
            isLoggedIn = true;
        }
        public void Vote()
        {
            if (isLoggedIn == true)
            {
                Console.WriteLine("1.Basketball\n2.Football\n3.Volleyball");
                Console.WriteLine("Oy vermek istediğiniz kategorinin ID'sini giriniz:");
                int choice = Convert.ToInt32(Console.ReadLine());
                foreach (Categories c in category)
                {
                    if (choice == c.CategoryID)
                    {
                        c.CategoryVote++;
                    }
                }
            }
        }
        public void Results()
        {
            Console.WriteLine("Oylama sonuçları");
            int totalVotes = 0;
            foreach (Categories categories in category)
            {
                totalVotes += categories.CategoryVote;
            }
            Console.WriteLine("Kategori\t\t\t Oy Sayısı\t\t Oy oranı");
            foreach (Categories categories in category)
            {
                double votePercentage = (categories.CategoryVote / totalVotes) * 100;
                Console.WriteLine($"{categories.CategoryName}\t\t\t {categories.CategoryVote}\t\t\t {votePercentage}%");
            }
            Console.WriteLine("program sonlandı çıkmak için enter tuşuna basınız");
            Console.ReadLine();
        }
    }
}
