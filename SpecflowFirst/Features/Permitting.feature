Feature: Permitting
	Navigating to the Permitting Screen

Background: 
	Given The user is logged into the application
	And The user is on 'Permitting' screen

Scenario: Add notes in the main Pane on Permitting
	Given 'Permitting' on 'Permitting' is expanded
	And The user 'Add' Notes
	When The user Saves Notes on the window
	Then The text entered should be visible when the user hovers over the Notes button

Scenario: Edit Permitting
	Given 'Permitting' on 'Permitting' is expanded
	When The user 'Edit' Permitting
	Then The user should be able to Save Permitting


	 