Feature: Free Shipping
           
Background: 
    Given the customer has a shopping cart with no products
    And the following products exists:
      | Name         | Type        | Price   |
      | Apples       | Food        | €1,99   |
      | Bananas      | Food        | €2,99   |
      | Book A       | Books       | €19,99  |
      | Book B       | Books       | €20,00  |
      | Refrigerator | Electronics | €799,99 |
      | Couch        | Furniture   | €499,99 |
      | Chair        | Furniture   | €12,99  |

Scenario Outline: Customer with less than 20 euros of products pays for shipping
    Given the customer adds '<product>' to their shopping cart
    When the customer checks out their shopping cart
    Then the total price of the order is '<total>'
    And the costs for shipping are '€3,95'
    
    Examples: 
      | product | total  |
      | Apples  | €1,99  |
      | Bananas | €2,99  |
      | Book A  | €19,99 |  
        
Scenario: Customer with more than 20 euros of products gets free shipping
    Given the customer adds 'Book A' to their shopping cart
    And the customer adds 'Book B' to their shopping cart
    When the customer checks out their shopping cart
    Then the total price of the order is '€39,99'
    And the costs for shipping are '€0,00'