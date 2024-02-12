using AventStack.ExtentReports;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace PlaywrightTest
{
    [TestFixture]
    [AllureNUnit]
    public class MainClass : PageTest
    {
        LoginClass login = new LoginClass();
        InventoryClass inventory = new InventoryClass(); 
        CartClass cart = new CartClass();
        CheckoutClass checkout = new CheckoutClass();
        ExtentReport extent = new ExtentReport();   
        [SetUp]
        public async Task Setup()
        {
            extent.LogReport("Playwright Flowtest of Swaglabs website");
            extent.ParentLog(NUnit.Framework.TestContext.CurrentContext.Test.Name);
            ContextOptions();

            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }
        [TearDown]
        public async Task Teardown()
        {
            Thread.Sleep(3000);
            // Stop tracing and export it into a zip archive.
            await Context.Tracing.StopAsync(new()
            {
                Path = @"trace/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString() + ".zip"
            });

            await Context.CloseAsync();
            await Browser.CloseAsync();

            extent.flush();
        }
        [AllureStep]
        [Test]
        public async Task SauceDemo_ValidCred()
        {
            //in which format you want report
            await login.Login(Page,"standard_user","secret_sauce");
            await inventory.Inventory(Page);
            Thread.Sleep(2000);
            await cart.Cart(Page);
            await checkout.Checkout(Page, "Jack", "jones", "23432");
            Thread.Sleep(3000);
        }
        [Test]
        public async Task SouceDemo_InvalidCred()
        {
            await login.Login(Page, "Standard", "secret_sauce");
        }
        public override BrowserNewContextOptions ContextOptions()
        {
            return new BrowserNewContextOptions()
            {
                RecordVideoDir = @"videos/" + TestContext.CurrentContext.Test.MethodName + "_" + DateTime.Now.ToString("yyyymmddhhmmss").ToString(),
                //StorageStatePath = @"state\pagetest_state.json",
                ViewportSize = new ViewportSize
                {
                    Height = 780,
                    Width = 1380
                },
                RecordVideoSize = new RecordVideoSize
                {
                    Height = 780,
                    Width = 1380
                }
            };

        }
    }
}