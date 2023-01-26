
using System.Xml.Linq;

namespace UnitTest
{
    
    public class Results
    {
        private IWebDriver driver;
        private List<Item> items = new List<Item>();

        public string BaseDiv = "//ancestor::div[@class = 'sg-col sg-col-4-of-12 sg-col-8-of-16 sg-col-12-of-20 s-list-col-right']";
        public string xPath = "//div[@class = 'sg-col sg-col-4-of-12 sg-col-8-of-16 sg-col-12-of-20 s-list-col-right']";

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
               
                
                var titles = element.FindElement(By.XPath("."+BaseDiv + title_to_set)).Text;
                var links = element.FindElement(By.XPath("."+BaseDiv + link_to_set)).GetAttribute("href");
                var prices = element.FindElement(By.XPath("." + BaseDiv + price_to_set)).Text;
                var shippings = element.FindElement(By.XPath("." + BaseDiv + shipping_to_set)).Text;

                items.Add(new Item(titles, links, prices, shippings));  
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
                        xPath += $"//descendant::span[@class='a-offscreen' and translate(text(),'$,','') < {element.Value}]";
                        break;

                    case "Price_Hiegher_OR_Equal_Then":
                        if (dict.Keys.Contains("Price_Lower_Then"))
                            xPath += $"[@class='a-offscreen' and translate(text(),'$,','') >= {element.Value}]";
                        else
                            xPath += $"//descendant::span[@class='a-offscreen' and translate(text(),'$,','') >= {element.Value}]";

                        break;
                        
                    case "Free_Shipping":
                        if (element.Value.Equals("true") )
                            if(dict.ContainsKey("Price_Lower_Then") || dict.ContainsKey("Price_Hiegher_OR_Equal_Then"))
                                xPath += $"{BaseDiv}//descendant::div[@class = 'a-row a-size-base a-color-secondary s-align-children-center']//span[@class = 'a-color-base a-text-bold' and contains(text(),'FREE Shipping')]";
                        else
                                xPath += $"//descendant::div[@class = 'a-row a-size-base a-color-secondary s-align-children-center']//span[@class = 'a-color-base a-text-bold' and contains(text(),'FREE Shipping')]";
                        break;

                    default: 
                        break;

                }
            }

            
        }

    }
}
