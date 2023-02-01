Feature: MainPage

A short summary of the feature

@tag1
Scenario: (Positive) Add an item to cart 
	Given User will be at homepage
	When user clicks an item
	Then user will be redirected to the product details
	When user clicks Add to Cat
	Then User sees the message 'Product added'


@tag2
Scenario: Adding Multiple items to cart 
	Given User will be at homepage
	When user adds a phone to cart
	Then User sees the message 'Product added' and clicks ok
	When User Goes back to homepage
	And User choses Laptop category
	And user adds Laptop to cart
	Then User sees the message 'Product added'

@tag3
Scenario: Placing a complete Order 
	Given User will be at homepage
	When user adds items to cart
	And user clicks on Cart on the navigation
	Then user is directed to Cart page
	When user clicks on 'Place Order'
	Then user sees a Popup of customer details
	When user enters "<Name>" "<Country>" "<City>" "<CreditCard>" "<Month>" "<Year>" 
	And user clicks on Purchase
	Then user sees a the message 'Thank you for your purchase!'

	Examples: 
	| Name  | Country  | City    | CreditCard | Month | Year |
	| Basim | Pakistan | Karachi | 123456789  | 1     | 2023 |




