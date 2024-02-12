using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlaywrightTest
{
    public class LoginClass : Baseclass
    {
        public async Task Login(IPage page, string user, string pass)
        {
            ChildLog("Login");
            await page.GotoAsync("https://www.saucedemo.com/v1/index.html");
            await WriteText(page,"#user-name", user,"username");
            await WriteText(page, "#password", pass, "password");
            await Click(page,"#login-button","login button");
            //await Expect(page.Locator(".status")).ToHaveTextAsync("Submitted");
        }
    }
}
