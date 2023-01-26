using System.Diagnostics;

namespace UnitTest
{
    public class Item
    {
        public string title;
        public string link;
        public string price;
        public string shipping;

        public Item(string title,string link,string price, string shipping) 
        {  
            this.title = title;
            this.link = link;
            this.price = price;
            this.shipping = shipping;
        }
    }
}
