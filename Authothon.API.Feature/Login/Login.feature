@Login
Feature: Login
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Login
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen



	@Login2
Scenario: Add twhree numbers
	Given I have entered 80 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 150 on the screen
