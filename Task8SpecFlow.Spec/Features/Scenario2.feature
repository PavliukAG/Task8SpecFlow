Feature: Scenario2

@Chrome
@Firefox
@Edge
Scenario: Add items with some conditions
	Given the shopping page is opened
	When in the search field, enter the keyword: Blouse 
	And click the search icon 
	Then the search query "BLOUSE" is displayed in the resualt page
	When move and click "More" button
	When choose conditions for Quantity = '3', Size = 'L', Color = 'White'
	And click "Add to cart" button
	Then modal window with a title "Product successfully added to your shopping cart" is displayed
	And click "Continue shopping" button
	Then the 'Blouse' item page is opened
	When in the search field, enter the keyword: Printed Summer Dress 
	And click the search icon 
	Then the search query "PRINTED SUMMER DRESS" is displayed in the resualt page
	When move and click "More" button
	When choose conditions for Quantity = '5', Size = 'M', Color = 'Orange'
	And click "Add to cart" button
	Then modal window with a title "Product successfully added to your shopping cart" is displayed
	And click "Proceed to checkout" button
	Then name, color, size, quantity, price and total price is displayed correctly for double item 
	When delete item 'Printed Summer Dress' from cart
	Then only item 'Blouse' is displayed in cart
	
