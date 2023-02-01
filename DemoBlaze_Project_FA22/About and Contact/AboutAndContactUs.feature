Feature: AboutAndContactUs

A short summary of the feature

@tag1
Scenario: Playing the About us Video
	Given User will be at homepage
	When User clicks about us on navigation bar
	Then About us Popup appears
	When user clicks on play button
	Then the video starts playing
	And user clicks on close button


@tag2
Scenario: Sending Message using Contact tab
	Given User will be at homepage
	When User clicks contact on navigation bar
	Then contact Popup appears
	When user enters information '<contactEmail>' '<contactName>' '<contactMessage>'
	And user clicks on Send Message
	Then Alert appears with text "Thanks for the message!!"

	Examples:
	| contactEmail        | contactName | contactMessage               |
	| basimtester@test.pk | Basim Ahmed | This is an automated message |