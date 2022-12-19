# product-stock-mvc

This project was built to practice recent knowledge I acquired about ASP .NET MVC Core,
especially in parts related to views and error handling.
The main focus is on ASP .NET MVC Core features, the better design was not in my plans.

Product Stock would be a website developed to simplify the management and organization of your company's stock,
in our application you will have a control of all the providers and what are the products provided by them.

You will have a list of suppliers, with the option to see more details, where you can see the information of that supplier
(such as personal data and contact details) and also each of the products that he can provide, with image, price and quantity available in stock.
In addition to being able to edit, delete and create a new supplier.

We also have a list with only the products available in our stock, being able to edit, delete or create a new one,
in the product details section, in addition to information about the product, you are also able to see which provider it was provided by and carry out
the necessary updates in your stock, having total control of your business, in a simple and easy way.
## 

# Some points to be highlighted

:heavy_check_mark:  This application was created with a 3-tier architecture: Web, Business and Data Access.  <br/>
:heavy_check_mark:  Good development practices were prioritized in this project, following S.O.L.I.D. Principles and Clean Code.  <br/>
:heavy_check_mark:  Generic and reusable methods were used in several parts of application, making the work smarter <br/>

<br />
<strong>Authentication</strong>

Created with Identity, it was used a system of claims, authenticated through the database connection.
Also with registration page, login and custom error page.
In the current configuration the lists and details of products and providers can be seen without authentication, but certain information
and creation/editing and deletion require specific Claims as a form of authentication.

<br />
<strong>Data Access</strong>

Using Entity Framework Core and the Repository Pattern pattern,
isolating the data access logic from the business layer and leaving the system decoupled and performatic.
The use of migrations was made to keep the system update simplified and also used the services
for validating methods that make changes to the database, making data writing safer

<br />
<strong>Exception Handling</strong>

Made with notifications, obtaining a complete log of each failure obtained in the application
through generic and reusable methods, optimizing our time in the search for bugs and any failures that may occur.

<br />
<strong>Validation</strong>

Using Fluent Validation, drastically reducing the chance of incorrect data writing
in the database and reinforcing the validation work that is already done in the front-end (via JQuery)
