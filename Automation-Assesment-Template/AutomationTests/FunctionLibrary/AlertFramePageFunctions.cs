using Xunit;
using System.Threading.Tasks;
using AutomationTests.PageControls;
using Microsoft.Playwright;

namespace AutomationTests.FunctionLibrary;

public class AlertFramePageFunctions
{
    private readonly IPage _page;

    public AlertFramePageFunctions(IPage page)
    {
        _page = page;
    }
    
    public async Task NavigateToFrameControlPage()
    {
        await _page.ClickAsync(AlertsFrameWindowsPageControl.TabForms);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.ListNestFrames), "List Nested Frame should be visible");
        await _page.ClickAsync(AlertsFrameWindowsPageControl.ListNestFrames);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.TextFrameHeader), "Frame Header should be visible");
    }
    
    public async Task NavigateToAlertsControlPage()
    {
        await _page.ClickAsync(AlertsFrameWindowsPageControl.TabForms);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.ListAlerts), "List Alerts should be visible");
        await _page.ClickAsync(AlertsFrameWindowsPageControl.ListAlerts);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.BtnAlert), "Button alert should be visible");
    }
    
    public async Task NavigateToWindowControlPage()
    {
        await _page.ClickAsync(AlertsFrameWindowsPageControl.TabForms);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.ListBrowserWindow),
            "List Browser window should be visible");
        await _page.ClickAsync(AlertsFrameWindowsPageControl.ListBrowserWindow);
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.BtnTab), "Button Tab should be visible");
    }
    
    public async Task ValidateAcceptAlert()
    {
        _page.Dialog += async (_1, acceptDialog) =>
        {
            Assert.Equal("You clicked a button", acceptDialog.Message);
            // await _page.WaitForTimeoutAsync(3000);
            await acceptDialog.AcceptAsync();
        };
        await _page.ClickAsync(AlertsFrameWindowsPageControl.BtnAlert);
    }
    
    public async Task ValidateDismissAlert()
    {
        _page.Dialog += async (_2, dismissDialog) =>
        {
            await dismissDialog.DismissAsync();
        };
        await _page.ClickAsync(AlertsFrameWindowsPageControl.BtnConfirm);
        string actTextValue = await _page.Locator(AlertsFrameWindowsPageControl.TextConfirmResult).InnerTextAsync();
        Assert.Contains("Cancel", actTextValue);
    }
    
    public async Task ValidateSendKeyAcceptAlert()
    {
        _page.Dialog += async (_3, sendDialog) =>
        {
            await sendDialog.AcceptAsync("natwest");
        };
        await _page.ClickAsync(AlertsFrameWindowsPageControl.BtnPrompt);
        string actTextValue = await _page.Locator(AlertsFrameWindowsPageControl.TextPromptResult).InnerTextAsync();
        Assert.Contains("natwest", actTextValue);
    }

    public async Task ValidateHandlingNewTab()
    {
        var newTabWindow = await _page.Context.RunAndWaitForPageAsync(async () =>
        {
            await _page.Locator(AlertsFrameWindowsPageControl.BtnTab).ClickAsync();
        });
        await newTabWindow.WaitForLoadStateAsync();
        Assert.Equal("https://demoqa.com/sample", newTabWindow.Url);
        Assert.True(await newTabWindow.Locator(AlertsFrameWindowsPageControl.TextNewWindow).IsVisibleAsync());
        await newTabWindow.CloseAsync();
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.BtnTab), "Button Tab should be visible");
    }
    
    public async Task ValidateHandlingNewWindow()
    {
        var newWindow = await _page.Context.RunAndWaitForPageAsync(async () =>
        {
            await _page.Locator(AlertsFrameWindowsPageControl.BtnWindow).ClickAsync();
        });
        await newWindow.WaitForLoadStateAsync();
        Assert.Equal("https://demoqa.com/sample", newWindow.Url);
        Assert.True(await newWindow.Locator(AlertsFrameWindowsPageControl.TextNewWindow).IsVisibleAsync());
        await newWindow.CloseAsync(); 
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.BtnTab), "Button Tab should be visible");
    }
    
    public async Task ValidateHandlingMsgWindow()
    {
        var newMessageWindow = await _page.Context.RunAndWaitForPageAsync(async () =>
        {
            await _page.Locator(AlertsFrameWindowsPageControl.BtnMsgWindow).ClickAsync();
        });
        await newMessageWindow.WaitForLoadStateAsync();
        Assert.Equal("about:blank", newMessageWindow.Url);
        await newMessageWindow.CloseAsync(); 
        Assert.True(await _page.IsVisibleAsync(AlertsFrameWindowsPageControl.BtnTab), "Button Tab should be visible");
    }
}