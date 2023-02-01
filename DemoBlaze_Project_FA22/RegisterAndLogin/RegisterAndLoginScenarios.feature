Feature: RegisterAndLoginScenarios

A short summary of the feature

@tag1
Scenario: (Negative) Sign up to the website
	Given Goto Url https://www.demoblaze.com/index.html
	When User clicks Sign Up
	And User enters the username "<userName>" and password "<password>" and clicks Sign Up
	Then User sees the failed popup message

	Examples: 
	| userName | password |
	| test     | test     |
	| xyz      |          |

@tag2
Scenario: User will register into the website with a new username
	Given Goto Url https://www.demoblaze.com/index.html
	When User clicks Sign Up
	And User will enter the username "<userNamePositive>" and password "<passwordPositive>" and click Sign Up
	Then User sees the success popup message

	Examples: 
	| userNamePositive | passwordPositive |
	| BasimTester1     | test             |

@tag3
Scenario: (Negative) Login to the website
	Given Goto Url https://www.demoblaze.com/index.html
	When User clicks Login
	And User enters the username "<loginuserNameN>" and password "<loginpasswordN>" and clicks Login
	Then User sees the failed login popup message

	Examples: 
	| loginuserNameN | loginpasswordN |
	| BasimTester1   | testtesttest   |
	| testtesttest   |                |

@tag4
Scenario: (Positive) Login to the website
	Given Goto Url https://www.demoblaze.com/index.html
	When User clicks Login
	And User enters the username "<loginuserNameP>" and password "<loginpasswordP>" and click Login
	Then User gets redirected to homepage

	Examples: 
	| loginuserNameP | loginpasswordP |
	| BasimTester1   | test           |


