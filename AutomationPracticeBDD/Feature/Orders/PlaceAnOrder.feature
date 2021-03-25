Feature: PlaceAnOrder
	Order a T-Shirt and Verify in Order History

@PlaceOrder
Scenario: Place an Order
	Given I navigate to AutomationPractice website
    When I sign in with username 'nesa246@gmail.com' and password 'alex246#'
	Then I see account home page
	When I select product 'T-SHIRTS'
	Then Select the available product
	And Continue and Place Order
	Then Verify the placed order in the accounts order history

