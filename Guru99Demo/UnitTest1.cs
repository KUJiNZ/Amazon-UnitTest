namespace Guru99Demo
{
        class UnitTest1
        {
            IWebDriver driver = new ChromeDriver();

            [SetUp]
            public void startBrowser()
            {
                driver = new ChromeDriver("D:\\Drivers");
            }

            [Test]
            public void test()
            {
                driver.Url = "http://www.google.co.in";
            }

            [TearDown]
            public void closeBrowser()
            {
                driver.Close();
            }

        }
}