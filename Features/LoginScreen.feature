Feature: LoginScreen
	In order to manage google login screen
	As a user
	I want to verify that google login screen is as expected

@Automation @PageLoad
Scenario: Check google account login url  
	Given User opens browser
	When User has entered google account url in the browser 
	Then Login page should be displayed 

@Automation @ForgortButton
Scenario: Check Forgot email button on login screen
	Given User opens browser and enter url
	When User click on forget email button
	Then Forgot email screen should be displayed

@Automation @LearnMoreLink
Scenario: Check Learn more link on login screen
	Given User opens browser and enter url
	When User click on Learn more link
	Then Learn more page should be displayed

@Automation @CreateAccount
Scenario: Check Create account link on login screen
	Given User opens browser and enter url
	When User click on Create accoun link and selete given options
	Then Create account page should be displayed

@automation @vaildTest 
Scenario: Enter email or phone and click on next button
	Given User opens browser and enter url
	When User enter valid email or phone
	And User click on the next button
	Then Page to enter password should be displayed

@automation @invaildTest 
Scenario: Invalid email or phone
	Given User opens browser and enter url
	When User enter invalid email or phone
	And User click on the next button
	Then Enter valid email or phone message is displayed
	
@automation @NullValueTest 
Scenario: Null value in email or phone
	Given User opens browser and enter url
	When User enter null value email or phone
	And User click on the next button
	Then Enter email or phone message is displayed

@automation @Non-Existing
Scenario: Non-Existing google account
	Given User opens browser and enter url
	When User enter Non-Existing email or phone
	And User click on the next button
	Then Couldn't find your google account message is displayed


