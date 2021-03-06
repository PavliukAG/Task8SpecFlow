Feature: Scenario1

@Chrome
@Firefox
@Edge
Scenario: Add item in cart
	Given the shopping page is opened
	When in the search field, enter the keyword: Summer
	And click the search icon 
	Then the search query "SUMMER" is displayed in the resualt page
	When open dropdown sorting select the Price: Highest first option
	Then items on the page are sorted according to the selected option
	Given save information about the first item
	When move and click "Add to cart" button
	Then click "Proceed to checkout" button
	Then the item data matches the item data in the cart
