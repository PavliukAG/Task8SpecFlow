Feature: Scenario2

@Chrome
Scenario: Successful "BLOUSE" search
	Given the shopping page is opened
	When in the search field, enter the keyword: Blouse 
	And click the search icon 
	Then the search query "BLOUSE" is displayed in the resualt page

@Chrome
Scenario: Successfully adding an item "BLOUSE" to the cart with conditions
	Given the search query 'Blouse' is displayed in the resualt page
	When move and click "More" button
	When choose conditions for Quantity = '3', Size = 'L', Color = 'White'
	And click "Add to cart" button
	When modal window with a title "Product successfully added to your shopping cart" is displayed
	Then click "Continue shopping" button

@Chrome
Scenario: Successful "PRINTED SUMMER DRESS" search
	Given the item page is opened
	When in the search field, enter the keyword: Printed summer dress 
	And click the search icon 
	Then the search query "PRINTED SUMMER DRESS" is displayed in the resualt page

@Chrome
Scenario: Successfully adding an item "PRINTED SUMMER DRESS" to the cart with conditions
	Given the search query 'PRINTED SUMMER DRESS' is displayed in the resualt page
	When move and click "More" button
	When choose conditions for Quantity = '5', Size = 'M', Color = 'Orange'
	And click "Add to cart" button
	When modal window with a title "Product successfully added to your shopping cart" is displayed
	Then click "Proceed to checkout" button

@Chrome
Scenario: Make sure the items in the cart have been added correctly
	Given the cart page is opened
	Then name, color, size, quantity, price and total price is displayed correctly for double item 

@Chrome
Scenario: Make sure it is possible to remove an item from the cart
	Given the cart page is opened
	When delete item 'Printed summer dress' from cart
	Then item 'Blouse' is displayed in cart
	And the one item is displayed in the cart
