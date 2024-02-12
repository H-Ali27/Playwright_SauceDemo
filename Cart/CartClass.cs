using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTest
{
    public class CartClass : Baseclass
    {
        public async Task Cart(IPage page)
        {
            ChildLog("checkout Overview");
            //remove a product from cart
            await Click(page,"#cart_contents_container > div > div.cart_list > div:nth-child(5) > div.cart_item_label > div.item_pricebar > button", "remove a product");
           //click a check out button
            await Click(page, "#cart_contents_container > div > div.cart_footer > a.btn_action.checkout_button", "checkout");
        }
    }
}
