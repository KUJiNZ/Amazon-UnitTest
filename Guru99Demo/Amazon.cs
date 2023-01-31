
namespace UnitTest
{
    public class Amazon
    {
        private Pages pages;
        private IWebDriver BrowserDriver;
        private string URL = "https://www.amazon.com";




        public Amazon(IWebDriver BrowserDriver)
        {
            this.BrowserDriver = BrowserDriver;
            this.BrowserDriver.Navigate().GoToUrl(URL);
        }

        public Pages Pages 
        { 
            get 
            {
                if (this.pages == null)
                {
                    this.pages = new Pages(this.BrowserDriver);
                }
                return this.pages; 
            } 
        }   
    }

}
