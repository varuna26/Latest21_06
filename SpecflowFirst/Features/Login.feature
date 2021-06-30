Feature: Login
	Login to the Application

Scenario: To Login to the application successfully
	Given I am on community dev login page
	When I Enter "vv" in Username
	And I Enter "trakit1234" in Password
	And I Click Login button
	Then I should be able to login successfully
	
#Scenario: To Login to the application
#	Given The User navigates to the website "<url>"
#	When The User tries logging in with Username and Password
#		 | Username | Password   |
#		 | vv       | trakit1234 |
#	Then The User should be able to login successfully
#
#Scenario: To try logging in to the application
#	Given The User navigates to the website "<url>"
#	When The User tries logging in with invalid UserName and Password
#		 | Username | Password   |
#		 | vv       | abcd@45 |
#	Then The User should not be able to login
#
#Scenario: To try logging in to the application with valid credentials
#	Given The User logs into the application with "<UserName>" and "<Password>"
#	Then The verify the result "<ResultSet>" contains "<Value>"
#		 | Key  | Value |
#		 | Home | Home  |
#	And The User logs out of the application
#		 
##Scenario: To try logging in to the application with invalid credentials
##	Given The User logs into the application with "<UserName>" and "<Password>"
##	Then The verify the result "<ResultSet>" contains "<Value>"
##		 | Key  | Value |
##		 | Login Error | UserName or Password is invalid. Please try again with valid credentials |
#
#Scenario Outline: To try logging in to the application with invalid credentials
#	Given The User logs into the application with "<UserName>" and "<Password>"
#	Then The verify the result "<ResultSet>" contains "<Value>"
#		 | Key  | Value |
#		 | <Key> | <Value> |
#		 Examples:
#		 | UserName | Password | Key   | Value                    |
#		 | abc      |          | Error | This is a required field |
#		 |          |  Pwd     | Error | This is a required field |