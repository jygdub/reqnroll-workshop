Feature: Free Shipping
           
Scenario: Customer with more than 20 euros of products gets free shipping
    Given the customer has a shopping cart with no products
    And Product 'Book A' of type 'Books' with a price of '€19,99' exists
    And Product 'Book B' of type 'Books' with a price of '€20,00' exists
    And the customer adds 'Book A' to their shopping cart
    And the customer adds 'Book B' to their shopping cart
    When the customer checks out their shopping cart
    Then the total price of the order is '€39,99'
    And the costs for shipping are '€0,00'
    