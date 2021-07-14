@WebUi
Feature: SmartBearWebUiLogin
	In order to access my account in the online shopping portal
	As a registered user
	I want to be able to log in

Scenario: Login as registered user
	Given I login to smartstore portal as "smartbear@yahoo.co.uk"
	When the two numbers are added