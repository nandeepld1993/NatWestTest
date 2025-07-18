namespace AutomationTests.PageControls;

public class AlertsFrameWindowsPageControl
{
    public static readonly string TabForms = "//div[text()='Alerts, Frame & Windows']";
    public static readonly string ListBrowserWindow = "//span[text()='Browser Windows']"; 
    public static readonly string BtnTab = "id=tabButton";
    public static readonly string BtnWindow = "id=windowButton";
    public static readonly string BtnMsgWindow = "id=messageWindowButton";
    public static readonly string TextNewWindow = "id=sampleHeading";
    
    public static readonly string ListAlerts= "//span[text()='Alerts']"; 
    public static readonly string BtnAlert = "id=alertButton";
    public static readonly string BtnTimerAlert = "id=timerAlertButton";
    public static readonly string BtnConfirm = "id=confirmButton";
    public static readonly string BtnPrompt = "id=promtButton";
    public static readonly string TextConfirmResult = "id=confirmResult";
    public static readonly string TextPromptResult = "id=promptResult";
    
    public static readonly string ListNestFrames = "//span[text()='Nested Frames']"; 
    public static readonly string ParentFrame = "id=frame1";
    public static readonly string ChildFrame = "//iframe[contains(@srcdoc,'Child Iframe')]";
    public static readonly string TextChildFrame = "//p[text()='Child Iframe']";
    public static readonly string TextFrameHeader = "//h1[text()='Nested Frames']";
}