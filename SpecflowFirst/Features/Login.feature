Feature: Login
	Login to the Application

Scenario: To Login to the application successfully
	Given I am on community dev login page
	When I Enter "vv" in Username
	And I Enter "trakit1234" in Password
	And I Click Login button
	Then I should be able to login successfully