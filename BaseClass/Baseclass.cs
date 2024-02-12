using AventStack.ExtentReports;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrightTest
{
    public class Baseclass : ExtentReport
    {
        AllureReport allure = new AllureReport();

        public static string report="allure";
        public async Task WriteText(IPage page, string locator, string text,string detail)
        {
            report.ToLower();
            if (report == "extent")
            {
                await page.FillAsync(locator,text);
                await TakeScreenshot(page, Status.Pass, detail);
            }
            else if (report == "allure")
            {
                await page.FillAsync(locator,text);
                await allure.TakeScreenshotAsync(page, detail);
            }
        }
        public async Task PressButton(IPage page, string locator, string text,string detail)
        {
            report.ToLower();
            if (report == "extent")
            {
                await page.PressAsync(locator, text);
                await TakeScreenshot(page, Status.Pass, detail);
            }
            else if (report == "allure")
            {
                await page.PressAsync(locator, text);
                await allure.TakeScreenshotAsync(page, detail);
            }
        }
        public async Task Click(IPage page,string locator,string detail)
        {
            report.ToLower();
            if (report == "extent")
            {
                await page.ClickAsync(locator);
                await TakeScreenshot(page, Status.Pass, detail);
            }
            else if (report == "allure")
            {
                await page.ClickAsync(locator);
                await allure.TakeScreenshotAsync(page, detail);
            }
        }
        public async Task Select(IPage page,string locator,string value, string detail)
        {
            report.ToLower();
            if (report == "extent")
            {
                await page.SelectOptionAsync(locator, value);
                await TakeScreenshot(page, Status.Pass, detail);
            }
            else if (report == "allure")
            {
                await page.SelectOptionAsync(locator, value);
                await allure.TakeScreenshotAsync(page, detail);
            }
        }
    }
}
