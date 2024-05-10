using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting_Uygulaması
{
    public class Categories
    {
        public Categories(int categoryID, string categoryName, int categoryVote)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            CategoryVote = categoryVote;
        }
        public Categories(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CategoryVote { get; set; }
    }
}
