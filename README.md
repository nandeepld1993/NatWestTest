**Natwest C# Playwright Automation Assessment Completed**

* I have reutilized the Basic solution and project setup.
* As part of UI automation below controls/pages are automated from the provided url.
   - Test cases for https://demoqa.com/automation-practice-form
   - Navigation to practice form page
   - Entered in the data into form
   - Clicking on Submit button
   - Validating entered data from table
* Apart from practice from below mentioned pages also automated
  - https://demoqa.com/text-box
  - https://demoqa.com/checkbox
  - https://demoqa.com/radio-button
  - https://demoqa.com/buttons
  - https://demoqa.com/links
  - https://demoqa.com/browser-windows
  - https://demoqa.com/alerts
  - https://demoqa.com/nestedframes
* Applied POM Design pattern to maintain the UI webelements
  - Created new folder **PageControls** under that created diffrent files based on the pages
    <img width="450" height="115" alt="image" src="https://github.com/user-attachments/assets/758aa69f-a671-4925-a2ca-b513012f1e3b" />
  - Created **FunctionLibrary** under that added navigation, entering the data and validation methods based on the pages
    <img width="633" height="133" alt="image" src="https://github.com/user-attachments/assets/5638b356-d129-4c50-a572-b3469baa8f8f" />
  - Maintained separate folder for **TestData** for the required test case, and used CSV file and Dictionary.
    <img width="566" height="106" alt="image" src="https://github.com/user-attachments/assets/7589f046-edd1-4b8f-89b7-d5e8217fe933" />
  - Under **Tests** folder added the test cases, and we just calling all the above created methods based on the test case
    <img width="451" height="123" alt="image" src="https://github.com/user-attachments/assets/f1e5de9a-7c50-46fb-af79-cb6d2f520275" />
* For Refit API testing of **https://reqres.in** used exisitng interface and added endpoint methods required for test case
  <img width="461" height="121" alt="image" src="https://github.com/user-attachments/assets/0be10a1c-2ec9-4ccc-8b2d-57274b2d8df9" />
  - under the test file added all the test cases and created separate file for serialize/deserialize of the data response
* Execution of the test cases, I have used xunit **[Fact]** attribute to differentiate the test cases
* To run multiple test cases i have added tag/category [Trait("Category", "API/UI")] based on the filter **dotnet test --filter "Category=UI"** and **dotnet test --filter "Category=API** we can run by navigating to solution.




