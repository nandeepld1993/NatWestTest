using Xunit;
using System.Threading.Tasks;
using AutomationTests.PageControls;
using AutomationTests.FunctionLibrary;

namespace AutomationTests.Tests;

public class ElementsPageTest:TestBase
{
    private readonly string _url = "https://demoqa.com/automation-practice-form";

    [Fact]
    [Trait("Category", "UI")]
    public async Task Verify_Text_Box_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.TabElements), "Tab elements should be visible");
        var elementsPageFunctions = new ElementsPageFunctions(_page); 
        await elementsPageFunctions.NavigateToTextBoxControlPage();
        await elementsPageFunctions.EnterTextBoxData();
        await elementsPageFunctions.ClickSubmit();
        await elementsPageFunctions.ValidateEnteredTextBoxData();
    }
    
    [Fact]
    [Trait("Category", "UI")]
    public async Task Verify_Check_Box_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.TabElements), "Tab elements should be visible");
        var elementsPageFunctions = new ElementsPageFunctions(_page);
        await elementsPageFunctions.NavigateToCheckBoxControlPage();
        await elementsPageFunctions.ClickAndValidateCheckBoxField();
    }
    
    [Fact]
    [Trait("Category", "UI")]
    public async Task Verify_Radio_Button_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.TabElements), "Tab elements should be visible");
        var elementsPageFunctions = new ElementsPageFunctions(_page);
        await elementsPageFunctions.NavigateToRadioBtnControlPage();
        await elementsPageFunctions.ClickAndValidateRadioBtnField();
    }
    
    [Fact]
    [Trait("Category", "UI")]
    public async Task Verify_Button_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.TabElements), "Tab elements should be visible");
        var elementsPageFunctions = new ElementsPageFunctions(_page);
        await elementsPageFunctions.NavigateToButtonControlPage();
        await elementsPageFunctions.ClickAndValidateBtnField();
    }
    
    [Fact]
    [Trait("Category", "UI")]
    public async Task Verify_Link_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.TabElements), "Tab elements should be visible");
        var elementsPageFunctions = new ElementsPageFunctions(_page);
        await elementsPageFunctions.NavigateToLinksControlPage();
        await elementsPageFunctions.ValidateLinksField();
    }
}