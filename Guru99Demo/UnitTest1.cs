
using System;

namespace UnitTest
{
        class UnitTest1
        {

            IWebDriver driver;
            BrowserFactory bf;


            [SetUp]
                public void Start()
                {
                    //#WebDriver Init
                    bf = new BrowserFactory();
                    bf.InitBrowser("Chrome");
                    driver = bf.drivers["CHROME"];
                }

            [Test]
                public void test()
                {
                    //Filter of searching
                    var dict = new Dictionary<string, string>()
                    {
                        {"Price_Lower_Then","100"},
                        {"Price_Hiegher_OR_Equal_Then","5"},
                        {"Free_Shipping","true"}
                    };

                    
                    
                    //POM init
                    Amazon Amazon = new Amazon(driver);
                    Amazon.Pages.Home.SearchBar.Text="Mouse";
                    Amazon.Pages.Home.SearchBar.Click();
                    
                    //Result of items found
                    List<Item> items = Amazon.Pages.Results.GetResultsBy(dict);

                    foreach (var item in items)
                    {
            
                        Console.WriteLine("---------------------------------------------------------------------------------");
                        Console.WriteLine(item.title);
                        Console.WriteLine(item.link);
                        Console.WriteLine(item.price);
                        Console.WriteLine(item.shipping);
                        Console.WriteLine("---------------------------------------------------------------------------------");
                    }
                    
                    
                    Assert.IsTrue(items.Count() > 0);

        }




            [TearDown]
                public void closeBrowser()
                {
                    bf.CloseAllDrivers();
                }

       

        }
}