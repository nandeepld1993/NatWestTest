using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;
using System.Collections.Generic;
using System;
using System.IO;

public class TestBase : IAsyncLifetime
{
    protected IPlaywright _playwright;
    protected IBrowser _browser;
    protected IPage _page;

    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        _page = await _browser.NewPageAsync();
        _page.SetDefaultTimeout(600000);
    }

    public async Task DisposeAsync()
    {
        await _page.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    public Dictionary<string, string> ReadCsvFile(string filename, string testcase)
    {
        Dictionary<string, string> rows = new Dictionary<string, string>();
        try
        {
            string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\TestData\\"+filename;
            string[] lines = File.ReadAllLines(filePath);
            bool isRowExists = false;
            for (int i = 1; i < lines.Length; i++)
            {
                var cells = lines[i].Split(',');
                var header = lines[0].Split(',');
                if (cells[0].Equals("Testcase1"))
                {
                    isRowExists = true;
                    for (int j = 1; j < cells.Length; j++)
                    {
                        rows.Add(header[j],cells[j]);
                    }
                    break;
                }
            }
            if(isRowExists)
                Console.WriteLine(testcase+" Testcase data found");
            else
                Console.WriteLine(testcase+" Testcase data not found");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return rows;
    }
}
