using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        driver.Navigate().GoToUrl("https://webcore.zell.mx/");
        driver.Manage().Window.Maximize();

        // Clic en "Registrarse"
        wait.Until(d => d.FindElement(By.LinkText("Registrarse"))).Click();

        // Completar el formulario
        driver.FindElement(By.Id("Input_Email")).SendKeys("juan.test@example.com");
        driver.FindElement(By.Id("Input_Mobile")).SendKeys("5551234567");
        driver.FindElement(By.Id("Input_FirstName")).SendKeys("Juan");
        driver.FindElement(By.Id("Input_FirstLName")).SendKeys("Pérez");
        driver.FindElement(By.Id("Input_UserId")).SendKeys("juanperez123");
        driver.FindElement(By.Id("Input_Password")).SendKeys("MiPassword123");
        driver.FindElement(By.Id("Input_ConfirmPassword")).SendKeys("MiPassword123");


        driver.FindElement(By.CssSelector(".btn-secondary"));


        // Verificación básica
        if (driver.PageSource.Contains("Bienvenido") || driver.Url.Contains("confirm"))
        {
            Console.WriteLine("✅ Registro exitoso");
        }
        else
        {
            Console.WriteLine("❌ Registro fallido");
        }

        driver.Quit();
    }
}
