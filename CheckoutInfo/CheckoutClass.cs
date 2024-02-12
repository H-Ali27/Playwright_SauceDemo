using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTest
{
    public class CheckoutClass : Baseclass
    {
        public async Task Checkout(IPage page,string Fname, string Lname, string Pcode)
        {
            ChildLog("Checkout Information");
            await WriteText(page, "#first-name", Fname, "First name");
            await WriteText(page, "#last-name", Lname, "Last name");
            await WriteText(page, "#postal-code", Pcode, "Zip code");
            await Click(page, "#checkout_info_container > div > form > div.checkout_buttons > input","Continue");
            //Checkout Overview Page: Finish Button
            await Click(page, "#checkout_summary_container > div > div.summary_info > div.cart_footer > a.btn_action.cart_button", "Finish Button");
            //Finixh Page: trying to check Assertion
            //await Expect(page.GetByText("Hidden text")).ToBeAttachedAsync();
        }
    }
}
