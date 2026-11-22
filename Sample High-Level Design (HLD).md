# High-Level Design (HLD)

**Project Name:** [Grocery-E-Shopping-Portal]  
**Author:** [ARUN]  
**Date:** [20/11/2026]  
**Version:** [1.0]  
**Status:** In Review

---

## 1. Problem Statement

A Grocery shop application is needed to be prepared, which is used to order grocery products seamlessly.
It should allow users to order the products remotely.
The existing applications are time consuming and it doesn't enable future extension.


## 2. Goals and Objectives

1. To have strong user authentication so that security is reliable.
2. To implement effective shopping system that enables selection of products.
3. To implement cart option that enables user to store multiple products multiple time and purchase accordingly.


## 3. Scope

### 3.1 In Scope

- Customer registration and login.
- Displaying Product categories
- Search option is enabled.
- Option to put in cart and remove it.
- Purchase summary and pricing logics.

### 3.2 Out of Scope

- Admin side management.
- Payment option for customer.
- Stock updation from owner.
- User side profile changes.

### 3.3 Assumptions and Constraints


- **Assumptions:**
- The data needs to be stored persistently, so the stock maintenance can be done.
-  When user logs-out and log-in, the cart products need to be displayed.
- The stock is updated after the purchase of the products. 
- The user data also needs to be stored persistently for smooth log-in purposes.

## 4. Requirements

### 4.1 Functional Requirements


| ID | Requirement | Description | Priority |
|---|---|---|---|
| FR-01 | User Registration | The application should receive details from user | [high] |
| FR-02 | User Login | The application should authenticate using credentials | [high] |
| FR-03 | Product categories | The application should display different products under various categories | [high] |
| FR-04 | Product search | The application should allow user to search selective product | [high] |
| FR-05 | Product listing | The application should display product with name, price and availability | [medium] |
| FR-06 | Carting option | The product should be able to added to cart | [high] |
| FR-07 | Cart removal | The product should be able to removed from cart | [high] |
| FR-08 | Stock updation | After purchase the stock should be updated | [high] |


### 4.2 Non-Functional Requirements


| ID | Attribute | Requirement / Expectation |
|---|---|---|
| NFR-01 | [Security] | [The user credentials should be stored securely] |
| NFR-02 | [Data-Persistence] | [Product in cart should be stored persistenly for future look-up] |
| NFR-03 | [Usability] | [The application flow should be user-friendly] |
| NFR-04 | [Maintainability] | [The application should be divided into layers so future extension can be made] |

### 4.3 Open Questions and Clarifications


| ID | Question / Uncertainty | Impact on Design | Status |
|---|---|---|---|
| Q-01 | [Details of the products that are sold by customer] | [Improper information of product in the app] | [Resolved] |
| Q-02 | [Details to be collected from user during signup] | [Misses information for tracking user] | [Resolved] |
| Q-03 | [Limits to adding to cart] | [Deviates from customer needs] | [Resolved] |


---

## 5. Proposed Solution

A Grocery E-Shoppping Portal needs to be developed, which should allow customers to purchase groceries.

### 5.1 Solution Overview

- Users can register and login to the application.
- They can explore differnt grocery products and add them to cart
- In cart they, can purchase them individually or on-whole as their wish.
- The stock will be updated after the purchase of the product.

**Proposed Approach:**

The user registers into the application.
The System authenticates the user.
THe user can browse into different categories of products.
They can search individual product which they need.
They can view the cart which consists of their carted items.
They can finally purchase the items in cart individually or fully as their wish.

### 5.2 High-Level Architecture

The System contains three-layer architecture.
The four layers are:
1. Model layer
2. View Layer.
3. Service layer
4. Repository layer
**Architecture Diagram:**

[![alt text](HLD-1.png)]


| Component | Responsibility | Interactions |
|---|---|---|
| [View Layer] | [Interacts with user such as collection and displaying data to user] | [Service layer] |
| [Service layer] | [It consists of business logics of the application] | [View layer, Repository layer] |
| [Repository layer] | [It enables the storage of data in the files/database] | [Service layer, Model layer] |
| [Model layer] | [It consists of data models of the application] | [Repository layer] |


### 5.3 Technology Stack


| Area | Choice | Version | Reason for Selection |
|---|---|---|---|
| [Language / Runtime] | [C#] | [8 or above] | [Supports OOPS concept and easily maintainable] |
| [Data Storage] | [JSON (File storage)] | [10] | [Enables easy convertion to database] |
| [Tools / Libraries] | [Visual Studio] | [18.0.2] | [Supports debugging of C# applications] |
| [Version Control] | [Git/Github] | [2.56.0] | [Easily tracable and updatable] |


### 5.4 Module / Class Design

**Class / Module Diagram:**

| Module / Class | Layer | Responsibility | Key Operations |
|---|---|---|---|
| [User Module] | [Service] | [Retrieves data from user] | [Manages the user data] |
| [Cart Module] | [Service] | [Manages cart logics] | [Adding and removing product from cart] |
| [Authentication Module] | [Service] | [Modifies the credentials] | [Encrypts and decrypts the credentials] |
| [Storage Module] | [Repository] | [Stores and retrieves data] | [Data are stored persistently and fetched accordingly] |


### 5.5 Data Design

**Design and Rationale:**

The application uses JSON for data storage and retrieval.

It mainly consists of two different data designs.
1. User model - Consists of user data.
2. Cart model - Consists of product data.

### 5.6 User Interface Design

| Screen ID | Screen Name | Purpose | Available Actions | Navigates To |
|---|---|---|---|---|
| S-01 | [Registration Screen] | [To enable registration for new customer] | [Enters details] | [Login] |
| S-02 | [Login Screen] | [Authenticate user] | [Enter login credentials] | [Main menu] |
| S-03 | [Main menu] | [Dislays list of options to redirect] | [Use can move to cart, product] | [Product] |
| S-04 | [Product Screen] | [Displays various list of products] | [User can add the product to cart] | [Cart Screen] |
| S-05 | [Cart Screen] | [Displays the items in cart] | [Users can purchase individually or whole] | [Main Menu] |


### 5.7 Core Workflows

![alt text](GroceryShopAppDesign-1.png)

**Workflow 1: [User Registration and Login]**

1. The user opens the registration page.
2. The user enters Full name, Unique user name, Mobile number, Password.
3. The application validates the information.
4. After signup, the user can login using login page.
5. The user needs to enter login page credentials which is unique user-name and password.
6. After successful login, it enables user to main menu.

**Workflow 2: [Product and Cart]**

1. User can redirect to product page using main menu.
2. The System displays various categories of products.
3. The user can select their willing category of product and search individual product.
4. The selected product can be added to cart.
5. After redirecting to cart, the user can initialise the purchase.
6. The product purchase can be done individually or the whole.
7. After the purchase, the story is updated.

### 5.8 Validation and Error Handling

| Scenario | Expected Behaviour | Proposed Handling |
|---|---|---|
| [Invalid login details] | [User should not be allowed to log in] | [Displays invalid credential message] |
| [Duplicate data entry] | [User cannot be able to sign up] | [Displays invalid signup details message] |
| [Unknown product search] | [Product should not be displayed] | [Displays no product found message] |
| [No stock of product] | [User cannot be able to add to cart] | [Displays out of stock message] |
| [Quanity is more than stock] | [User cannot be able to add to cart] | [Displays insufficient stock message] |


### 5.9 Security and Other Design Considerations

1. User password is hashed and stored in the repository.
2. The product quantity should be checked before purchasing the product in cart.
3. Input validation should prevent invalid data.

### 5.10 Extensibility and Future Readiness

| Change Scenario | How the Design Supports It | Code Change Needed (Y/N) | Effort |
|---|---|---|---|
| [Online payment] | [A separate payment module can be created and integrated with purchase module] | [Y] | [Medium] |
| [Product Image addition] | [Images are already stored in the file which can be used for extension] | [Y] | [Low] |
| [Database integration] | [Repository layer can be altered with required database] | [Y] | [Low] |
| [Change into web application] | [Individual layers can be integrated with individual stacks] | [Y] | [Medium] |

---

## 6. Testing Approach

### 6.1 Testing Scope

1. Verify user registration and login.
2. Verify product category display.
3. Verify product search.
4. Verify addition and removal of product in cart.
5. Verify stock updation.

### 6.2 Test Scenarios

| Test ID | Scenario | Expected Result |
|---|---|---|
| TC-01 | [Register with valid details] | [User account is created successfully] |
| TC-02 | [Register with invalid details] | [User account is not created] |
| TC-03 | [Login with valid details] | [User is logged into main menu] |
| TC-04 | [Login with invalid details] | [User won't be able to login] |
| TC-05 | [VIew product categories] | [All the product categories should be displayed] |
| TC-06 | [Search existing product] | [Display the details of the product] |
| TC-07 | [Search non-existing product] | [Should display the non-existence message to usage] |
| TC-08 | [Addition of product to cart] | [Product should be present in cart] |
| TC-09 | [Removal of product from cart] | [Product should not exist in cart] |
| TC-10 | [Purchase of empty cart] | [User cannot be able to purchase] |

---

## 7. Design Decisions and Trade-offs

Document the important design decisions, alternatives considered, and the rationale behind the proposed choices.

| ID | Decision | Alternatives Considered | Selected Approach | Rationale and Trade-offs |
|---|---|---|---|---|
| D-01 | [Application architecture] | [Hexagonal/MVVM] | [MVC] | [Reliable for small scale application and extensible] |
| D-02 | [Storage unit] | [Databases/Files] | [JSON file storage] | [Extensible for future upgrades] |

---
