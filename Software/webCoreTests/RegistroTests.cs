
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace webCoreTests
{
    [TestFixture]
    public class RegistroTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            // Inicializa ChromeDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestRegistroExitoso()
        {
            // Navegar a la página principal
            driver.Navigate().GoToUrl("https://webcore.zell.mx/");

            // Clic en el enlace de "Registrarse"
            wait.Until(d => d.FindElement(By.LinkText("Registrarse"))).Click();

            // Completar el formulario
            driver.FindElement(By.Id("Input_Email")).SendKeys("juan.test@example.com");
            driver.FindElement(By.Id("Input_Mobile")).SendKeys("5551234567");
            driver.FindElement(By.Id("Input_FirstName")).SendKeys("Juan");
            driver.FindElement(By.Id("Input_FirstLName")).SendKeys("Pérez");
            driver.FindElement(By.Id("Input_UserId")).SendKeys("juanperez123");
            driver.FindElement(By.Id("Input_Password")).SendKeys("MiPassword123");
            driver.FindElement(By.Id("Input_ConfirmPassword")).SendKeys("MiPassword123");

            // Enviar el formulario
            driver.FindElement(By.CssSelector(".btn-secondary"));

            // Verificar si se muestra la página de éxito
            if (driver.PageSource.Contains("Bienvenido") || driver.Url.Contains("confirm"))
            {
                Console.WriteLine("✅ Registro exitoso");
            }
            else
            {
                Console.WriteLine("❌ Registro fallido");
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Cerrar el navegador después de cada prueba
            driver.Quit();
        }
    }
}
