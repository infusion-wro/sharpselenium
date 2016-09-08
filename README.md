##Framework design

###Selenium properties

**Selenium.settings** is a file that consist few settings for Selenium:

* **DefaultTimeout** - a default timeout in seconds for waiting for various events in the system like presence of the element, availability of the frame, page reloading etc.,
* **AlertTimeout** - in seconds which represents how much time the system will wait for alert to be present in the system,
* **Url** - URL of tested application,

###PageElement

The **IPageElement** interface represents a particular element of the page. It consists of three methods:

* **getBy(String... placeholders)** - this method returns a **By** object which is used by Selenium to locate particular element on the site. It takes a placeholders as a parameters because it is possible to have elements with dynamically created locators and By object is immutable,
* **getType()** - it returns a textual representation of the locator type of this element (i.e. xpath, name, id). There is no method to get this information from By object. It can be used for debugging purposes,
* **getExpression()** - it returns a textual representation of the expression used to locate this element (i.e. //td[2], searchButton). There is no method to get this information from By object. It can be used for debugging purposes.

The **PageElement** class implements IPageElement interface has two additional fields:

* **BY_TYPE** - it is an value which is telling what kind of expression will be used to locate the element i.e xpath, name, id,
* **EXPRESSION** - it is an actual expression that will locate element i.e. //td[2], searchButton,

This class is then extended by concrete classes which are containers for the concrete page elements (i.e. ResultsPage). The concrete class has some static public fields that are representing the particular elements of the page. If the code of UI will change only those classes has to be adjusted - test code will stay the same.

In this place it is worth to mention that there is a possibility to locate an elements with dynamically created expressions. Let's consider an example. We want to search for a result on results page by providing the information like date, tournament and match which is given in runtime. The xpath of particular row consist of those information and we don't want to hard-code it in our xpath expression for locating that row. In that case we can use an expression with placeholders i.e. //tr[@id='{0}']/td.
This **{0}** is a placeholder which can be provided in getBy() method. It will be then replaced by a ByFactory in runtime and the final expression will be provided i.e. getBy("someId") will give an xpath locator //tr[@id='someId']/td. To support that functionality there is also a **IPlaceholdersProvider** interface provided. It can be implemented by a class that represents some common object in a system like **ResultRow**. It holds the parameters of the object like date, tournament etc. and provides a method **getPlaceholders()** which is returning an array of strings that can be used to resolve a placeholders in a locator expression.

###ByFactory

**ByFactory** class has only one static method **get(ByType locatorType, String expression, String... placeholders)** which returns actual Selenium By locator based on the locator type 
(xpath, name, id), expression and placeholders. It was introduced to support dynamically created expressions in which we can resolve placeholders before creating actual Selenium By object which is immutable.

###DropDownValue

**IDropDownValue** interface is representing an option that can be selected in drop down. It is then implemented by DropDownValue class which is extended by concrete classes that are holding the values for particular drop downs used all across the site. It is used because of two reasons: to make sure that only the values available in the given drop down can be selected and to make sure if the drop down value will be changed we will make an adjustment only in one class without making changes in the test code.

###PageObject

The **PageObject** class is the most important class of the framework. It encapsulates all the functionalities related to page elements location and interactions with particular page. It is also the main place where Selenium is used for the loose coupling purpose. This class is extended by concrete classes which are related to particular pages like MainPage or Results Page. The PageObject class is also parameterized with T parameter which has to implement an IPageElement interface. This ensures that in the concrete page object class methods only the elements related to that page can be used. It also holds the values for default timeout, alert timeout, the url of the application and the instance of the Selenium web driver (SESSION).

The one of the most important features of PageObject is a **getWebElement(T element, String...placeholders)** method which takes an T element and optional placeholders (for elements with dynamically created locator expressions) and it executes a few steps:

* it constructs the Selenium By locator using the getBy(placeholders) abstract method from PageElement interface,
* it waits for an element to be clickable using the explicit wait so it returns an WebElement only when it is ready to interaction i.e. clicking, sending text etc. 

This method is private because we didn't want to use Selenium related code (like WebElement class) in too many places because it will cause the tight coupling. All the methods that are using Selenium related classes are private. All the mechanisms like waits, element locating and so on are hidden in PageObject class. This can be called the deepest level of the framework which should need the least amount of changes.

The second level of the framework are the methods that have protected modifier. They are directly available in a classes extending the PageObject class. However, they are related with page elements interaction that shouldn't be visible and available from the actual test code. When we are calling a method which causes the load of the new page we are returning a PageObject related to this new site as a result i.e. calling the method clickResultsPage() in MainPage page object will click the link and return an ResultsPage page object as a result. Then we can interact with this new page object.

The last level of the framework are the methods implemented in concrete PageObject classes and a public methods from the PageObject. Those methods can be called directly in test's code. The methods implemented in classes extending the PageObject are grouping some common functionalities related with particular pages in like choosing a tournament or a season. The public methods in PageObject class allows to interact with page elements like clicking them, sending keys, ticking the checkbox, setting the drop down value etc. Those interactions are also available for WebElement objects from Selenium but again we are not manipulating directly on them to be less dependent on the external framework. One of the interesting methods is the **clickAndWaitForPageToLoad(T element, String... placeholders)**. Sometimes in the application application there is a lot of buttons and other controls that arecausing the page to reload. To be sure that we are checking the state of the control after the reload not before or during it, we can call this method for an element that is causing the page to reload. PageObject will then take care of everything.

##Tests organization

###SeleniumTest

**SeleniumTest** is a class that should be extended by every Selenium based test. It is simply holding the Selenium web driver instance (SESSION) and it creates the new instance of it before every test and closes it after every test to make sure we have a clean session in every test. In the test code we are giving this session as a parameter of a MainPage page object
constructor in the first step of a test to navigate to the main page of our application. In the next steps we are interacting with the page objects in the same way the user would interact with the site - clicking some buttons, filling some text fields, ticking the checkboxes etc. Whenever we need to navigate to another page by clicking some link a new page object related to that part of the site is returned for us. From that point we are interacting with this new page object as a user with a newly opened page would. To see a good example of it please see the **SampleTest** class.

All the test are following the GIVEN - WHEN - THEN convention with a proper comments in the code. Here also I took the convention that there is no actual THEN section because if something gone wrong during the execution of the test then the custom **SeleniumTestException** is thrown. If all the steps of the test executes successfully then I assume the test is passed with green status.