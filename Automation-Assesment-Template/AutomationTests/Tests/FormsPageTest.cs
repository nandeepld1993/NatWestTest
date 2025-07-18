using Xunit;
using System.Threading.Tasks;
using AutomationTests.PageControls;
using AutomationTests.FunctionLibrary;

namespace AutomationTests.Tests;

public class FormsPageTest: TestBase
{
    [Fact]
    public async Task Verify_Form_Page_Controls()
    {
        await _page.GotoAsync("https://demoqa.com/automation-practice-form");
        Assert.True(await _page.IsVisibleAsync(FormsPageControl.TabForms), "Tab elements should be visible");
        var formsPageFunctions = new FormPageFunctions(_page); 
        await formsPageFunctions.NavigateToFormPage();
        var readFormData = ReadCsvFile("FormTestData.csv", "Testcase1");
        await formsPageFunctions.EnterDateIntoFormPage(readFormData);
        await formsPageFunctions.ClickSubmit();
        await formsPageFunctions.ValidateEnteredFormPageData(readFormData);
    }
}