# Test Plan – Grocery Shop Application

## 1. User Registration and Login

| TEST ID | SCENARIO | EXPECTED RESULT | PASS/FAIL |
|---|---|---|---|
| TC-01 | Register with valid username, password and required details | User account is created successfully | Pass |
| TC-02 | Register with a username containing only spaces | Registration is rejected | Pass |
| TC-03 | Register with a password that does not satisfy the validation rules | Registration is rejected with an appropriate message | Pass |
| TC-04 | Register with valid details after correcting invalid input | User account is created successfully | Pass |
| TC-05 | Login using valid username and password | User is logged in successfully | Pass |
| TC-06 | Login using an incorrect username | Login is rejected | Pass |
| TC-07 | Login using an incorrect password | Login is rejected | Pass |
| TC-08 | Login with both username and password empty | Login is rejected and validation messages are displayed | Pass |
| TC-09 | Login using an account that does not exist | Login is rejected with an appropriate message | Pass |

## 2. Product Viewing and Searching

| TEST ID | SCENARIO | EXPECTED RESULT | PASS/FAIL |
|---|---|---|---|
| TC-10 | Select the product category | All products of that category are displayed | Pass |
| TC-11 | Select an invalid category option | Invalid selection is rejected | Pass |
| TC-12 | Search for an existing product | Matching product details are displayed | Pass |
| TC-13 | Search for a non-existing product | Product not found message is displayed | Pass |
| TC-14 | Search using a product name with different letter casing | Matching product is found if the search is case-insensitive | Pass |
| TC-15 | View product details | Product name, price, category and available stock are displayed | Pass |
| TC-16 | View products when no products are available | Appropriate no-products message is displayed | Pass |

## 3. Cart Management

| TEST ID | SCENARIO | EXPECTED RESULT | PASS/FAIL |
|---|---|---|---|
| TC-17 | Add an available product to the cart | Product is added to the user's cart | Pass |
| TC-18 | Add multiple products to the cart | All selected products are added successfully | Pass |
| TC-19 | Add a product with zero available stock | Product cannot be added to the cart | Pass |
| TC-20 | Add a product with a quantity greater than available stock | Addition is rejected with an appropriate message | Pass |
| TC-21 | View the cart after adding products | All added products and their quantities are displayed | Pass |
| TC-22 | View an empty cart | Appropriate empty-cart message is displayed | Pass |
| TC-23 | Remove an existing product from the cart | Selected product is removed successfully | Pass |
| TC-24 | Remove a product that does not exist in the cart | Removal is rejected with an appropriate message | Pass |
| TC-25 | Clear the cart containing multiple products | All products are removed from the cart | Pass |
| TC-26 | Clear an already empty cart | Application handles the operation without errors | Pass |

## 4. Purchase and Checkout

| TEST ID | SCENARIO | EXPECTED RESULT | PASS/FAIL |
|---|---|---|---|
| TC-27 | Purchase a product immediately using the purchase option | User is taken through the checkout process successfully | Pass |
| TC-28 | Purchase all products in the cart | All cart products are included in the order | Pass |
| TC-29 | Purchase selected products from the cart | Only selected products are included in the order | Pass |
| TC-30 | Attempt to purchase an empty cart | Purchase is rejected with an appropriate message | Pass |
| TC-31 | Enter a valid delivery address | Delivery address is accepted | Pass |
| TC-32 | Enter an empty delivery address | Checkout is rejected with a validation message | Pass |
| TC-33 | Enter a valid delivery date in dd-MM-yyyy format | Delivery date is accepted | Pass |
| TC-34 | Enter a delivery date in the past | Past delivery date is rejected | Pass |
| TC-35 | Select the appropriate delivery slot | Selected delivery time is saved successfully | Pass |
| TC-36 | Complete checkout with valid delivery details | Order is created successfully | Pass |
| TC-37 | Complete checkout for selected cart products | Only selected products are included in the order | Pass |
| TC-38 | Complete checkout with multiple products | Order total is calculated correctly | Pass |
| TC-39 | Complete checkout with valid details | Purchased products are removed from the cart | Pass |

## 5. Order History and Tracking

| TEST ID | SCENARIO | EXPECTED RESULT | PASS/FAIL |
|---|---|---|---|
| TC-40 | Select Track Order from the main menu | User's order history is displayed | Pass |
| TC-41 | View order history when previous orders exist | All orders belonging to the logged-in user are displayed | Pass |
| TC-42 | View order history when no orders exist | Appropriate no-orders message is displayed | Pass |
| TC-43 | View an order containing multiple products | All purchased products are displayed correctly | Pass |
| TC-44 | View order details | Order ID, delivery address, delivery date and delivery time are displayed | Pass |
| TC-45 | View the total amount of an existing order | Correct order total is displayed | Pass |
| TC-46 | Login using another user account and view order history | Only the logged-in user's orders are displayed | Pass |

## 6. Wishlist Management

| TEST ID | SCENARIO | EXPECTED RESULT | PASS/FAIL |
|---|---|---|---|
| TC-47 | Add an available product to the wishlist | Product is added to the wishlist successfully | Pass |
| TC-48 | Add multiple products to the wishlist | All selected products are added successfully | Pass |
| TC-49 | Add the same product to the wishlist again | Duplicate wishlist entry is prevented if duplicate checking is implemented | Pass |
| TC-50 | View the wishlist containing products | All wishlist products are displayed | Pass |
| TC-51 | View an empty wishlist | Appropriate empty-wishlist message is displayed | Pass |
| TC-52 | Purchase a product from the wishlist | Selected wishlist product proceeds through checkout | Pass |
| TC-53 | Purchase multiple available wishlist products | Selected products proceed through checkout successfully | Pass |
| TC-54 | Purchase a wishlist product with zero stock | Purchase is rejected with an appropriate message | Pass |
| TC-55 | Attempt to purchase a product from an empty wishlist | Purchase is rejected | Pass |

## 7. Admin Login and Stock Management

| TEST ID | SCENARIO | EXPECTED RESULT | PASS/FAIL |
|---|---|---|---|
| TC-56 | Login using valid admin credentials | Admin is logged in successfully | Pass |
| TC-57 | Login using an incorrect admin credential | Admin login is rejected | Pass |
| TC-58 | Login using normal user credentials in the admin login option | Access to the admin menu is denied | Pass |
| TC-59 | Login to the admin account when products have low stock | Low-stock warning message is displayed in red | Pass |
| TC-60 | View the admin stock management product list | All products are displayed with serial numbers and available stock | Pass |
| TC-61 | Select a valid product serial number | Corresponding product is selected for stock updating | Pass |
| TC-62 | Enter an invalid product serial number | Invalid serial number is rejected | Pass |
| TC-63 | Enter a valid new stock quantity | Selected product stock is updated successfully | Pass |
| TC-64 | Enter zero as the new stock quantity | Product stock is updated to zero | Pass |
| TC-65 | Enter a negative stock quantity | Invalid stock quantity is rejected | Pass |
| TC-66 | Enter alphabetic characters as the new stock quantity | Invalid stock quantity is rejected | Pass |