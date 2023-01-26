
using System;

namespace UnitTest
{
        class UnitTest1
        {
            public string URL = "https://www.amazon.com";
            BrowserFactory bf;


            [SetUp]
                public void Start()
                {
                    //AmazonTest Amazon = new AmazonTest("Chrome", URL);
                }

            [Test]
                public void test()
                {
                    var dict = new Dictionary<string, string>()
                    {
                        {"Price_Lower_Then","100"},
                        {"Price_Hiegher_OR_Equal_Then","5"},
                        {"Free_Shipping","true"}
                    };

                    bf = new BrowserFactory();
                    bf.InitBrowser("Chrome");
                    IWebDriver driver = bf.drivers["CHROME"];
                    driver.Navigate().GoToUrl(URL);

                    Amazon Amazon = new Amazon(driver);
                    Amazon.Pages.Home.SearchBar.Text="Mouse";
                    Amazon.Pages.Home.SearchBar.Click();

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