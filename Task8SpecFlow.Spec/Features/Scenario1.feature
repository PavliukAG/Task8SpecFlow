Feature: ShopSite

@Chrome
Scenario: The search term "SUMMER" is displayed above the list of products near the words 'SEARCH'
	Given the shopping page is opened
	When in the search field, enter the keyword: Summer
	And click the search icon 
	Then the search query "SUMMER" is displayed in the resualt page


@Chrome
Scenario: Items are sorted in descending order
	Given product catalog page is opened
	When open dropdown sorting select the Price: Highest first option
	Then items on the page are sorted according to the selected option

@Chrome
Scenario: Adding items to cart
	Given save information about the first item
	When move and click "Add to cart" button
	And go to cart
	Then the item data matches the item data in the cart
