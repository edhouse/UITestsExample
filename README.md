# UITestsExample
Example how to do UI testing for WPF and WinForms applications.

The solution consists of 7 projects:

ExampleApplication.Logic
------------------------
There is bussiness logic of the application. It is used for both WPF and also WinForms app version.

ExampleApplication.WinForms
---------------------------
The view layer for WinForms.

ExampleApplication.Wpf
---------------------------
The view layer for WPF.

ExampleApplication.UiTests.AppModel
-----------------------------------
For UI testing we need some interface to interact the application. The interface models the applications UI from the user point of view. The interaction is made using TestStack.White.

ExampleApplication.Resources
----------------------------
Besides some usual resources there is folder named <b>AutomationIdentifiers</b>. In that folder should be UIAutomation identifiers that are used in both the application and the application model to identify the controls.

ExampleApplication.ScreenRecorder
---------------------------------
Useful app to record the screen during the test.

ExampleApplication.UiTests
--------------------------
There are actual tests. Tests are written as the XUnit tests using the <b>ExampleApplication.UiTests.AppModel</b> to perform the UI interaction. One class per each test scenario. Each test class inherits the <b>BaseTest</b> class. Each test runs new application instance and starts recording. At the end of the test recording is stopped. If the test succeeds the screen video is removed. If the test fails the screenshot is taken prior the application is shutdown. Screenshots and videos are named after the test.
