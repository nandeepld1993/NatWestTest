using Xunit;
using System.Threading.Tasks;
using AutomationTests.PageControls;
using AutomationTests.FunctionLibrary;

namespace AutomationTests.Tests;

public class AlertFrameWindowPageTest:TestBase
{
    private readonly string _url = "https://demoqa.com/automation-practice-form";
    
    [Fact]
    public async Task Verify_Frame_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.TabForms), "Tab elements should be visible");
        var framePageFunctions = new AlertFramePageFunctions(_page); 
        await framePageFunctions.NavigateToFrameControlPage();
        var parentFrame = _page.FrameLocator(AlertsFrameWindowsPageControl.ParentFrame);
        string actChildFrameText = await parentFrame.FrameLocator(AlertsFrameWindowsPageControl.ChildFrame).Locator(AlertsFrameWindowsPageControl.TextChildFrame).InnerTextAsync();
        Assert.Equal("Child Iframe", actChildFrameText);
        Assert.True(await _page.Locator(AlertsFrameWindowsPageControl.TextFrameHeader).IsVisibleAsync());
    }
    
    [Fact]
    public async Task Verify_Accept_Alert_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.TabForms), "Tab elements should be visible");
        var alertPageFunctions = new AlertFramePageFunctions(_page); 
        await alertPageFunctions.NavigateToAlertsControlPage();
        await alertPageFunctions.ValidateAcceptAlert();
    }
    
    [Fact]
    public async Task Verify_Dismiss_Alert_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.TabForms), "Tab elements should be visible");
        var alertPageFunctions = new AlertFramePageFunctions(_page); 
        await alertPageFunctions.NavigateToAlertsControlPage();
        await alertPageFunctions.ValidateDismissAlert();
    }
    
    [Fact]
    public async Task Verify_Alert_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.TabForms), "Tab elements should be visible");
        var alertPageFunctions = new AlertFramePageFunctions(_page); 
        await alertPageFunctions.NavigateToAlertsControlPage();
        await alertPageFunctions.ValidateSendKeyAcceptAlert();
    }

    [Fact]
    public async Task Verify_Window_Controls()
    {
        await _page.GotoAsync(_url);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.TabForms),
            "Tab elements should be visible");
        var alertWindowFunctions = new AlertFramePageFunctions(_page); 
        await alertWindowFunctions.NavigateToWindowControlPage();
        await alertWindowFunctions.ValidateHandlingNewTab();
        await alertWindowFunctions.ValidateHandlingNewWindow();
        await alertWindowFunctions.ValidateHandlingMsgWindow();

    }
}