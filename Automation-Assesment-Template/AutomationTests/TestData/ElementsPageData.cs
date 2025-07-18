using System.Collections.Generic;

namespace AutomationTests.TestData;

public class ElementsPageData
{
    public static readonly Dictionary<string, string> TextBoxData = new Dictionary<string, string>
    {
        { "Full Name", "Test" },
        { "Email", "Test@gmail.com" },
        { "Current Address", "Test Current Address" },
        { "Permanent Address", "Test Permanent Address" },
    };
}