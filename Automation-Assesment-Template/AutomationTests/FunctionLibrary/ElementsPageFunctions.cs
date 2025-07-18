using Xunit;
using System.Threading.Tasks;
using AutomationTests.PageControls;
using AutomationTests.TestData;
using Microsoft.Playwright;

namespace AutomationTests.FunctionLibrary;

public class ElementsPageFunctions
{
    private readonly IPage _page;

    public ElementsPageFunctions(IPage page)
    {
        _page = page;
    }
    
    public async Task NavigateToTextBoxControlPage()
    {
        await _page.ClickAsync(ElementsPageControl.TabElements);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.ListTextBox), "List textBox should be visible");
        await _page.ClickAsync(ElementsPageControl.ListTextBox);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.InputFullName), "Full name should be visible");
    }
    
    public async Task EnterTextBoxData()
    {
        await _page.FillAsync(ElementsPageControl.InputFullName, ElementsPageData.TextBoxData["Full Name"]);
        await _page.FillAsync(ElementsPageControl.InputEmail, ElementsPageData.TextBoxData["Email"]);
        await _page.FillAsync(ElementsPageControl.InputCurrentAddress, ElementsPageData.TextBoxData["Current Address"]);
        await _page.FillAsync(ElementsPageControl.InputPermanentAddress, ElementsPageData.TextBoxData["Permanent Address"]);
    }

    public async Task ClickSubmit()
    {
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.BtnSubmit), "Submit button should be visible");
        await _page.ClickAsync(ElementsPageControl.BtnSubmit);
    }

    public async Task ValidateEnteredTextBoxData()
    {
        var actName = await _page.InnerTextAsync(ElementsPageControl.TextName);
        Assert.EndsWith(ElementsPageData.TextBoxData["Full Name"], actName);
        var actEmail = await _page.InnerTextAsync(ElementsPageControl.TextEmail);
        Assert.EndsWith(ElementsPageData.TextBoxData["Email"], actEmail);
        var actCurrentAddress = await _page.InnerTextAsync(ElementsPageControl.TextCurrentAddress);
        Assert.EndsWith(ElementsPageData.TextBoxData["Current Address"], actCurrentAddress);
        var actPermanentAddress = await _page.InnerTextAsync(ElementsPageControl.TextPermanentAddress);
        Assert.EndsWith(ElementsPageData.TextBoxData["Permanent Address"], actPermanentAddress);
    }
    
    public async Task NavigateToCheckBoxControlPage()
    {
        await _page.ClickAsync(ElementsPageControl.TabElements);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.ListCheckBox), "List checkbox should be visible");
        await _page.ClickAsync(ElementsPageControl.ListCheckBox);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.CheckBoxHome), "Home checkbox should be visible");
    }

    public async Task ClickAndValidateCheckBoxField()
    {
        await _page.ClickAsync(ElementsPageControl.CheckBoxHome);
        Assert.True(await _page.IsCheckedAsync(ElementsPageControl.CheckBoxHome));
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.BtnExpandAll), "Expand all should be visible");
        await _page.ClickAsync(ElementsPageControl.BtnExpandAll);
        var allchecked = await _page.Locator(ElementsPageControl.CheckBoxAll).AllAsync();
        foreach (var check in allchecked)
        {
            Assert.True(await check.IsCheckedAsync(), "Control checkbox should be checked");
        }
        
        await _page.ClickAsync(ElementsPageControl.CheckBoxHome);
        Assert.False(await _page.IsCheckedAsync(ElementsPageControl.CheckBoxHome));
        var allunchecked = await _page.Locator(ElementsPageControl.CheckBoxAll).AllAsync();
        foreach (var uncheck in allunchecked)
        {
            Assert.False(await uncheck.IsCheckedAsync(), "Control checkbox should be unchecked");
        }
    }
    
    public async Task NavigateToRadioBtnControlPage()
    {
        await _page.ClickAsync(ElementsPageControl.TabElements);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.ListRadioButton), "List Radio Button should be visible");
        await _page.ClickAsync(ElementsPageControl.ListRadioButton);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.RadBtnYes), "Yes Radio button should be visible");
    }

    public async Task ClickAndValidateRadioBtnField()
    {
        await _page.ClickAsync(ElementsPageControl.RadBtnYes);
        Assert.True(await _page.IsCheckedAsync(ElementsPageControl.RadBtnYes));
        Assert.Equal("Yes", await _page.InnerTextAsync(ElementsPageControl.TextSelectedRadBtn));
        Assert.False(await _page.IsCheckedAsync(ElementsPageControl.RadBtnImpress));
        Assert.True(await _page.IsDisabledAsync(ElementsPageControl.RadBtnNo));
        
        Assert.True(await _page.IsEnabledAsync(ElementsPageControl.RadBtnImpress), "Impressive Radio button should be enable");
        await _page.ClickAsync(ElementsPageControl.RadBtnImpress);
        Assert.True(await _page.IsCheckedAsync(ElementsPageControl.RadBtnImpress));
        Assert.Equal("Impressive", await _page.InnerTextAsync(ElementsPageControl.TextSelectedRadBtn));
        Assert.False(await _page.IsCheckedAsync(ElementsPageControl.RadBtnYes));
        Assert.True(await _page.IsDisabledAsync(ElementsPageControl.RadBtnNo));
    }
    
    public async Task NavigateToButtonControlPage()
    {
        await _page.ClickAsync(ElementsPageControl.TabElements);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.ListButton), "List checkbox should be visible");
        await _page.ClickAsync(ElementsPageControl.ListButton);
        Assert.True(await _page.IsEnabledAsync(ElementsPageControl.BtnDoubleClick), "Double click button should be enable");
    }

    public async Task ClickAndValidateBtnField()
    {
        await _page.DblClickAsync(ElementsPageControl.BtnDoubleClick);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.TextDoubleClick), "Double click text should be visible");
        
        Assert.True(await _page.IsEnabledAsync(ElementsPageControl.BtnClick), "click button should be enable");
        await _page.ClickAsync(ElementsPageControl.BtnClick);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.TextDynamicClick), "click button text should be visible");
        
        Assert.True(await _page.IsEnabledAsync(ElementsPageControl.BtnRightClick), "Right click button should be enable");
        await _page.ClickAsync(ElementsPageControl.BtnRightClick, new PageClickOptions()
        {
            Button = MouseButton.Right
        });
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.TextRightClick), "Right click button text should be visible");
    }
    
    public async Task NavigateToLinksControlPage()
    {
        await _page.ClickAsync(ElementsPageControl.TabElements);
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.ListLinks), "List link should be visible");
        await _page.ClickAsync(ElementsPageControl.ListLinks);
    }

    public async Task ValidateLinksField()
    {
        var allLinks = await _page.Locator(ElementsPageControl.LinksAll).AllAsync();
        foreach (var link in allLinks)
        {
            var actLinkText = await link.InnerTextAsync();
            var actAttributeValue = await link.GetAttributeAsync("href");
            if (actAttributeValue.ToString().Equals("javascript:void(0)"))
            {
                await link.ClickAsync();
                await _page.WaitForTimeoutAsync(1000);
                var fullLinkText = await _page.InnerTextAsync(ElementsPageControl.TextLinkResponse);
                Assert.Contains(actLinkText.ToString().Trim(), fullLinkText.ToString());
            }
        }
    }
}