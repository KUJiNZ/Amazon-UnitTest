
using System.Xml.Linq;

namespace UnitTest
{
    
    public class Results
    {
        private IWebDriver driver;
        private List<Item> items = new List<Item>();

        public string BaseDiv = "//ancestor::div[@class = 'sg-col sg-col-4-of-12 sg-col-8-of-16 sg-col-12-of-20 s-list-col-right']";
        public string xPath = "//div[@class = 'sg-col sg-col-4-of-12 sg-col-8-of-16 sg-col-12-of-20 s-list-col-right' ";

        private string title_to_set = "//descendant::span[@class = 'a-size-medium a-color-base a-text-normal']";
        private string link_to_set = "//descendant::a[@class='a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']";
        private string price_to_set = "//descendant::span[@class='a-price'][1]";
        private string shipping_to_set = "//descendant::div[@class = 'a-row a-size-base a-color-secondary s-align-children-center']//descendant::span[@class = 'a-color-base a-text-bold']/.";

        public Results(IWebDriver driver)
        {
            this.driver = driver;
        }

        public List<Item> GetResultsBy(Dictionary<string,string> dict)
        {

            Filter(dict);

            var elements = driver.FindElements(By.XPath(xPath));
            foreach (var element in elements)
            {


                var title = element.FindElement(By.XPath("." + BaseDiv + title_to_set)).Text;
                var link = element.FindElement(By.XPath("." + BaseDiv + link_to_set)).GetAttribute("href");
                var price = element.FindElement(By.XPath("." + BaseDiv + price_to_set)).Text;
                price = price.Replace("\n", ".").Replace("\r", "");
                var shipping = element.FindElement(By.XPath("." + BaseDiv + shipping_to_set)).Text;

                items.Add(new Item(title, link, price, shipping));  
            }
 
            return items;
        }
        public void Filter(IDictionary<string, string> dict)
        {
            foreach (var element in dict)
            {
                switch (element.Key) 
                {
                    case "Price_Lower_Then":
                        xPath += $" and descendant::span[@class='a-offscreen' and translate(text(),'$,','') < {element.Value}]";
                        break;

                    case "Price_Hiegher_OR_Equal_Then":
                        xPath += $" and descendant::span[@class='a-offscreen' and translate(text(),'$,','') >= {element.Value}]";
                        break;
                        
                    case "Free_Shipping":
                        if (element.Value.Equals("true") )
                                xPath += $" and descendant::span[@class = 'a-color-base a-text-bold' and contains(text(),'FREE Shipping')]";
                        else
                                xPath += $" and not(descendant::span[@class = 'a-color-base a-text-bold' and contains(text(),'FREE Shipping')]";
                        break;

                    default: 
                        break;

                }
            }
            xPath += "]";

            
        }

    }
}
