namespace UnitTest
{
    public class BrowserFactory
    {
        public  IDictionary<string, IWebDriver> drivers = new Dictionary<string, IWebDriver>();
      
        public  void InitBrowser(string browserName)
        {

            switch (browserName.ToUpper())
            {
                case "CHROME":
                    if (!drivers.ContainsKey("CHROME"))
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("start-maximized");

                        IWebDriver driver = new ChromeDriver("D:\\WebDrivers\\Chrome");
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                        drivers.Add("CHROME", driver);
                    }
                    break;

                case "FIREFOX":
                    if (!drivers.ContainsKey("FIREFOX"))
                    {
                        FirefoxOptions options = new FirefoxOptions(); ;
                        options.AddArgument("start-maximazed");

                        IWebDriver driver = new FirefoxDriver("C:\\Users\\deade\\AppData\\Local\\Mozilla Firefox");
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


                        drivers.Add("FIREFOX", driver);
                    }
                    break;

                case "IE":
                    if (drivers.ContainsKey("IE"))
                    {
                        InternetExplorerOptions options = new InternetExplorerOptions(); ; ;

                        IWebDriver driver = new InternetExplorerDriver("D:\\WebDrivers\\IE", options);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                        drivers.Add("IE", driver);
                    }
                    break;
            }
        }

        public void LoadApplication(string browserName,string url)
        {
            drivers[browserName].Url= url;
        }

        public void CloseAllDrivers()
        {
            foreach (var key in drivers.Keys)
            {
                drivers[key].Close();
                drivers[key].Quit();
            }
        }
    }
}

