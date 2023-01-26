
namespace UnitTest
{
    public class Amazon
    {
        private Pages pages;
        private IWebDriver BrowserDriver;




        public Amazon(IWebDriver BrowserDriver)
        {
            this.BrowserDriver = BrowserDriver;
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
