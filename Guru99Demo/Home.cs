

namespace UnitTest
{
    public class Home
    {
        private IWebDriver driver;
        private SearchBar searchBar;
        

        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }

        public SearchBar SearchBar
        {
            get
            {
                if (searchBar == null)
                    searchBar = new SearchBar(this.driver);
                return searchBar;
            }
            
        }
    }
}
