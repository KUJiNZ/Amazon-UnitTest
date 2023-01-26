
using System.Xml.Linq;

namespace UnitTest
{
    public  class SearchBar
    {
        private IWebDriver driver;
        private IWebElement SearchBarComponent;
        public SearchBar(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Click()
        {
            //SearchBarComponent = this.driver.FindElement(By.Id("nav - search - submit - button"));
            //SearchBarComponent.Click();
            SearchBarComponent.Submit();
        }


        public string Text
        {
            set
            {
                SearchBarComponent = driver.FindElement(By.Id("twotabsearchtextbox"));
                SearchBarComponent.SendKeys(value);
            }

        }
    }
}
