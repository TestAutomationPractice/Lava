Feature: Admin
	In order to check the movie page functionality
	As an admin
	I want to be to add new movie

Scenario: Adding a new movie
	Given I am on Autothon challenge page
	And   I login with below details
	| username | password |
	| Admin    | password |
	When  I add a new movie with below details
	| Title    | Director  | Description                       | Categories | URL                         | Rating |
	| Lava 2.0 | Om Mishra | This is an effort of 4 Automators | Thriller   | https://Lava.automation.com | 5      |
	Then  I should be able to add movie successfully
