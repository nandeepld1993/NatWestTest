namespace AutomationTests.PageControls;

public class ElementsPageControl
{
    public static readonly string TabElements = "//div[text()='Elements']";
    public static readonly string ListTextBox = "//span[text()='Text Box']";
    public static readonly string InputFullName = "id=userName";
    public static readonly string InputEmail = "id=userEmail";
    public static readonly string InputCurrentAddress = "id=currentAddress";
    public static readonly string InputPermanentAddress = "id=permanentAddress";
    public static readonly string BtnSubmit = "id=submit";
    public static readonly string TextName = "id=name";
    public static readonly string TextEmail = "id=email";
    public static readonly string TextCurrentAddress = "//p[@id='currentAddress']";
    public static readonly string TextPermanentAddress = "//p[@id='permanentAddress']";
    
    public static readonly string ListCheckBox = "//span[text()='Check Box']";
    public static readonly string BtnExpandAll = "//button[@title='Expand all']";
    public static readonly string BtnCollapseAll = "//button[@title='Collapse all']";
    public static readonly string BtnToggle = "//button[@title='Toggle']";
    public static readonly string CheckBoxHome = "//input[@id='tree-node-home']//following-sibling::span";
    public static readonly string CheckBoxAll = "//span[@class='rct-checkbox']";
    
    public static readonly string ListRadioButton = "//span[text()='Radio Button']";
    public static readonly string RadBtnYes = "//label[text()='Yes']";
    public static readonly string RadBtnNo = "//label[text()='No']";
    public static readonly string RadBtnImpress = "//label[text()='Impressive']";
    public static readonly string TextSelectedRadBtn = "//span[@class='text-success']";
    
    public static readonly string ListWebTable = "//span[text()='Web Tables']";
    public static readonly string ListButton = "//span[text()='Buttons']";
    public static readonly string BtnDoubleClick = "id=doubleClickBtn";
    public static readonly string BtnRightClick = "id=rightClickBtn";
    public static readonly string BtnClick = "//button[text()='Click Me']";
    public static readonly string TextDoubleClick = "//p[text()='You have done a double click']";
    public static readonly string TextRightClick = "//p[text()='You have done a right click']";
    public static readonly string TextDynamicClick = "//p[text()='You have done a dynamic click']";
    
    public static readonly string ListLinks = "//span[text()='Links']";
    public static readonly string LinksAll = "//h1[text()='Links']//following-sibling::p//a";
    public static readonly string TextLinkResponse = "id=linkResponse";
}