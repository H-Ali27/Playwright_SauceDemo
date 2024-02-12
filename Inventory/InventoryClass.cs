using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTest
{
    public class InventoryClass : Baseclass
    {
        public async Task Inventory(IPage page)
        {
            ChildLog("Inventory");
            await Click(page, "#inventory_container > div > div:nth-child(1) > div.pricebar > button", "product 1");
            await Click(page, "#inventory_container > div > div:nth-child(2) > div.pricebar > button", "product 2");
            await Click(page, "#inventory_container > div > div:nth-child(6) > div.pricebar > button", "product 3");
            await Select(page, "#inventory_filter_container > select", "Name (Z to A)","Sorting");
            await Click(page, "#shopping_cart_container > a > svg > path","Cart Icon Click");
        }
    }
}
