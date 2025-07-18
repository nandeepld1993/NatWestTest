using System.Collections;
using System.Collections.Generic;
using Xunit;
using System.Threading.Tasks;
using AutomationTests.PageControls;
using Microsoft.Playwright;

namespace AutomationTests.FunctionLibrary;

public class FormPageFunctions
{
    private readonly IPage _page;

    public FormPageFunctions(IPage page)
    {
        _page = page;
    }
    
    public async Task NavigateToFormPage()
    {
        await _page.ClickAsync(FormsPageControl.TabForms);
        Assert.True(await _page.IsVisibleAsync(FormsPageControl.ListPracticeForm), "List practice form should be visible");
        await _page.ClickAsync(FormsPageControl.ListPracticeForm);
        Assert.True(await _page.IsVisibleAsync(FormsPageControl.InputFirstName), "First name should be visible");
    }
    
    public async Task EnterDateIntoFormPage(Dictionary<string, string> data)
    {
        await _page.FillAsync(FormsPageControl.InputFirstName, data["FirstName"]);
        await _page.FillAsync(FormsPageControl.InputLastName, data["LastName"]);
        await _page.FillAsync(FormsPageControl.InputEmail, data["Email"]);
        await _page.Locator("//label[text()='"+data["Gender"]+"']").ClickAsync();
        await _page.FillAsync(FormsPageControl.InputMobileNumber, data["Mobile"]);
        await _page.FillAsync(FormsPageControl.InputBirthDate, data["DateOfBirth"]);
        await Select_Subjects(data["Subjects"]);
        await Select_Hobbies(data["Hobbies"]);
        await _page.Locator(FormsPageControl.InputUploadPicture).SetInputFilesAsync(data["FilePath"]);
        await _page.FillAsync(ElementsPageControl.InputCurrentAddress, data["Address"]);
        await _page.ClickAsync(FormsPageControl.DropdownState);
        await _page.Locator("//div[text()='"+data["State"]+"']").ClickAsync();
        await _page.ClickAsync(FormsPageControl.DropdownCity);
        await _page.Locator("//div[text()='"+data["City"]+"']").ClickAsync();
    }
    
    public async Task ValidateEnteredFormPageData(Dictionary<string, string> data)
    {
        ArrayList actFormPageValue = new ArrayList();
        var allRows = await _page.Locator(FormsPageControl.TableTextForm).AllAsync();
        foreach (var row in allRows)
        {
            string actCellValue= await row.InnerTextAsync();
            if(actCellValue.Contains(','))
                foreach (string cellValue in actCellValue.Split(','))
                    actFormPageValue.Add(cellValue);
            else
                foreach (string cellValue in actCellValue.Split(' '))
                    actFormPageValue.Add(cellValue);
        }
        Assert.True(data["FirstName"].Equals(actFormPageValue[0]));
        Assert.True(data["LastName"].Equals(actFormPageValue[1]));
        Assert.True(data["Email"].Equals(actFormPageValue[2]));
        Assert.True(data["Gender"].Equals(actFormPageValue[3]));
        Assert.True(data["Mobile"].Equals(actFormPageValue[4]));
    }
    
    public async Task ClickSubmit()
    {
        Assert.True(await _page.IsVisibleAsync(ElementsPageControl.BtnSubmit), "Submit button should be visible");
        await _page.ClickAsync(ElementsPageControl.BtnSubmit);
    }
    
    private async Task Select_Subjects(string subjects)
    {
        var actSubjects = subjects.Split(";");
        foreach (var subject in actSubjects)
        {
            await _page.FillAsync(FormsPageControl.InputSubject, subject);
            await _page.PressAsync(FormsPageControl.InputSubject,"Enter");
        }
    }
    
    private async Task Select_Hobbies(string hobbies)
    {
        var actHobbies = hobbies.Split(";");
        foreach (var hobby in actHobbies)
        {
            await _page.Locator("//label[text()='" + hobby + "']").ClickAsync();
        }
    }
}